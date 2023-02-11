using ControleDiario.Controllers;
using ControleDiario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDiario.Models
{
    public class MoodModel
    {
        public static int InsertMood(Mood cadastro2)
        {
            return new MoodController().InsertMood(cadastro2);
        }
        public List<Mood> ToListMood(Mood cadastro2)
        {
            return new MoodController().ToListMood(cadastro2);
        }
        public static int UpdateMood(Mood cadastro2)
        {
            return new MoodController().UpdateMood(cadastro2);
        }
        public static int DeleteMood(Mood cadastro2)
        {
            return new MoodController().DeleteMood(cadastro2);
        }
        public static int CountMood(Mood cadastro2)
        {
            return new MoodController().CountMood(cadastro2);
        }
    }

}
