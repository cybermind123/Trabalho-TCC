using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Program.Pagamento
{
    class PagamentoDTO
    {
        public int id { get; set; }

        public double SalarioBruto { get; set; }

        public int DiasTrabMes { get; set; }

        public int NumeroDiasMes { get; set; }

        public int HorasTrab50 { get; set; }

        public int HorasTrab100 { get; set; }
    }
}
