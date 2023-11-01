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
            entrada = Regex.Replace(entrada, @"(\d+)\.$", "$1");

            if (string.IsNullOrEmpty(entrada))
            {
                return "0";
            }

            // Reconocer y convertir números negativos
            entrada = Regex.Replace(entrada, @"(?<=[^\d])-", "0-");

            // Validaciones
            if (entrada.StartsWith("*") || entrada.StartsWith("/") || entrada.EndsWith("+") || entrada.EndsWith("-") ||
                entrada.EndsWith("*") || entrada.EndsWith("/"))
            {
                return "Syntax error";
            }

            // Procesar paréntesis
            int openParentheses = entrada.Count(c => c == '(');
            int closeParentheses = entrada.Count(c => c == ')');

            if (openParentheses != closeParentheses)
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
            try
            {
                DataTable dt = new DataTable();
                var result = dt.Compute(entrada, "");
                return result.ToString();
            }
            catch (Exception)
            {
                return "Math error";
            }
        }
    }
}