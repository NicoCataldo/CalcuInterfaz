using Microsoft.VisualBasic.Logging;
using System.Data;
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
            //Eliminar punto decimal al final del numero si existe ejemplo 4. -> 4
            entrada = Regex.Replace(entrada, @"(\d+)\.$", "$1");

            if (string.IsNullOrEmpty(entrada))
            {
                return "0";
            }

            //Verifica si empieza con un operador o termina
            if (entrada.StartsWith("*") || entrada.StartsWith("/") || entrada.EndsWith("+") || entrada.EndsWith("-") ||
                entrada.EndsWith("*") || entrada.EndsWith("/"))
            {
                return "Syntax error";
            }

            //Eliminar + inicial
            if (entrada.StartsWith("+"))
            {
                entrada = entrada.Substring(1);
            }

            // Validaciones
            for (int i = 0; i < entrada.Length; i++)
            {
                // Operadores consecutivos. Ej: +/
                if ("+-*/".Contains(entrada[i]) && "+-*/)".Contains(entrada[i + 1]))
                {
                    return "Syntax error";
                }
            }

            // Reconocer y convertir números negativos y valida si el - esta precedido por otro operador
            entrada = Regex.Replace(entrada, @"(?<!\d)-", "0-"); 
            //entrada = Regex.Replace(entrada, @"(?<=[^\d+\-*/])-(?=\d)", "0-"); 
            


            

            

            //coloca el multiplicador entre dos parentesis
            entrada = entrada.Replace(")(", ")*(");


            // Procesar paréntesis
            int openParentheses = entrada.Count(c => c == '(');
            int closeParentheses = entrada.Count(c => c == ')');

            if (openParentheses < closeParentheses)
            {
                return "Syntax error";
            }
            else
            {
                if (openParentheses > closeParentheses)
                {
                    for (int i = 0; i < (openParentheses - closeParentheses); i++)
                        entrada = entrada + ")";
                }
            }

            // Evaluar la expresión
            string resultado = EvaluarExpresion(entrada);

            return resultado;
        }
        private static string EvaluarExpresion(string expresion)
        {
            try
            {
                Stack<decimal> numeros = new Stack<decimal>();
                Stack<char> operadores = new Stack<char>();

                int i = 0;
                while (i < expresion.Length)
                {
                    char c = expresion[i];

                    if (char.IsDigit(c) || c == '-' && (i == 0 || expresion[i - 1] == '('))
                    {
                        int j = i;
                        while (j < expresion.Length && (char.IsDigit(expresion[j]) || expresion[j] == '.'))
                        {
                            j++;
                        }

                        string numeroStr = expresion.Substring(i, j - i);
                        decimal numero = decimal.Parse(numeroStr, CultureInfo.InvariantCulture);
                        numeros.Push(numero);
                        i = j;
                    }
                    else if (c == '+' || c == '-' || c == '*' || c == '/')
                    {
                        if (i == 0 || expresion[i - 1] == '(')
                        {
                            return "Syntax error"; // Operador incorrecto después de (
                        }
                        else if (i > 0 && (expresion[i - 1] == '+' || expresion[i - 1] == '-' || expresion[i - 1] == '*' || expresion[i - 1] == '/'))
                        {
                            return "Syntax error"; // Dos operadores juntos
                        }
                        while (operadores.Count > 0 && Precedencia(operadores.Peek()) >= Precedencia(c))
                        {
                            decimal b = numeros.Pop();
                            decimal a = numeros.Pop();
                            char operador = operadores.Pop();
                            decimal resultado = AplicarOperador(a, b, operador);
                            numeros.Push(resultado);
                        }
                        operadores.Push(c);
                        i++;
                    }
                    else if (c == '(')
                    {
                        operadores.Push(c);
                        i++;
                    }
                    else if (c == ')')
                    {
                        while (operadores.Count > 0 && operadores.Peek() != '(')
                        {
                            decimal b = numeros.Pop();
                            decimal a = numeros.Pop();
                            char operador = operadores.Pop();
                            decimal resultado = AplicarOperador(a, b, operador);
                            numeros.Push(resultado);
                        }
                        if (operadores.Count == 0 || operadores.Peek() != '(')
                        {
                            return "Syntax error"; // Falta el paréntesis de apertura correspondiente
                        }
                        operadores.Pop(); // Quitar el paréntesis de apertura
                        i++;
                    }
                    else if (char.IsWhiteSpace(c))
                    {
                        // Ignorar espacios en blanco
                        i++;
                    }
                    else
                    {
                        return "Syntax error";
                    }
                }

                while (operadores.Count > 0)
                {
                    decimal b = numeros.Pop();
                    decimal a = numeros.Pop();
                    char operador = operadores.Pop();
                    decimal resultado = AplicarOperador(a, b, operador);
                    numeros.Push(resultado);
                }

                if (numeros.Count == 1 && operadores.Count == 0)
                {
                    decimal resultado = numeros.Pop();
                    if (resultado % 1 == 0)
                    {
                        return resultado.ToString("N0"); // Mostrar como entero
                    }
                    else
                    {
                        return resultado.ToString("N2"); // Mostrar con un decimal
                    }
                }
                else
                {
                    return "Syntax error";
                }

            }
            catch (Exception)
            {
                return "Syntax error";
            }
        }

        private static int Precedencia(char operador)
        {
            switch (operador)
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

        private static decimal AplicarOperador(decimal a, decimal b, char operador)
        {
            switch (operador)
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
                        throw new DivideByZeroException("Math error");
                    }
                    return a / b;
                default:
                    throw new ArgumentException("Operador no válido: " + operador);
            }
        }

    }
}