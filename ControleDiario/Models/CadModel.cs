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
    }
}
