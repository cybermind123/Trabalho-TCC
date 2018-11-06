using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes.Base;

namespace WindowsFormsApp1.Classes.Funcionario
{
    class FuncionarioDatabase
    {
        public int Salvar(FuncionarioDTO dto)
        {
            string script = @"INSERT INTO tb_Funcionario (nm_NomeFuncionario, nm_LoginFuncionario, nm_Senha, bt_Permissao_ADM, bt_Permissao_Evento, bt_Permissao_Relatorio) 
                                     VALUES (@nm_NomeFuncionario, @nm_LoginFuncionario, @nm_Senha, @bt_Permissao_ADM, @bt_Permissao_Evento, @bt_Permissao_Relatorio)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_NomeFuncionario", dto.Nome));
            parms.Add(new MySqlParameter("nm_LoginFuncionario", dto.Login));
            parms.Add(new MySqlParameter("nm_Senha", dto.Senha));
            parms.Add(new MySqlParameter("bt_Permissao_ADM", dto.PermissaoADM));
            parms.Add(new MySqlParameter("bt_Permissao_Evento", dto.PermissaoEvento));
            parms.Add(new MySqlParameter("bt_Permissao_Relatorio", dto.PermissaoRelatorio));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public List<FuncionarioDTO> Listar()
        {
            string script = @"SELECT * FROM tb_Funcionario";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FuncionarioDTO> lista = new List<FuncionarioDTO>();
            while (reader.Read())
            {
                FuncionarioDTO dto = new FuncionarioDTO();
                dto.id = reader.GetInt32("id_Funcionario");
                dto.Nome = reader.GetString("nm_NomeFuncionario");
                dto.Login = reader.GetString("nm_LoginFuncionario");
                dto.Senha = reader.GetString("nm_Senha");
                dto.PermissaoADM = reader.GetBoolean("bt_Permissao_ADM");
                dto.PermissaoEvento = reader.GetBoolean("bt_Permissao_Evento");
                dto.PermissaoRelatorio = reader.GetBoolean("bt_Permissao_Relatorio");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_Funcionario WHERE id_Funcionario = @id_Funcionario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_Funcionario", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public FuncionarioDTO Logar(string login, string senha)
        {
            string script = @"SELECT * FROM tb_Funcionario WHERE nm_LoginFuncionario = @nm_LoginFuncionario AND nm_senha = @nm_senha";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_LoginFuncionario", login));
            parms.Add(new MySqlParameter("nm_senha", senha));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            FuncionarioDTO funcionario = null;

            if (reader.Read())
            {
                funcionario = new FuncionarioDTO();
                funcionario.id = reader.GetInt32("id_Funcionario");
                funcionario.Nome = reader.GetString("nm_NomeFuncionario");
                funcionario.Login = reader.GetString("nm_LoginFuncionario");
                funcionario.Senha = reader.GetString("nm_Senha");
                funcionario.PermissaoADM = reader.GetBoolean("bt_Permissao_ADM");
                funcionario.PermissaoEvento = reader.GetBoolean("bt_Permissao_Evento");
                funcionario.PermissaoRelatorio = reader.GetBoolean("bt_Permissao_Relatorio");
            }
            reader.Close();

            return funcionario;
        }
    }
}
