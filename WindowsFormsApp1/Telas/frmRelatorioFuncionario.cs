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

namespace WindowsFormsApp1.Telas
{
    public partial class frmRelatorioFuncionario : Form
    {
        public frmRelatorioFuncionario()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                FuncionarioBusiness business = new FuncionarioBusiness();
                List<FuncionarioDTO> lista = business.Listar();

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = lista;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Best Moments",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApp1.frmFolhaPagamento tela = new WindowsFormsApp1.frmFolhaPagamento();
            tela.Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FuncionarioDTO funcionario = dataGridView1.CurrentRow.DataBoundItem as FuncionarioDTO;
            FuncionarioBusiness business = new FuncionarioBusiness();
            business.Remover(funcionario.id);

            MessageBox.Show("Funcionário Removido");
            Listar();
        }
        private void Listar()
        {
            FuncionarioBusiness business = new FuncionarioBusiness();
            List<FuncionarioDTO> lista = business.Listar();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }
    }
}
