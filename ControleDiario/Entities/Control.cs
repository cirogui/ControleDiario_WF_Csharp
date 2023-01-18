using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDiario.Entities
{
    public class Control
    {
        int id;
        DateTime data;
        string tipo;
        int peso;
        string descricao;
        int feito;

        public int Id { get => id; set => id = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Peso { get => peso; set => peso = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public int Feito { get => feito; set => feito = value; }
    }
}
