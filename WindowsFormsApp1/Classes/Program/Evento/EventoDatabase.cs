using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes.Base;

namespace WindowsFormsApp1.Classes.Evento
{
    class EventoDatabase
    {
        public int Salvar(EventoDTO dto)
        {
            string script = @"INSERT INTO tb_Evento (nm_NomeEvento, nm_Local, dt_Data, dt_Horario, vl_Preco, ds_Descricao, ds_Quantidade, tb_Estoque_id_Estoque, tb_Funcionario_id_Funcionario, tb_Cliente_id_Cliente) 
                                     VALUES (@nm_NomeEvento, @nm_Local, @dt_Data, @dt_Horario, @vl_Preco, @ds_Descricao, @ds_Quantidade, @tb_Estoque_id_Estoque, @tb_Funcionario_id_Funcionario, @tb_Cliente_id_Cliente)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_NomeEvento", dto.Nome));
            parms.Add(new MySqlParameter("nm_Local", dto.Local));
            parms.Add(new MySqlParameter("dt_Data", dto.Data));
            parms.Add(new MySqlParameter("dt_Horario", dto.Horario));
            parms.Add(new MySqlParameter("vl_Preco", dto.Valor));
            parms.Add(new MySqlParameter("ds_Descricao", dto.Descricao));
            parms.Add(new MySqlParameter("ds_Quantidade", dto.Quantidade));
            parms.Add(new MySqlParameter("tb_Estoque_id_Estoque", dto.Estoque));
            parms.Add(new MySqlParameter("tb_Funcionario_id_Funcionario", dto.Funcionario));
            parms.Add(new MySqlParameter("tb_Cliente_id_Cliente", dto.Cliente));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public List<EventoDTO> Listar()
        {
            string script = @"SELECT * FROM tb_Evento";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<EventoDTO> lista = new List<EventoDTO>();
            while (reader.Read())
            {
                EventoDTO dto = new EventoDTO();
                dto.id = reader.GetInt32("id_Evento");
                dto.Nome = reader.GetString("nm_NomeEvento");
                dto.Local = reader.GetString("nm_Local");
                dto.Data = reader.GetDateTime("dt_Data");
                dto.Horario = reader.GetString("dt_Horário");
                dto.Valor = reader.GetDecimal("vl_Preco");
                dto.Descricao = reader.GetString("ds_Descricao");
                dto.Quantidade = reader.GetInt32("ds_Quantidade");
                dto.Estoque = reader.GetInt32("tb_Estoque_id_Estoque");
                dto.Funcionario = reader.GetInt32("tb_Funcionario_id_Funcionario");
                dto.Cliente = reader.GetInt32("tb_Cliente_id_Cliente");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }
    }
}
