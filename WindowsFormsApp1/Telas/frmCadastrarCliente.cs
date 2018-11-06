using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes.Cliente;

namespace WindowsFormsApp1
{
    public partial class frmCadastrarCliente : Form
    {
        public frmCadastrarCliente()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteDTO Cliente = new ClienteDTO();
                Cliente.Nome = textBox1.Text;
                if (textBox2.Text != String.Empty)
                {
                    Cliente.CPF = Convert.ToInt32(textBox2.Text);
                }
                Cliente.Sexo = Convert.ToString(comboBox1.SelectedItem);
                Cliente.Email = textBox3.Text;
                Cliente.Telefone = Convert.ToInt32(textBox4.Text);

                ClienteBusiness business = new ClienteBusiness();
                business.Salvar(Cliente);

                MessageBox.Show("Cliente Salvo com sucesso.", "Best Moments",
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
