using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Program.Pagamento
{
    class PagamentoBusiness
    {
        public int Salvar(PagamentoDTO dto)
        {
            PagamentoDatabase db = new PagamentoDatabase();
            return db.Salvar(dto);
        }

        public void Remover(int id)
        {
            PagamentoDatabase db = new PagamentoDatabase();
            db.Remover(id);
        }
        
        public List<PagamentoDTO> Listar()
        {
            PagamentoDatabase db = new PagamentoDatabase();
            return db.Listar();
        }
    }
}
