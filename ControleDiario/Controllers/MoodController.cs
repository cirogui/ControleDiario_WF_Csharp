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

        public int CountMood(Mood cadastro2)
        {
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();


                cn.CommandText = "SELECT COUNT(*) FROM mood2 WHERE date = @date AND intensity = '3' AND feelings = 'Hope' OR feelings = 'Hapiness' OR feelings = 'Focus'";
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = cadastro2.Date;
                cn.Connection = con;

                int up3 = (Convert.ToInt32(cn.ExecuteScalar())) * 3;

                cn.CommandText = "SELECT COUNT(*) FROM mood2 WHERE date = @date AND intensity = '2' AND feelings = 'Hope' OR feelings = 'Hapiness' OR feelings = 'Focus'";
                cn.Connection = con;

                int up2 = (Convert.ToInt32(cn.ExecuteScalar())) * 2;

                cn.CommandText = "SELECT COUNT(*) FROM mood2 WHERE date = @date AND intensity = '1' AND feelings = 'Hope' OR feelings = 'Hapiness' OR feelings = 'Focus'";
                cn.Connection = con;

                int up1 = (Convert.ToInt32(cn.ExecuteScalar())) * 1;






                cn.CommandText = "SELECT COUNT(*) FROM mood2 WHERE date = @date AND intensity = '3' AND feelings = 'Anxiety' OR feelings = 'Sadness' OR feelings = 'Angry' OR feelings = 'Boredom'";
                cn.Connection = con;

                int down3 = (Convert.ToInt32(cn.ExecuteScalar())) * -3;


                cn.CommandText = "SELECT COUNT(*) FROM mood2 WHERE date = @date AND intensity = '2' AND feelings = 'Anxiety' OR feelings = 'Sadness' OR feelings = 'Angry' OR feelings = 'Boredom'";
                cn.Connection = con;

                int down2 = (Convert.ToInt32(cn.ExecuteScalar())) * -2;

                cn.CommandText = "SELECT COUNT(*) FROM mood2 WHERE date = @date AND intensity = '1' AND feelings = 'Anxiety' OR feelings = 'Sadness' OR feelings = 'Angry' OR feelings = 'Boredom'";
                cn.Connection = con;

                int down1 = (Convert.ToInt32(cn.ExecuteScalar())) * -1;



                int resultMood = (up1 + up2 + up3) - (down1 + down2 + down3);



                cn.CommandText = "SELECT COUNT(*) FROM moodlevel WHERE date = @date";
                int resultLevel = Convert.ToInt32(cn.ExecuteScalar());
                cn.Connection = con;

                if (resultLevel == 0)
                {
                    cn.CommandText = "INSERT INTO moodlevel (date, mood) VALUES (@date, @mood)";
                    cn.Parameters.Add("mood", SqlDbType.Int).Value = Convert.ToInt32(resultMood);
                    cn.Connection = con;
                    int qtd3 = cn.ExecuteNonQuery();
                    return resultMood;
                }
                else
                {
                    cn.CommandText = "UPDATE moodlevel SET mood = @mood WHERE date = @date";
                    cn.Parameters.Add("mood", SqlDbType.Int).Value = Convert.ToInt32(resultMood);
                    cn.Connection = con;
                    int qtd3 = cn.ExecuteNonQuery();
                    return resultMood;
                }

            }
        }


    }
   
}
