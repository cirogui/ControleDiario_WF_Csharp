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
        DateTime date;
        string type;
        string importance;
        string description;
        string done;



        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Type { get => type; set => type = value; }
        public string Importance { get => importance; set => importance = value; }
        public string Description { get => description; set => description = value; }
        public string Done { get => done; set => done = value; }

    }
}
