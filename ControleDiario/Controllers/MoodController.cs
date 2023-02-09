using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDiario.Entities;
using ControleDiario.Models;
using ControleDiario.Views;
using Mood = ControleDiario.Entities.Mood;

namespace ControleDiario.Controllers
{
    public class MoodController
    {
        public int InsertMood(Mood cadastro2)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "INSERT INTO mood2 ([date], [feelings], [intensity], [note]) VALUES (@date, @feelings, @intensity, @note)";
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = cadastro2.Date;
                cn.Parameters.Add("feelings", SqlDbType.VarChar).Value = cadastro2.Feelings;
                cn.Parameters.Add("intensity", SqlDbType.Int).Value = cadastro2.Intensity;
                cn.Parameters.Add("note", SqlDbType.VarChar).Value = cadastro2.Note;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }
        public List<Mood> ToListMood(Mood cadastro2)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * from mood2 WHERE date = @date";
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = cadastro2.Date;
                cn.Connection = con;

                SqlDataReader dr;
                List<Mood> list2 = new List<Mood>();
                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Mood dado2 = new Mood();
                        dado2.Id = Convert.ToInt32(dr["id"]);
                        dado2.Date = Convert.ToDateTime(dr["date"]);
                        dado2.Feelings = Convert.ToString(dr["feelings"]);
                        dado2.Intensity = Convert.ToInt32(dr["intensity"]);
                        dado2.Note = Convert.ToString(dr["note"]);
                        list2.Add(dado2);
                    }

                }
                return list2;
            }

        }
        public int UpdateMood(Mood cadastro2)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "UPDATE mood2 SET date = @date, feelings = @feelings, intensity = @intensity, note = @note WHERE id = @id";
                cn.Parameters.Add("id", SqlDbType.Int).Value = cadastro2.Id;
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = cadastro2.Date;
                cn.Parameters.Add("feelings", SqlDbType.VarChar).Value = cadastro2.Feelings;
                cn.Parameters.Add("intensity", SqlDbType.Int).Value = cadastro2.Intensity;
                cn.Parameters.Add("note", SqlDbType.VarChar).Value = cadastro2.Note;


                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }
        public int DeleteMood(Mood cadastro2)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "DELETE from mood2 WHERE id = @id";
                cn.Parameters.Add("id", SqlDbType.Int).Value = cadastro2.Id;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }


    }
   
}
