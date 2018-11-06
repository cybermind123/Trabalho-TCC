using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Estoque
{
    class EstoqueBusiness
    {
        public int Salvar(EstoqueDTO dto)
        {
            if (dto.Produto == string.Empty)
            {
                throw new ArgumentException("Nome é obrigatório.");
            }
            
            EstoqueDatabase db = new EstoqueDatabase();
            return db.Salvar(dto);
        }

        public void Remover(int id)
        {
            EstoqueDatabase db = new EstoqueDatabase();
            db.Remover(id);
        }


        public List<EstoqueDTO> Listar()
        {
            EstoqueDatabase db = new EstoqueDatabase();
            return db.Listar();
        }
    }
}
