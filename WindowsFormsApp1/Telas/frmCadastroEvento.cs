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
using WindowsFormsApp1.Classes.Estoque;
using WindowsFormsApp1.Classes.Evento;
using WindowsFormsApp1.Classes.Funcionario;
using WindowsFormsApp1.Classes.Program.UserSession;

namespace WindowsFormsApp1
{
    public partial class frmCadastroEvento : Form
    {
        public frmCadastroEvento()
        {
            InitializeComponent();
            CarregarClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarClientes()
        {
            ClienteBusiness business = new ClienteBusiness();
            List<ClienteDTO> clientes = business.Listar();

            comboBox2.DisplayMember = nameof(ClienteDTO.Nome);
            comboBox2.ValueMember = nameof(ClienteDTO.id);
            comboBox2.DataSource = clientes;
        }

        private void CarregarEstoques()
        {
            EstoqueBusiness business = new EstoqueBusiness();
            List<EstoqueDTO> estoques = business.Listar();

            comboBox1.DisplayMember = nameof(EstoqueDTO.id);
            comboBox1.ValueMember = nameof(EstoqueDTO.id);
            comboBox1.DataSource = estoques;
        }

        private void CarregarFuncionarios()
        {
            FuncionarioBusiness business = new FuncionarioBusiness();
            List<FuncionarioDTO> funcionarios = business.Listar();

            comboBox1.DisplayMember = nameof(FuncionarioDTO.Nome);
            comboBox1.ValueMember = nameof(FuncionarioDTO.id);
            comboBox1.DataSource = funcionarios;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string evento = textBox1.Text;
                string Local = textBox2.Text;
                string Data = dateTimePicker1.Text;
                string Hora = txtHorario.Text;
                string valor = textBox5.Text;
                DateTime solic = DateTime.Now;

                EventoDTO Evento = new EventoDTO();
                Evento.Nome = textBox1.Text;
                Evento.Local = textBox2.Text;
                Evento.Data = Convert.ToDateTime(dateTimePicker1.Text);
                Evento.Horario = txtHorario.Text;
                Evento.Valor = Convert.ToDecimal(textBox5.Text);
                Evento.Descricao = textBox3.Text;
                Evento.Quantidade = Convert.ToInt32(numericUpDown1.Value);
                Evento.Estoque = Convert.ToInt32(comboBox1.SelectedItem);
                Evento.Cliente = Convert.ToInt32(comboBox2.SelectedItem);
                Evento.Funcionario = Convert.ToInt32(comboBox3.SelectedItem);

                EventoBusiness business = new EventoBusiness();
                business.Salvar(Evento);

                MessageBox.Show("Pedido Salvo com sucesso.", "Best Moments",
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
    }
}
