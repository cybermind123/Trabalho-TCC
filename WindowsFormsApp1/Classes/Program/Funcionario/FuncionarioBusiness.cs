using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Funcionario
{
    class FuncionarioBusiness
    {
        public FuncionarioDTO Logar(string login, string senha)
        {
            if (login == string.Empty)
            {
                throw new ArgumentException("Usuário é obrigatório.");
            }

            if (senha == string.Empty)
            {
                throw new ArgumentException("Senha é obrigatório.");
            }

            FuncionarioDatabase db = new FuncionarioDatabase();
            return db.Logar(login, senha);
        }

        public int Salvar(FuncionarioDTO dto)
        {
            if (dto.Nome == string.Empty)
            {
                throw new ArgumentException("Nome é obrigatório.");
            }

            if (dto.Login == string.Empty)
            {
                throw new ArgumentException("Username é obrigatório.");
            }

            if (dto.Senha == string.Empty)
            {
                throw new ArgumentException("Senha é obrigatória.");
            }
            

            FuncionarioDatabase db = new FuncionarioDatabase();
            return db.Salvar(dto);
        }

        public void Remover(int id)
        {
            FuncionarioDatabase db = new FuncionarioDatabase();
            db.Remover(id);
        }


        public List<FuncionarioDTO> Listar()
        {
            FuncionarioDatabase db = new FuncionarioDatabase();
            return db.Listar();
        }
    }
}
