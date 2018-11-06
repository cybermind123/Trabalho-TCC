using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes.Fornecedor;

namespace WindowsFormsApp1
{
    public partial class frmCadastroFornecedor : Form
    {
        public frmCadastroFornecedor()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                FornecedorDTO Fornecedor = new FornecedorDTO();
                Fornecedor.Nome = textBox1.Text;
                Fornecedor.Produto = textBox2.Text;
                Fornecedor.Telefone = Convert.ToInt32(textBox3.Text);
                Fornecedor.Email = textBox5.Text;
                Fornecedor.Descricao = textBox4.Text;

                FornecedorBusiness business = new FornecedorBusiness();
                business.Salvar(Fornecedor);

                MessageBox.Show("Fornecedor Salvo com sucesso.", "Best Moments",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmFolhaPagamento tela = new frmFolhaPagamento();
                tela.Show();
                this.Hide();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Best Moments",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFolhaPagamento tela = new frmFolhaPagamento();
            tela.Show();
            this.Hide();
        }
    }
}
