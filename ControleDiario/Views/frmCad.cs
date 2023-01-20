using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleDiario.Entities;
using ControleDiario.Models;
using Control = ControleDiario.Entities.Control;

namespace ControleDiario.Views
{
    public partial class frmCad : Form
    {
        Control cadastro = new Control();
        public frmCad()
        {
            InitializeComponent();
            dtPicker.Value = DateTime.Today;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }

        private void save()
        {



            try
            {
                 if (cbTipo.Text != "" ^ tbDesc.Text != "" ^ cbPeso.Text != "")
                {
                    cadastro.Date = dtPicker.Value;
                    cadastro.Type = cbTipo.Text;
                    cadastro.Description = tbDesc.Text;
                    cadastro.Importance = cbPeso.Text;
                    cadastro.Done = "Un done";
                    int x = CadModel.Insert(cadastro);
                    if (x > 0)
                    {
                        MessageBox.Show("Added");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                } else
                {
                    MessageBox.Show("Fill all the elements!");
                }
                
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            

        }

        private void frmCad_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
