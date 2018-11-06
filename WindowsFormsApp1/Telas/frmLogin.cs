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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtLogin.Text;
                string password = txtSenha.Text;

                FuncionarioBusiness business = new FuncionarioBusiness();
                FuncionarioDTO funcionario = business.Logar(username, password);

                if (funcionario != null)
                {
                    UserSession.UsuarioLogado = funcionario;

                    frmFolhaPagamento tela = new frmFolhaPagamento();
                    tela.Show();
                    this.Hide();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Best Moments",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicio tela = new frmInicio();
            tela.Show();
            this.Hide();
        }
    }
}
