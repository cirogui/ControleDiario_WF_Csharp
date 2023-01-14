using ControleDiario.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDiario.Controllers
{
    public class CadController
    {
        public int Insert(Control cadastro)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "INSERT INTO registros ([data],[tipo],[peso], [descricao]) VALUES ([@data], [@tipo], [@peso], [@descricao])";
                cn.Parameters.Add("data", SqlDbType.DateTime).Value = cadastro.Data;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }
    }
}
