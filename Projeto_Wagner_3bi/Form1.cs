using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Wagner_3bi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        double ValorReajustado;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox5.Clear(); 
            float valorAPagar = float.Parse(textBox1.Text);
            int qtdParcelas = int.Parse(textBox2.Text);
            float parcelaParaPagamento = valorAPagar / qtdParcelas;
            double valorPorParcela = Math.Round(parcelaParaPagamento, 2);
            ValorReajustado = valorPorParcela;
            DateTime dataTeste;
            string dataPagemento = textBox3.Text;
            Boolean testarData = DateTime.TryParse(dataPagemento, out dataTeste);
            if (testarData == false)
                MessageBox.Show("A data não foi escrita corretamente");
            else
            {
                DateTime dataPorParcela = dataTeste;
                for (int i = 1; i <= qtdParcelas; i++)
                {
                    DateTime dataParaImprimir;
                    dataParaImprimir = dataPorParcela.AddDays(31);
                    dataPorParcela = dataParaImprimir;
                    int day = (int)dataPorParcela.DayOfWeek;
                    if (day == 0)
                    {
                        dataPorParcela = dataPorParcela.AddDays(1);
                    }
                    else if (day == 6)
                    {
                        dataPorParcela = dataPorParcela.AddDays(2);
                    }
                    textBox4.AppendText(i.ToString("0") + Environment.NewLine);
                    textBox5.AppendText(dataPorParcela.ToString("dd/MM/yyyy") + Environment.NewLine);
                    label7.Text = String.Format("{0:C2}", valorPorParcela);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int totalParcelas = int.Parse(textBox2.Text);
            int parcelaParaPagamento = int.Parse(textBox6.Text);
            string dataParaPagamento = textBox7.Text;
            DateTime data;
            Boolean testarData = DateTime.TryParse(dataParaPagamento, out data);
            if (testarData == false)
                MessageBox.Show("A data não foi escrita corretamente");
            else
            {
                for (int i = 0; i <= textBox5.Lines.Length - 1; i++)
                {
                    DateTime dataParaTeste;
                    string datas = textBox5.Lines[i];
                    Boolean testarData2 = DateTime.TryParse(datas, out dataParaTeste);
                    if (testarData2 == true)
                    {
                        int parcelaNaTextBox = int.Parse(textBox4.Lines[i]);
                        if (parcelaParaPagamento == parcelaNaTextBox)
                        {
                            if (data <= dataParaTeste)
                            {
                                textBox4.Clear();
                                textBox5.Clear();
                                MessageBox.Show("Pagamento feito com sucesso");
                                for (int y = parcelaParaPagamento + 1; y <= totalParcelas; y++)
                                {
                                    dataParaTeste = dataParaTeste.AddDays(31);
                                    int dia = (int)dataParaTeste.DayOfWeek;
                                    if (dia == 0)
                                    {
                                        dataParaTeste = dataParaTeste.AddDays(1);
                                    }
                                    else if (dia == 6)
                                    {
                                        dataParaTeste = dataParaTeste.AddDays(2);
                                    }
                                    textBox4.AppendText(y.ToString("0") + Environment.NewLine);
                                    textBox5.AppendText(dataParaTeste.ToString("dd/MM/yyyy") + Environment.NewLine);                                 
                                }
                                break;
                            } else if (data > dataParaTeste)
                            {
                                ValorReajustado = ValorReajustado + (ValorReajustado * 0.03);
                                label7.Text = String.Format("{0:C2}", ValorReajustado);
                                textBox4.Clear();
                                textBox5.Clear();
                                MessageBox.Show("Parcela em atraso!");
                                for (int y = parcelaParaPagamento + 1; y <= totalParcelas; y++)
                                {
                                    dataParaTeste = dataParaTeste.AddDays(31);
                                    int dia = (int)dataParaTeste.DayOfWeek;
                                    if (dia == 0)
                                    {
                                        dataParaTeste = dataParaTeste.AddDays(1);
                                    }
                                    else if (dia == 6)
                                    {
                                        dataParaTeste = dataParaTeste.AddDays(2);
                                    }
                                    textBox4.AppendText(y.ToString("0") + Environment.NewLine);
                                    textBox5.AppendText(dataParaTeste.ToString("dd/MM/yyyy") + Environment.NewLine);
                                }
                                break;
                            }
                        } else if (parcelaParaPagamento > parcelaNaTextBox || parcelaParaPagamento < parcelaNaTextBox)
                        {
                            MessageBox.Show("Não pode pagar parcela fora da sua data de vencimento");
                            break;
                        }
                    }
                }
            }
        }
    }
}
