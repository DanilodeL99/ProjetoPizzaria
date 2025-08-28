using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPizzaria
{
    public partial class Pedido : Form
    {
        //INSTANCIANDO A CLASSE DE CONEXÂO
        Conexao con = new Conexao();
        public Pedido()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

        }

        private void Pedido_Load(object sender, EventArgs e)
        {
            cmbTamanhoPizza.Items.Add("Pequena- R$ 20,00");
            cmbTamanhoPizza.Items.Add("Média- R$ 30,00");
            cmbTamanhoPizza.Items.Add("Grande- R$ 50,00");
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //DECLARANDO AS VARIAVEIS
            double valorPizza = 0;
            double valorOpcao = 0;
            double valorTotal = 0;

            if (cmbTamanhoPizza.SelectedIndex == 0)
            {
                valorPizza = 20;   
            }
            else if (cmbTamanhoPizza.SelectedIndex == 1)
            {
                valorPizza = 30;
            }
            else if (cmbTamanhoPizza.SelectedIndex == 2)
            {
                valorPizza = 50;
            }
            if(chkBorda.Checked == true)
            {
                valorOpcao = valorOpcao + 5;
            }
            if (chkTempero.Checked == true)
            {
                valorOpcao = valorOpcao + 6;
            }
            if (chkCebola.Checked == true)
            {
                valorOpcao = valorOpcao + 3;
            }
            if (chkCatupiry.Checked == true)
            {
                valorOpcao = valorOpcao + 4;
            }
            else
            {

            }
            valorTotal = valorPizza + valorOpcao;
            txtValorPizza.Text = Convert.ToString(valorPizza);
            txtValorOpcionais.Text = Convert.ToString(valorOpcao);
            txtValorPagar.Text = Convert.ToString(valorTotal);
        }
    }
}
