using ControleDiario.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDiario.Models;
using ControleDiario.Views;
using Control = ControleDiario.Entities.Control;


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
                cn.CommandText = "INSERT INTO registros5 ([date], [type], [importance], [description], [done]) VALUES (@date, @type, @importance, @description, @done)";
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = cadastro.Date;
                cn.Parameters.Add("type", SqlDbType.VarChar).Value = cadastro.Type;
                cn.Parameters.Add("importance", SqlDbType.VarChar).Value = cadastro.Importance;
                cn.Parameters.Add("description", SqlDbType.VarChar).Value = cadastro.Description;
                cn.Parameters.Add("done", SqlDbType.VarChar).Value = cadastro.Done;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }

        public List<Control> ToList(Control cadastro)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * from registros5 WHERE date = @date";
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = cadastro.Date;
                cn.Connection = con;

                SqlDataReader dr;
                List<Control> list = new List<Control>();
                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Control dado = new Control();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.Date = Convert.ToDateTime(dr["date"]);
                        dado.Type = Convert.ToString(dr["type"]);
                        dado.Importance = Convert.ToString(dr["importance"]);
                        dado.Description = Convert.ToString(dr["description"]);
                        dado.Done = Convert.ToString(dr["done"]);
                        list.Add(dado);
                    }

                }
                return list;
            }

        }
        public int Update(Control cadastro)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "UPDATE registros5 SET data = @date, type = @type, importance = @importance, description = @description, done = @done WHERE id = @id";
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = cadastro.Date;

                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }

        public int Mark(Control cadastro)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "UPDATE registros5 SET done = @done WHERE id = @id";
                cn.Parameters.Add("done", SqlDbType.VarChar).Value = cadastro.Done;
                cn.Parameters.Add("id", SqlDbType.Int).Value = cadastro.Id;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }

        public int Count(Control cadastro)
        {
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();


                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Very important' AND done = 'Perfectly done'";
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = cadastro.Date;
                cn.Connection = con;

                double dr1 = (Convert.ToInt32(cn.ExecuteScalar())) * 2.5;

                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Very important' AND done = 'Done'";
                cn.Connection = con;

                double dr2 = (Convert.ToInt32(cn.ExecuteScalar())) * 2;

                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Very important' AND done = 'Partially done'";
                cn.Connection = con;

                double dr3 = (Convert.ToInt32(cn.ExecuteScalar())) * 1;

                double veryImportant = (dr1 + dr2 + dr3) * 3;




                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Important' AND done = 'Perfectly done'";
                cn.Connection = con;

                double dr4 = (Convert.ToInt32(cn.ExecuteScalar())) * 2.5;


                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Important' AND done = 'Done'";
                cn.Connection = con;

                double dr5 = (Convert.ToInt32(cn.ExecuteScalar())) * 2;

                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Important' AND done = 'Partially done'";
                cn.Connection = con;

                double dr6 = (Convert.ToInt32(cn.ExecuteScalar())) * 1;

                double important = (dr4 + dr5 + dr6) * 2;




                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Not important' AND done = 'Perfectly done'";
                cn.Connection = con;

                double dr7 = (Convert.ToInt32(cn.ExecuteScalar())) * 2.5;

                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Not important' AND done = 'Done'";
                cn.Connection = con;

                double dr8 = (Convert.ToInt32(cn.ExecuteScalar())) * 2;

                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Not important' AND done = 'Partially done'";
                cn.Connection = con;

                double dr9 = (Convert.ToInt32(cn.ExecuteScalar())) * 1;

                double notImportant = (dr7 + dr8 + dr9) * 1;




                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Very important'";
                cn.Connection = con;

                double total1 = (Convert.ToInt32(cn.ExecuteScalar())) * 3;

                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Important'";
                cn.Connection = con;

                double total2 = (Convert.ToInt32(cn.ExecuteScalar())) * 2;

                cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Not important'";
                cn.Connection = con;

                double total3 = (Convert.ToInt32(cn.ExecuteScalar())) * 1;

                double totalTotal = (total1 + total2 + total3) * 2;

                double result = ((veryImportant + important + notImportant) / totalTotal) * 100;


                cn.CommandText = "SELECT COUNT(*) FROM produtividade2 WHERE date = @date";
                int resultProd = Convert.ToInt32(cn.ExecuteScalar());
                cn.Connection = con;

                if (result > 0)
                {
                    if (result > 100)
                    {
                        result = 100;
                    }
                    if (resultProd == 0)
                    {
                        cn.CommandText = "INSERT INTO produtividade2 (date, productivity) VALUES (@date, @productivity)";
                        cn.Parameters.Add("productivity", SqlDbType.Int).Value = Convert.ToInt32(result);
                        cn.Connection = con;
                        int qtd = cn.ExecuteNonQuery();
                        return Convert.ToInt32(result);

                    }
                    else
                    {
                        cn.CommandText = "UPDATE produtividade2 SET productivity = @productivity WHERE date = @date";
                        cn.Parameters.Add("productivity", SqlDbType.Int).Value = Convert.ToInt32(result);
                        cn.Connection = con;
                        int qtd = cn.ExecuteNonQuery();
                        return Convert.ToInt32(result);
                    }
                }
               
                return 0;

            }
        }
        public int Delete(Control cadastro)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "DELETE from registros5 WHERE id = @id";
                cn.Parameters.Add("id", SqlDbType.Int).Value = cadastro.Id;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }
        public int RepeatHabit(Control cadastro)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT COUNT (*) from registros5 WHERE type = 'Habit' AND date = @date";
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = DateTime.Today;
                cn.Connection = con;

                int habitqtd = Convert.ToInt32(cn.ExecuteScalar());

                if (habitqtd == 0)
                {
                    cn.CommandText = "SELECT COUNT (*) from registros5 WHERE type = 'Habit' AND date = @date2";
                    cn.Parameters.Add("date2", SqlDbType.DateTime).Value = DateTime.Today.AddDays(-1);
                    cn.Connection = con;
                    int habitystd = Convert.ToInt32(cn.ExecuteScalar());    

                    if (habitystd != 0)
                    {
                        cn.CommandText = "INSERT INTO registros5 (date, type, importance, description, done) SELECT @date as date, type, importance, description, 'Un done' as done from registros5 WHERE type = 'Habit'";
                        int qtd3 = cn.ExecuteNonQuery();
                        return qtd3;
                    }

                }

                return 1;
            }
        }
    }
}
