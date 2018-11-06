using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Evento
{
    class EventoBusiness
    {
        public int Salvar(EventoDTO dto)
        {
            if (dto.Nome == string.Empty)
            {
                throw new ArgumentException("Nome é obrigatório.");
            }

            EventoDatabase db = new EventoDatabase();
            return db.Salvar(dto);
        }
        
        public List<EventoDTO> Listar()
        {
            EventoDatabase db = new EventoDatabase();
            return db.Listar();
        }
    }
}

