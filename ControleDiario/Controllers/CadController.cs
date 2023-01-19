using ControleDiario.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                cn.CommandText = "INSERT INTO registros3 ([data], [tipo], [peso], [descricao], [feito]) VALUES (@data, @tipo, @peso, @descricao, @feito)";
                cn.Parameters.Add("data", SqlDbType.DateTime).Value = cadastro.Data;
                cn.Parameters.Add("tipo", SqlDbType.VarChar).Value = cadastro.Tipo;
                cn.Parameters.Add("peso", SqlDbType.Int).Value = cadastro.Peso;
                cn.Parameters.Add("descricao", SqlDbType.VarChar).Value = cadastro.Descricao;
                cn.Parameters.Add("FEITO", SqlDbType.Float).Value = cadastro.Feito;                
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }

        public List<Control> ToList (Control cadastro)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * from registros3 WHERE data = @data";
                cn.Parameters.Add("data", SqlDbType.DateTime).Value = cadastro.Data;
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
                        dado.Data = Convert.ToDateTime(dr["data"]);
                        dado.Tipo = Convert.ToString(dr["tipo"]);
                        dado.Peso = Convert.ToInt32(dr["peso"]);
                        dado.Descricao = Convert.ToString(dr["descricao"]);
                        dado.Feito = Convert.ToInt32(dr["feito"]);
                        list.Add(dado);
                    }
                    
                }
                return list;
            }

        }
        public List<Control> ToListAll ()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.Setting;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * from registros3";
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
                        dado.Data = Convert.ToDateTime(dr["data"]);
                        dado.Tipo = Convert.ToString(dr["tipo"]);
                        dado.Peso = Convert.ToInt32(dr["peso"]);
                        dado.Descricao = Convert.ToString(dr["descricao"]);
                        dado.Feito = Convert.ToInt32(dr["feito"]);
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
                cn.CommandText = "UPDATE registros3 SET data = @data, tipo = @tipo, peso = @peso, descricao = @descricao, feito = @feito WHERE id = @id";
                cn.Parameters.Add("data", SqlDbType.DateTime).Value = cadastro.Data;
                cn.Parameters.Add("tipo", SqlDbType.VarChar).Value = cadastro.Tipo;
                cn.Parameters.Add("peso", SqlDbType.Int).Value = cadastro.Peso;
                cn.Parameters.Add("descricao", SqlDbType.VarChar).Value = cadastro.Descricao;
                cn.Parameters.Add("feito", SqlDbType.Float).Value = cadastro.Feito;
                cn.Parameters.Add("id", SqlDbType.Int).Value = cadastro.Id;
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
                cn.CommandText = "UPDATE registros3 SET feito = @feito WHERE id = @id";
                cn.Parameters.Add("feito", SqlDbType.Float).Value = cadastro.Feito;
                cn.Parameters.Add("id", SqlDbType.Int).Value = cadastro.Id;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }
    }
}
