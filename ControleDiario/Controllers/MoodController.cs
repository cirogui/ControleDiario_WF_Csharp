using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDiario.Entities;

namespace ControleDiario.Controllers
{
    public class MoodController
    {
        public int InsertMood(Mood cadastro)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "INSERT INTO mood2 ([date], [feelings], [intensity], [note]) VALUES (@date, @feelings, @intinsity, @note)";
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = cadastro.Date;
                cn.Parameters.Add("feelings", SqlDbType.VarChar).Value = cadastro.Feelings;
                cn.Parameters.Add("intensity", SqlDbType.Int).Value = cadastro.Intensity;
                cn.Parameters.Add("note", SqlDbType.VarChar).Value = cadastro.Note;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }
    }
}
