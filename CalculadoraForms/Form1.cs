using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        int numero1;
        string ultimoOp;
        bool apertouOpera;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbTela.Clear();
            txbAux.Clear();
            numero1 = 0;
            apertouOpera= false;
        }
        private void Numero_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
        }
        private void Operador_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;

            if (txbTela.Text != "" && apertouOpera == false)
            {
                numero1 = int.Parse(txbTela.Text);
                txbTela.Clear();
                txbAux.Text = numero1.ToString() + botao.Text;
                ultimoOp = botao.Text;
                apertouOpera = true;
            }
            else if (txbTela.Text != "")
            {
                btnIgual.PerformClick();
                numero1 = int.Parse(txbTela.Text);
                txbAux.Text = numero1.ToString() + botao.Text;
                numero1 = int.Parse(txbTela.Text);
                txbTela.Text = "";
                ultimoOp = botao.Text;
                    
            }
            else
            {
                MessageBox.Show("ALGO ESTA ERRADO, POR FAVOR DIGITE O NUMERO DEPOIS O OPERADOR!");
            }

        }
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (txbTela.Text != "")
            {
                switch (ultimoOp)
                {
                    case "+":
                        apertouOpera = true;
                            txbAux.Clear();
                            txbTela.Text = (numero1 + int.Parse(txbTela.Text)).ToString();
                            numero1 = 0;
                        
                        break;

                    case "-":
                        apertouOpera= true;
                        txbAux.Clear();
                        txbTela.Text = (numero1 - int.Parse(txbTela.Text)).ToString();
                        numero1 = 0;
                        break;

                    case "X":
                        apertouOpera= true;
                        txbAux.Clear();
                        txbTela.Text = (numero1 * int.Parse(txbTela.Text)).ToString();
                        numero1 = 0;
                        break;

                    case "÷":
                        apertouOpera= true;
                        if (int.Parse(txbTela.Text) <= 0)
                        {
                            MessageBox.Show("Erro detectado");
                            txbTela.Clear();
                            txbAux.Clear();
                            numero1 = 0;
                        }
                        else
                        {
                            txbAux.Clear();
                            txbTela.Text = (numero1 / int.Parse(txbTela.Text)).ToString();
                            numero1 = 0;
                        }
                        break;
                }
            }
            else
            { 
                MessageBox.Show("OPÇÃO INVALIDA, TENTE NOVAMENTE!!!!"); 
            }
        }
    }
}
