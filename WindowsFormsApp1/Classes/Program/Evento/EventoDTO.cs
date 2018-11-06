using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Evento
{
    class EventoDTO
    {
        public int id { get; set; }

        public string Nome { get; set; }

        public string Local { get; set; }

        public DateTime Data { get; set; }

        public String Horario { get; set; }

        public decimal Valor { get; set; }
        
        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public int Estoque { get; set; }

        public int Funcionario { get; set; }

        public int Cliente { get; set; }
    }
}
