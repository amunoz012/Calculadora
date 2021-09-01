using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        Double resultadoFinal = 0;
        String operacion;
        String Num2;
        bool operacionEs = false;
        bool operacionX = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Codigo para la los botones numerales y "."
        private void button24_Click(object sender, EventArgs e)
        {
            if ((Result.Text == "0") || operacionEs || operacionX) 
            {
                Result.Clear();
            }
            operacionEs = false;
            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if (!Result.Text.Contains("."))
                    Result.Text = Result.Text + button.Text;
                    operacionX = false;
            }
            else
            Result.Text = Result.Text + button.Text;
            operacionX = false;
        }

        //Codigo para los operadores (+,-...).
        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(resultadoFinal != 0)
            {
                button20.PerformClick();
                operacion = button.Text;
                operacionActual.Text = resultadoFinal + " " + operacion;
                operacionEs = true;
            }
            else
            operacion = button.Text;
            resultadoFinal= Double.Parse(Result.Text);
            operacionActual.Text = resultadoFinal + " " + operacion;
            operacionEs = true;
        }

        //CE
        private void button5_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
        }

        //C
        private void button10_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
            resultadoFinal = 0;
            operacionActual.Text = " ";
        }

        //Calculando el resultado
        private void button20_Click(object sender, EventArgs e)
        {
            switch (operacion)
            {
                case "+":
                    Num2 = Result.Text;
                    Result.Text = (resultadoFinal + Double.Parse(Result.Text)).ToString();
                    break;

                case "-":
                    Num2 = Result.Text;
                    Result.Text = (resultadoFinal - Double.Parse(Result.Text)).ToString();
                    break;

                case "*":
                    Num2 = Result.Text;
                    Result.Text = (resultadoFinal * Double.Parse(Result.Text)).ToString();
                    break;

                case "/":
                    Num2 = Result.Text;
                    Result.Text = (resultadoFinal / Double.Parse(Result.Text)).ToString();
                    break;

                default:
                    break;
            }
            operacionActual.Text = resultadoFinal.ToString() + " " + operacion + " " + Num2 + " = ";
            resultadoFinal = Double.Parse(Result.Text); 
            operacionX = true;
        }
    }
}
