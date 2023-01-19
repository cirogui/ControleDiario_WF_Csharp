using ControleDiario.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control = ControleDiario.Entities.Control;

namespace ControleDiario.Views
{
    public partial class frmMark : Form
    {
        Control cadastro = new Control();
        public static int done = 0;
        public frmMark()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                done = 4;
            }
            this.Close();
            return;
            
        }

        
    }
}
