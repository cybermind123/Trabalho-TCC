using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes.Estoque;

namespace WindowsFormsApp1.Telas
{
    public partial class frmCadastroEstoque : Form
    {
        public frmCadastroEstoque()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowsFormsApp1.frmFolhaPagamento tela = new WindowsFormsApp1.frmFolhaPagamento();
            tela.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                EstoqueDTO Evento = new EstoqueDTO();
                Evento.Produto = textBox1.Text;
                Evento.Quantidade = Convert.ToInt32(numericUpDown1.Value);
                Evento.Fornecedor = Convert.ToInt32(comboBox1.SelectedItem);

                EstoqueBusiness business = new EstoqueBusiness();
                business.Salvar(Evento);

                MessageBox.Show("Pedido Salvo com sucesso.", "Best Moments",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                WindowsFormsApp1.frmFolhaPagamento tela = new WindowsFormsApp1.frmFolhaPagamento();
                tela.Show();
                this.Hide();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Best Moments",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
