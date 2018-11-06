using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Estoque
{
    class EstoqueDTO
    {
        public int id { get; set; }

        public string Produto { get; set; }

        public int Quantidade { get; set; }

        public int Fornecedor { get; set; }
    }
}
