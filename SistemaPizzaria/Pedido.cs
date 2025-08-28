using MySql.Data.MySqlClient;
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

        private void grpOpcionais_Enter(object sender, EventArgs e)
        {
            cmbTamanhoPizza.SelectedIndex = -1;
            txtValorPizza.Clear();
            txtValorPagar.Clear();
            txtValorOpcionais.Clear();
            chkBorda.Checked = false;
            chkCatupiry.Checked = false;
            chkCebola.Checked = false;
            chkTempero.Checked = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //VERIFICAR OS CAMPOS
            if (txtValorPizza.Text == "")
            {
                MessageBox.Show("Campos Obrigatório");
                txtValorPizza.Focus();
            }
            else if(txtValorOpcionais.Text == "")
            {
                MessageBox.Show("Campos Obrigatório");
                txtValorOpcionais.Focus();
            }
            else if (txtValorPagar.Text == "")
            {
                MessageBox.Show("Campos Obrigatório");
                txtValorPagar.Focus();
            }
            else
            {
                //TRATAMENTO DE ERROS
                try
                {
                    //INSERINDO DADOS NO BANCO DE DADOS
                    string sql = "insert into tbPedido(tipoPizza,valorPizza,valorOpcao,valorTotal) values(@pizza,@vpizza,@vopcao,@total)";
                    MySqlCommand cmd = new MySqlCommand(sql, con.ConnectarBD());
                    cmd.Parameters.Add("@pizza", MySqlDbType.Text).Value = cmbTamanhoPizza.Text;
                    cmd.Parameters.Add("@vpizza", MySqlDbType.Text).Value = txtValorPizza.Text;
                    cmd.Parameters.Add("@vopcao", MySqlDbType.Text).Value = txtValorOpcionais.Text;
                    cmd.Parameters.Add("@total", MySqlDbType.Text).Value = txtValorPagar.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados cadastrados com Sucesso !!!");
                    cmbTamanhoPizza.Text = "";
                    txtValorPizza.Text = "";
                    txtValorOpcionais.Text = "";
                    txtValorPagar.Text = "";
                    cmbTamanhoPizza.Focus();
                    con.DesConnectarBD();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }
    }
}
