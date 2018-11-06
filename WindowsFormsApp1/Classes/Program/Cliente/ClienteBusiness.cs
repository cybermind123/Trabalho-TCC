using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Cliente
{
    class ClienteBusiness
    {
        public int Salvar(ClienteDTO dto)
        {
            ClienteDatabase db = new ClienteDatabase();
            return db.Salvar(dto);
        }

        public void Remover(int id)
        {
            ClienteDatabase db = new ClienteDatabase();
            db.Remover(id);
        }


        public List<ClienteDTO> Listar()
        {
            ClienteDatabase db = new ClienteDatabase();
            return db.Listar();
        }
    }
}

