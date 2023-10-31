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

            // Input no vacío
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
            //REVISAR QUE NO EMPIECE CON */, ELIMINAR + INICIAL

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
            // Remove spaces and replace commas with dots
            string input = entrada.Replace(" ", "").Replace(",", ".");

            // Create a stack to hold the numbers and operators
            Stack<decimal> numbers = new Stack<decimal>();
            Stack<char> operators = new Stack<char>();

            // Loop through the input string
            // Loop through the input string
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsDigit(c) || c == '.')
                {
                    // Parse the number and push it onto the stack
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
                    // Push the opening parenthesis onto the operator stack
                    operators.Push(c);
                }
                else if (c == ')')
                {
                    // Evaluate the expression inside the parentheses
                    while (operators.Peek() != '(')
                    {
                        decimal b = numbers.Pop();
                        decimal a = numbers.Pop();
                        char op = operators.Pop();
                        decimal result = Evaluate(a, b, op);
                        numbers.Push(result);
                    }
                    operators.Pop(); // Pop the opening parenthesis
                }
                else if ("+-*/".Contains(c))
                {
                    // Evaluate higher-precedence operators on the stack
                    while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(c))
                    {
                        decimal b = numbers.Pop();
                        decimal a = numbers.Pop();
                        char op = operators.Pop();
                        decimal result = Evaluate(a, b, op);
                        numbers.Push(result);
                    }
                    // Push the current operator onto the stack
                    operators.Push(c);
                }
            }

            // Evaluate any remaining operators on the stack
            while (operators.Count > 0)
            {
                decimal b = numbers.Pop();
                decimal a = numbers.Pop();
                char op = operators.Pop();
                decimal result = Evaluate(a, b, op);
                numbers.Push(result);
            }

            // Check for division by zero
            if (numbers.Count == 1 && operators.Count == 0)
            {
                decimal result = numbers.Pop();
                if (result == 0)
                {
                    return "Math error";
                }
                else
                {
                    // Return the result as a string with 4 decimal places
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
    }
}