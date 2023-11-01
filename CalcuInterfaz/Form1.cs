using Microsoft.VisualBasic.Logging;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CalcuInterfaz
{
    public partial class Form1 : Form
    {

        static string entrada = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void agregarNumero(Object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            Ingreso.Text += boton.Text;
        }
        private void CButton_Click(object sender, EventArgs e)
        {
            if (Ingreso.Text.Length > 1)
            {
                Ingreso.Text = Ingreso.Text.Substring(0, Ingreso.Text.Length - 1);
            }
            else
            {
                Ingreso.Text = "";
            }

        }
        private void AC_Button_Click(object sender, EventArgs e)
        {
            Ingreso.Text = "";
            OutPut.Text = "";
        }
        private void Par_Button_Click(object sender, EventArgs e) { }
        private void X_Button_Click(object sender, EventArgs e)
        {
            Ingreso.Text += "*";
        }
        private void button12_Click(object sender, EventArgs e) { }
        private void button9_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void button17_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void Num0_Click_1(object sender, EventArgs e) { }
        private void Resultado_TextChanged(object sender, EventArgs e) { }
        private void Igual_Button_Click(object sender, EventArgs e)
        {
            entrada = Ingreso.Text;
            OutPut.Text = leerInputValido();
            Ingreso.Text = entrada;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private static string leerInputValido()

        {

            entrada = Regex.Replace(entrada, @"(\d+)\.$", "$1");

            // Input vacío es 0
            if (string.IsNullOrEmpty(entrada))
            {

                return "0";
            }

            // Recorremos la entrada en busca de validaciones
            int openParentheses = 0;
            int closeParentheses = 0;
            for (int i = 0; i < entrada.Length - 1; i++)
            {
                // Conteo de paréntesis

                if (entrada[i] == '(')
                {
                    openParentheses++;
                }
                else if (entrada[i] == ')')
                {
                    closeParentheses++;
                }

                // Operadores consecutivos. Ej: +/
                if ("+-*/".Contains(entrada[i]) && "+-*/)".Contains(entrada[i + 1]))
                {
                    return "Syntax error";

                }

                // Paréntesis vacíos. Ej: ()
                if (entrada[i] == '(' && entrada[i + 1] == ')')
                {
                    return "Syntax error";
                }

                // Agregar símbolo '*' antes o después de paréntesis. Ej: 2(3+1)5 -> 2*(3+1)*5
                if (char.IsDigit(entrada[i]) && entrada[i + 1] == '(' || entrada[i] == ')' && char.IsDigit(entrada[i + 1]))
                {
                    entrada = entrada.Insert(i + 1, "*");
                    //Console.WriteLine("Añadido/s símbolo/s *");
                }

                // Puntos decimales consecutivos. Ej: 12,,3
                if (entrada[i] == ',' && entrada[i + 1] == ',')
                {
                    return "Syntax error";
                }
            }

            // Paridad de paréntesis
            if (openParentheses < closeParentheses) //Ej: 3+(2*4))
            {

                return "Syntax error";
            }
            else
            {
                if (openParentheses > closeParentheses) //Ej: 6*(2+3
                {
                    for (int i = 0; i < (openParentheses - closeParentheses); i++)
                        entrada = entrada + ")";
                }
            }

            // Input con operador como caracter final
            if (entrada.EndsWith("+") || entrada.EndsWith("-") || entrada.EndsWith("*") || entrada.EndsWith("/"))
            {
                return "Syntax error";
            }

            // Separamos los números del entrada
            string[] numbers = entrada.Split(new char[] { '+', '-', '*', '/', '(', ')' });

            // TODO: REVISAR QUE LOS NUMEROS NO EMPIECEN CON '*', '/' -> "Syntax error"
            if (entrada.StartsWith("*") || entrada.StartsWith("/"))
            {
                return "Syntax error";
            }

            // TODO: ELIMINAR + INICIAL. Ej: +4.5 -> 4.5
            if (entrada.StartsWith("+"))
            {
                entrada = entrada.Substring(1);
            }

            // TODO: CONSIDERAR NUMEROS NEGATIVOS COMO VÁLIDOS



            // Más de un punto decimal. Ej: 2,41,3
            foreach (string number in numbers)
            {
                int decimalPoints = 0;
                foreach (char c in number)
                {
                    if (c == ',')
                    {
                        decimalPoints++;
                    }
                    if (decimalPoints > 1)
                    {
                        return "Syntax error";
                    }

                    // Revisar que los números no terminen en ','
                    if (number.EndsWith(","))
                    {
                        return "Syntax error";
                        // TODO: ELIMINAR PUNTO FINAL DE NÚMEROS DECIMALES. Ej.: 4. -> 4
                    }
                }
            }

            //TODO CORRECTO
            return Calcular();

        }

        static string Calcular()
        {
            // Eliminamos espacios y reemplazamos comas con puntos
            string input = entrada.Replace(" ", "").Replace(",", ".");

            // Creamos una pila para contener los números y operadores
            Stack<decimal> numeros = new Stack<decimal>();
            Stack<char> operaciones = new Stack<char>();

            // Recorremos la cadena de entrada
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsDigit(c) || c == '.')
                {
                    // Analizamos el número y los introducimos en la pila
                    int j = i;
                    while (j < input.Length && (char.IsDigit(input[j]) || input[j] == '.'))
                    {
                        j++;
                    }
                    string numString = input.Substring(i, j - i);
                    decimal numero;
                    if (decimal.TryParse(numString, NumberStyles.Float, CultureInfo.InvariantCulture, out numero))
                    {
                        numeros.Push(numero);
                    }
                    else
                    {
                        return "Syntax error";
                    }
                    i = j - 1;
                }
                else if (c == '(')
                {
                    // Empuja el paréntesis de apertura en la pila del operador
                    operaciones.Push(c);
                }
                else if (c == ')')
                {
                    // Evaluamos la expresión dentro del paréntesis
                    while (operaciones.Peek() != '(')
                    {
                        decimal b = numeros.Pop();
                        decimal a = numeros.Pop();
                        char op = operaciones.Pop();
                        decimal resultado = Evaluate(a, b, op);
                        numeros.Push(resultado);
                    }
                    operaciones.Pop(); // Pop en el paréntesis de apertura
                }
                else if ("+-*/".Contains(c))
                {
                    // Evaluamos operadores de mayor prioridad en la pila
                    while (operaciones.Count > 0 && Precedence(operaciones.Peek()) >= Precedence(c))
                    {
                        decimal b = numeros.Pop();
                        decimal a = numeros.Pop();
                        char op = operaciones.Pop();
                        decimal resultado = Evaluate(a, b, op);
                        numeros.Push(resultado);
                    }
                    // Empuja el operador actual sobre la pila
                    operaciones.Push(c);
                }
            }

            // Evaluamos los operadores restantes en la pila
            while (operaciones.Count > 0)
            {
                decimal b = numeros.Pop();
                decimal a = numeros.Pop();
                char op = operaciones.Pop();
                decimal resultado = Evaluate(a, b, op);
                numeros.Push(resultado);
            }

            // Comprobamos la división por cero
            if (numeros.Count == 1 && operaciones.Count == 0)
            {
                decimal resultado = numeros.Pop();
                if (resultado == 0)
                {
                    return "Math error";
                }
                else
                {
                    // Devolvemos el resultado como una cadena con 4 decimales
                    return resultado.ToString("N4");
                }
            }
            else
            {
                return "Syntax error";
            }
        }
        static int Precedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }

        static decimal Evaluate(decimal a, decimal b, char op)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return a / b;
                    }
                default:
                    throw new ArgumentException("Invalid operator: " + op);
            }
        }
    }
}