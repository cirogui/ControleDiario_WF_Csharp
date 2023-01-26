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

        /* public int UpdateProductivity(Control cadastro)
        {
            using (SqlConnection con = new SqlConnection())
            {
                // 1 - Procurar a menor data em que existe registros e inserir na variável minDate

                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT MIN(date) from registros5";
                cn.Connection = con;

                DateTime minDate = Convert.ToDateTime(cn.ExecuteScalar());

                // 2 - Verificar se já foi inserida a produtividade da menor data no bd produtividade

                cn.CommandText = "SELECT COUNT(*) FROM produtividade WHERE date = @date";
                cn.Parameters.Add("date", SqlDbType.DateTime).Value = minDate;
                cn.Connection = con;

                int resultDate = Convert.ToInt32(cn.ExecuteScalar());


                // 3 - Se não tiver produtividade inserida na tabela produtividade, calcular a produtividade do dia na tabela registros5 e inserir na tabela produtividade 

                if (resultDate == 0)
                {

                    cn.CommandText = "SELECT COUNT(*) FROM registros5 WHERE date = @date AND importance = 'Very important' AND done = 'Perfectly done'"; cn.Connection = con;
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

                    // insere os dados na tabela produtividade
                    cn.CommandText = "INSERT INTO produtividade (date, productivity) VALUES (@date, @productivity)";
                    cn.Parameters.Add("productivity", SqlDbType.Int).Value = Convert.ToInt32(result);
                    cn.Connection = con;

                    int qtd3 = cn.ExecuteNonQuery();
                    return qtd3;
                }
                // 4 - Se já tiver produtividade inserida na tabela produtividade, enquanto a data de referência for menor do que a data de hoje, incrementar um dia na data de referência e verificar se teve produtividade registrada nesse dia. Se não tiver, insere.
                else
                {

                    while (minDate < DateTime.Today)
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            minDate = minDate.AddDays(1);
                            cn.CommandText = String.Format("SELECT COUNT(*) FROM produtividade WHERE date = @date{0}", i);
                            cn.Parameters.Add(String.Format("date{0}", i), SqlDbType.DateTime).Value = minDate;
                            cn.Connection = con;
                            int dateResult5 = Convert.ToInt32(cn.ExecuteScalar());

                            if (dateResult5 == 0)
                            {
                                cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0}", i);
                                cn.Connection = con;
                                int resultDate3 = Convert.ToInt32(cn.ExecuteScalar());
                                if (resultDate3 == 0)
                                {
                                    cn.CommandText = String.Format("INSERT INTO produtividade (date, productivity) VALUES (@date{0}, 0)", i);
                                    cn.Connection = con;
                                    int qtd4 = cn.ExecuteNonQuery();
                                    return qtd4;
                                }
                                else
                                {
                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Very important' AND done = 'Perfectly done'", i);
                                    cn.Connection = con;
                                    double dr1 = (Convert.ToInt32(cn.ExecuteScalar())) * 2.5;
                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Very important' AND done = 'Done'", i);
                                    cn.Connection = con;
                                    double dr2 = (Convert.ToInt32(cn.ExecuteScalar())) * 2;
                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Very important' AND done = 'Partially done'", i);
                                    cn.Connection = con;
                                    double dr3 = (Convert.ToInt32(cn.ExecuteScalar())) * 1;
                                    double veryImportant = (dr1 + dr2 + dr3) * 3;

                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Important' AND done = 'Perfectly done'", i);
                                    cn.Connection = con;
                                    double dr4 = (Convert.ToInt32(cn.ExecuteScalar())) * 2.5;
                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Important' AND done = 'Done'", i);
                                    cn.Connection = con;
                                    double dr5 = (Convert.ToInt32(cn.ExecuteScalar())) * 2;
                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Important' AND done = 'Partially done'", i);
                                    cn.Connection = con;
                                    double dr6 = (Convert.ToInt32(cn.ExecuteScalar())) * 1;
                                    double important = (dr4 + dr5 + dr6) * 2;

                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Not important' AND done = 'Perfectly done'", i);
                                    cn.Connection = con;
                                    double dr7 = (Convert.ToInt32(cn.ExecuteScalar())) * 2.5;
                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Not important' AND done = 'Done'", i);
                                    cn.Connection = con;
                                    double dr8 = (Convert.ToInt32(cn.ExecuteScalar())) * 2;
                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Not important' AND done = 'Partially done'", i);
                                    cn.Connection = con;
                                    double dr9 = (Convert.ToInt32(cn.ExecuteScalar())) * 1;
                                    double notImportant = (dr7 + dr8 + dr9) * 1;

                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Very important'", i);
                                    cn.Connection = con;
                                    double total1 = (Convert.ToInt32(cn.ExecuteScalar())) * 3;

                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Important'", i);
                                    cn.Connection = con;
                                    double total2 = (Convert.ToInt32(cn.ExecuteScalar())) * 2;

                                    cn.CommandText = String.Format("SELECT COUNT(*) FROM registros5 WHERE date = @date{0} AND importance = 'Not important'", i);
                                    cn.Connection = con;
                                    double total3 = (Convert.ToInt32(cn.ExecuteScalar())) * 1;

                                    double totalTotal = (total1 + total2 + total3) * 2;

                                    double result4 = ((veryImportant + important + notImportant) / totalTotal) * 100;

                                    cn.CommandText = String.Format("INSERT INTO produtividade (date, productivity) VALUES (@date{0}, @productivity)", i);
                                    cn.Parameters.Add("productivity", SqlDbType.Int).Value = Convert.ToInt32(result4);
                                    cn.Connection = con;

                                    int qtd5 = cn.ExecuteNonQuery();
                                    return qtd5;
                                }
                            }
                        }


                    }

                    return 1;

                }



            }


        }*/

        
    }
}
