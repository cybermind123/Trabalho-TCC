using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes.Base;

namespace WindowsFormsApp1.Classes.Program.Pagamento
{
    class PagamentoDatabase
    {
        public int Salvar(PagamentoDTO dto)
        {
            string script = @"INSERT INTO tb_Pagamento (sl_SalarioBruto, ds_DiasTrabMes, ds_NumeroDiasMes, ds_HorasTrab50, ds_HorasTrab100) 
                                     VALUES (@sl_SalarioBruto, @ds_DiasTrabMes, @ds_NumeroDiasMes, @ds_HorasTrab50, @ds_HorasTrab100)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("sl_SalarioBruto", dto.SalarioBruto));
            parms.Add(new MySqlParameter("ds_DiasTrabMes", dto.DiasTrabMes));
            parms.Add(new MySqlParameter("ds_NumeroDiasMes", dto.NumeroDiasMes));
            parms.Add(new MySqlParameter("ds_HorasTrab50", dto.HorasTrab50));
            parms.Add(new MySqlParameter("bt_HorasTrab100", dto.HorasTrab100));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public List<PagamentoDTO> Listar()
        {
            string script = @"SELECT * FROM tb_Pagamento";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<PagamentoDTO> lista = new List<PagamentoDTO>();
            while (reader.Read())
            {
                PagamentoDTO dto = new PagamentoDTO();
                dto.id = reader.GetInt32("id_Pagamento");
                dto.SalarioBruto = reader.GetDouble("sl_SalarioBruto");
                dto.DiasTrabMes = reader.GetInt32("ds_DiasTrabMes");
                dto.NumeroDiasMes = reader.GetInt32("ds_NumeroDiasMes");
                dto.HorasTrab50 = reader.GetInt32("ds_HorasTrab50");
                dto.HorasTrab100 = reader.GetInt32("bt_HorasTrab100");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_Pagamento WHERE id_Pagamento = @id_Pagamento";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_Pagamento", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
    }
}
