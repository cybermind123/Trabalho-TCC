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

namespace WindowsFormsApp1.Telas
{
    public partial class frmRelatorioFornecedor : Form
    {
        public frmRelatorioFornecedor()
        {
            InitializeComponent();
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

        private void frmRelatorioFornecedor_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                FornecedorBusiness business = new FornecedorBusiness();
                List<FornecedorDTO> lista = business.Listar();

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = lista;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Best Moments",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FornecedorDTO Fornecedor = dataGridView1.CurrentRow.DataBoundItem as FornecedorDTO;
            FornecedorBusiness business = new FornecedorBusiness();
            business.Remover(Fornecedor.id);

            MessageBox.Show("Fornecidor Removido");
            Listar();
        }
        private void Listar()
        { 
    FornecedorBusiness business = new FornecedorBusiness();
    List<FornecedorDTO> lista = business.Listar();

    dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = lista;
        }
}
}
