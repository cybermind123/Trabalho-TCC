using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes.Base;

namespace WindowsFormsApp1.Classes.Estoque
{
    class EstoqueDatabase
    {
        public int Salvar(EstoqueDTO dto)
        {
            string script = @"INSERT INTO tb_Estoque (nm_Produto, ds_Quantidade, tb_Fornecedor_id_Fornecedor) 
                                     VALUES (@nm_Produto, @ds_Quantidade, @tb_Fornecedor_id_Fornecedor)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_Produto", dto.Produto));
            parms.Add(new MySqlParameter("ds_Quantidade", dto.Quantidade));
            parms.Add(new MySqlParameter("tb_Fornecedor_id_Fornecedor", dto.Fornecedor));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public List<EstoqueDTO> Listar()
        {
            string script = @"SELECT * FROM tb_Estoque";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<EstoqueDTO> lista = new List<EstoqueDTO>();
            while (reader.Read())
            {
                EstoqueDTO dto = new EstoqueDTO();
                dto.id = reader.GetInt32("id_Estoque");
                dto.Produto = reader.GetString("nm_Produto");
                dto.Quantidade = reader.GetInt32("ds_Quantidade");
                dto.Fornecedor = reader.GetInt32("tb_Fornecedor_id_Fornecedor");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_Estoque WHERE id_Estoque = @id_Estoque";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_Estoque", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
    }
}
