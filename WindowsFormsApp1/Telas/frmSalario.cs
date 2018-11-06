using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes.Extras;

namespace WindowsFormsApp1.Telas
{
    public partial class frmSalario : Form
    {
        public frmSalario()
        {
            InitializeComponent();
        }

        public void LoadScreen(double SB, int DiasTrabMes, int TotalDiasMes, int Horas50, int Horas100)
        {
            SB = Convert.ToDouble(lblSalarioBruto.Text);
            DiasTrabMes = Convert.ToInt32(lblDiasTrab.Text);
            TotalDiasMes = Convert.ToInt32(lblDiasMes.Text);
            Horas50 = Convert.ToInt32(lblHorasTrab50.Text);
            Horas100 = Convert.ToInt32(lblHorasTrab100.Text);
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmFolhaPagamento tela = new frmFolhaPagamento();
            tela.Show();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

        }
    }
}
