using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes.Evento;

namespace WindowsFormsApp1.Telas
{
    public partial class frmFolhaPagamento : Form
    {
        public frmFolhaPagamento()
        {
            InitializeComponent();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            double SalarioBruto = Convert.ToDouble(txtSalBruto.Text);
            int TotalDiasMes = Convert.ToInt32(txtDiasMes.Text);
            int DiasTrab = Convert.ToInt32(txtDiasTrab.Text);
            int Horas50 = Convert.ToInt32(txtHora50.Text);
            int Horas100 = Convert.ToInt32(txtHora100.Text);

            frmSalario tela = new frmSalario();
            tela.Show();
            this.Hide();

            tela.LoadScreen(SalarioBruto, DiasTrab, TotalDiasMes, Horas50, Horas100);
        }
    }
}
