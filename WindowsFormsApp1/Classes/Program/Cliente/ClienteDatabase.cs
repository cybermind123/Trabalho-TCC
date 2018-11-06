using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes.Base;

namespace WindowsFormsApp1.Classes.Cliente
{
    class ClienteDatabase
    {
        public int Salvar(ClienteDTO dto)
        {
            string script = @"INSERT INTO tb_Cliente (nm_NomeCliente, ds_CPF, ds_Sexo, ds_Email, ds_Telefone) 
                                     VALUES (@nm_NomeCliente, @ds_CPF, @ds_Sexo, @ds_Email, @ds_Telefone)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_NomeCliente", dto.Nome));
            parms.Add(new MySqlParameter("ds_CPF", dto.CPF));
            parms.Add(new MySqlParameter("ds_Sexo", dto.Sexo));
            parms.Add(new MySqlParameter("ds_Email", dto.Email));
            parms.Add(new MySqlParameter("ds_Telefone", dto.Telefone));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public List<ClienteDTO> Listar()
        {
            string script = @"SELECT * FROM tb_Cliente";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<ClienteDTO> lista = new List<ClienteDTO>();
            while (reader.Read())
            {
                ClienteDTO dto = new ClienteDTO();
                dto.id = reader.GetInt32("id_Cliente");
                dto.Nome = reader.GetString("nm_NomeCliente");
                dto.CPF = reader.GetInt32("ds_CPF");
                dto.Email = reader.GetString("ds_Email");
                dto.Telefone = reader.GetInt32("ds_Telefone");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_Cliente WHERE id_Cliente = @id_Cliente";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_Cliente", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
    }
}

