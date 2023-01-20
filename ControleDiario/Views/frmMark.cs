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
        public static string done = "";
        public frmMark()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                done = "Perfectly done";
            } 
            else if (radioButton2.Checked)
            {
                done = "Done";   
            } 
            else if (radioButton3.Checked)
            {
                done = "Partially done";
            } 
            else if (radioButton4.Checked)
            {
                done = "Un done";
            } 
            else
            {
                MessageBox.Show("Select an option!");
            }
            this.Close();
            return;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
