using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDiario.Entities
{
    public class Mood
    {
        int id;
        DateTime date;
        string feelings;
        int intensity;
        string note;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Feelings { get => feelings; set => feelings = value; }
        public int Intensity { get => intensity; set => intensity = value; }
        public string Note { get => note; set => note = value; }
    }
}
