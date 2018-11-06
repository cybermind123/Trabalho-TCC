using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Funcionario
{
    class FuncionarioDTO
    {
        public int id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public bool PermissaoADM { get; set; }

        public bool PermissaoEvento { get; set; }

        public bool PermissaoRelatorio { get; set; }
    }
}
