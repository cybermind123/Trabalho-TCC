using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Fornecedor
{
    class FornecedorBusiness
    {
        public int Salvar(FornecedorDTO dto)
        {
            if (dto.Nome == string.Empty)
            {
                throw new ArgumentException("Nome é obrigatório.");
            }

            FornecedorDatabase db = new FornecedorDatabase();
            return db.Salvar(dto);
        }
        public void Remover(int id)
        {
            FornecedorDatabase db = new FornecedorDatabase();
            db.Remover(id);
        }
        public List<FornecedorDTO> Listar()
        {
            FornecedorDatabase db = new FornecedorDatabase();
            return db.Listar();
        }

        public int Alterar(FornecedorDTO dto)
        {
            FornecedorDatabase db = new FornecedorDatabase();
            return db.Alterar(dto);
        }
        public FornecedorDTO ListarPorId(int idFornecedor)
        {
            FornecedorDatabase db = new FornecedorDatabase();
            return db.ListarPorId(idFornecedor);
        }

    }
}
