using Microsoft.VisualBasic.Logging;
using System.Globalization;

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

            // Input no vac�o
            if (string.IsNullOrEmpty(entrada))
            {

                return "0";
            }

            // Cambiar comas por puntos
            //entrada = entrada.Replace(",", ".");

            // Recorremos la entrada en busca de validaciones
            int openParentheses = 0;
            int closeParentheses = 0;
            for (int i = 0; i < entrada.Length - 1; i++)
            {
                // Conteo de par�ntesis

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

                // Par�ntesis vac�os. Ej: ()
                if (entrada[i] == '(' && entrada[i + 1] == ')')
                {
                    return "Syntax error";
                }

                // Agregar s�mbolo '*' antes o despu�s de par�ntesis. Ej: 2(3+1)5 -> 2*(3+1)*5
                if (char.IsDigit(entrada[i]) && entrada[i + 1] == '(' || entrada[i] == ')' && char.IsDigit(entrada[i + 1]))
                {
                    entrada = entrada.Insert(i + 1, "*");
                    //Console.WriteLine("A�adido/s s�mbolo/s *");
                }

                // Puntos decimales consecutivos. Ej: 12,,3
                if (entrada[i] == ',' && entrada[i + 1] == ',')
                {
                    return "Syntax error";
                }
            }

            // Paridad de par�ntesis
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

            // Separamos los n�meros del entrada
            string[] numbers = entrada.Split(new char[] { '+', '-', '*', '/', '(', ')' });
            //REVISAR QUE NO EMPIECE CON */, ELIMINAR + INICIAL

            // M�s de un punto decimal. Ej: 2,41,3
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

                    // Revisar que los n�meros no terminen en ','
                    if (number.EndsWith(","))
                    {
                        return "Syntax error";
                        //REVISAR. Eliminar el punto.
                    }
                }
            }

            //TODO CORRECTO

            //return "Correcto";
            return Calculate();

        }

        static string Calculate()
        {
            // Eliminamos espacios y reemplazamos comas con puntos
            string input = entrada.Replace(" ", "").Replace(",", ".");

            // Creamos una pila para contener los n�meros y operadores
            Stack<decimal> numbers = new Stack<decimal>();
            Stack<char> operators = new Stack<char>();

            // Recorremos la cadena de entrada
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsDigit(c) || c == '.')
                {
                    // Analizamos el n�mero y los introducimos en la pila
                    int j = i;
                    while (j < input.Length && (char.IsDigit(input[j]) || input[j] == '.'))
                    {
                        j++;
                    }
                    string numberString = input.Substring(i, j - i);
                    decimal number;
                    if (decimal.TryParse(numberString, NumberStyles.Float, CultureInfo.InvariantCulture, out number))
                    {
                        numbers.Push(number);
                    }
                    else
                    {
                        return "Syntax error";
                    }
                    i = j - 1;
                }
                else if (c == '(')
                {
                    // Empuja el par�ntesis de apertura en la pila del operador
                    operators.Push(c);
                }
                else if (c == ')')
                {
                    // Evaluamos la expresi�n dentro del par�ntesis
                    while (operators.Peek() != '(')
                    {
                        decimal b = numbers.Pop();
                        decimal a = numbers.Pop();
                        char op = operators.Pop();
                        decimal result = Evaluate(a, b, op);
                        numbers.Push(result);
                    }
                    operators.Pop(); // Pop en el par�ntesis de apertura
                }
                else if ("+-*/".Contains(c))
                {
                    // Evaluamos operadores de mayor prioridad en la pila
                    while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(c))
                    {
                        decimal b = numbers.Pop();
                        decimal a = numbers.Pop();
                        char op = operators.Pop();
                        decimal result = Evaluate(a, b, op);
                        numbers.Push(result);
                    }
                    // Empuja el operador actual sobre la pila
                    operators.Push(c);
                }
            }

            // Evaluamos los operadores restantes en la pila
            while (operators.Count > 0)
            {
                decimal b = numbers.Pop();
                decimal a = numbers.Pop();
                char op = operators.Pop();
                decimal result = Evaluate(a, b, op);
                numbers.Push(result);
            }

            // Comprobamos la divisi�n por cero
            if (numbers.Count == 1 && operators.Count == 0)
            {
                decimal result = numbers.Pop();
                if (result == 0)
                {
                    return "Math error";
                }
                else
                {
                    // Devolvemos el resultado como una cadena con 4 decimales
                    return result.ToString("N4");
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
    }//Test cambios
}