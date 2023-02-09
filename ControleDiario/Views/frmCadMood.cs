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
using Mood = ControleDiario.Entities.Mood;

namespace ControleDiario.Views
{
    public partial class frmCadMood : Form
    {
        Mood cadastro2 = new Mood();
        public frmCadMood()
        {
            InitializeComponent();
            dtpAddMood.Value = DateTime.Now;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            savemood();
            this.Close();
        }
        private void savemood()
        {
            try
            {
                if (cbFeeling.Text == "" ^ cbIntensity.Text == "")
                {
                    MessageBox.Show("Fill all the elements!");
                } else
                {
                    cadastro2.Date = dtpAddMood.Value;
                    cadastro2.Feelings = cbFeeling.Text;
                    cadastro2.Intensity = Convert.ToInt32(cbIntensity.Text);
                    cadastro2.Note = tbNote.Text;
                    int x = MoodModel.InsertMood(cadastro2);
                    if (x > 0)
                    {
                        MessageBox.Show("Added");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
