using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes.Funcionario;
using WindowsFormsApp1.Classes.Program.UserSession;

namespace WindowsFormsApp1
{
    public partial class frmCadastroFuncionario : Form
    {
        public frmCadastroFuncionario()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                FuncionarioDTO Funcionario = new FuncionarioDTO();
                Funcionario.Nome = textBox1.Text;
                Funcionario.Login = textBox2.Text;
                Funcionario.Senha = textBox3.Text;
                Funcionario.PermissaoADM = false;
                Funcionario.PermissaoEvento = true;
                Funcionario.PermissaoRelatorio = true;

                FuncionarioBusiness business = new FuncionarioBusiness();
               int a=  business.Salvar(Funcionario);

                MessageBox.Show("Funcionario Salvo com sucesso.", "Best Moments",
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

        private void button2_Click(object sender, EventArgs e)
        {
            frmFolhaPagamento tela = new frmFolhaPagamento();
            tela.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmFolhaPagamento tela = new frmFolhaPagamento();
            tela.Show();
            this.Hide();
        }
    }
}
