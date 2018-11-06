using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes.Base;

namespace WindowsFormsApp1.Classes.Fornecedor
{
    class FornecedorDatabase
    {
        public int Salvar(FornecedorDTO dto)
        {
            string script = @"INSERT INTO tb_Fornecedor (nm_Fornecedor, nm_Produto, ds_Telefone, ds_Email, ds_Descricao) 
                                     VALUES (@nm_Fornecedor, @nm_Produto, @ds_Telefone, @ds_Email, @ds_Descricao)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_Fornecedor", dto.Nome));
            parms.Add(new MySqlParameter("nm_Produto", dto.Produto));
            parms.Add(new MySqlParameter("ds_Telefone", dto.Telefone));
            parms.Add(new MySqlParameter("ds_Email", dto.Email));
            parms.Add(new MySqlParameter("ds_Descricao", dto.Descricao));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public int Alterar(FornecedorDTO dto)
        {
            string script = @"UPDATE tb_Fornecedor SET nm_Fornecedor = @nm_Fornecedor,  
                                                          nm_Produto = @nm_Produto,
                                                         ds_Telefone = @ds_Telefone,
                                                            ds_Email = @ds_Email,
                                                        ds_Descricao = @ds_Descricao

                                                 WHERE id_Fornecedor = @id_Fornecedor";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_Fornecedor", dto.id));
            parms.Add(new MySqlParameter("nm_Fornecedor", dto.Nome));
            parms.Add(new MySqlParameter("nm_Produto", dto.Produto));
            parms.Add(new MySqlParameter("ds_Telefone", dto.Telefone));
            parms.Add(new MySqlParameter("ds_Email", dto.Email));
            parms.Add(new MySqlParameter("ds_Descricao", dto.Descricao));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public List<FornecedorDTO> Listar()
        {
            string script = @"SELECT * FROM tb_Fornecedor";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FornecedorDTO> lista = new List<FornecedorDTO>();
            while (reader.Read())
            {
                FornecedorDTO dto = new FornecedorDTO();
                dto.id = reader.GetInt32("id_Fornecedor");
                dto.Nome = reader.GetString("nm_Fornecedor");
                dto.Produto = reader.GetString("nm_Produto");
                dto.Telefone = reader.GetInt32("ds_Telefone");
                dto.Email = reader.GetString("ds_Email");
                dto.Descricao = reader.GetString("ds_Descricao");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public FornecedorDTO ListarPorId(int idFornecedor)
        {
            string script = @"SELECT * FROM tb_Fornecedor WHERE id_Fornecedor = @id_Fornecedor";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_Fornecedor", idFornecedor));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            FornecedorDTO dto = new FornecedorDTO();
            while (reader.Read())
            {
                dto.id = reader.GetInt32("id_Fornecedor");
                dto.Nome = reader.GetString("nm_Fornecedor");
                dto.Produto = reader.GetString("nm_Produto");
                dto.Telefone = reader.GetInt32("ds_Telefone");
                dto.Email = reader.GetString("ds_Email");
                dto.Descricao = reader.GetString("ds_Descricao");
            }

            reader.Close();
            return dto;
        }

        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_Fornecedor WHERE id_Fornecedor = @id_Fornecedor";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_Fornecedor", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
    }
}
