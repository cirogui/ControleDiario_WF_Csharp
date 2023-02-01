using ControleDiario.Controllers;
using ControleDiario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDiario.Models
{
    public class CadModel
    {
        public static int Insert(Control cadastro)
        {
            return new CadController().Insert(cadastro);    
        }

        public List<Control> ToList(Control cadastro)
        {
            return new CadController().ToList(cadastro);
        }        
        public static int Update(Control cadastro)
        {
            return new CadController().Update(cadastro);
        }
        public static int Mark(Control cadastro)
        {
            return new CadController().Mark(cadastro);
        }
        public static int Count(Control cadastro)
        {
            return new CadController().Count(cadastro);
        }
        public static int Delete(Control cadastro)
        {
            return new CadController().Delete(cadastro);
        }

    }
}
