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
                    if (cbTipo.Text == "Hábito")
                    {
                        cadastro.Type = "Habit";
                    } else if (cbTipo.Text == "Tarefa")
                    {
                        cadastro.Type = "Task";
                    } else
                    {
                        cadastro.Type = cbTipo.Text;
                    }
                    
                    cadastro.Description = tbDesc.Text;

                    switch (cbPeso.Text)
                    {
                        case "Muito importante":
                            cadastro.Importance = "Very important";
                            break;

                        case "Importante":
                            cadastro.Importance = "Important";
                            break;

                        case "Pouco importante":
                            cadastro.Importance = "Not important";
                            break;

                        default:
                            cadastro.Importance = cbPeso.Text;
                            break;
                    }
                       
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

            /* if (language == "Português")
            {
                label1.Text = "Tipo:";
                lb2.Text = "Descrição";
                label2.Text = "Importância:";
                button1.Text = "Adicionar";
                button2.Text = "Cancelar";
                cbTipo.Items.Remove("Habit");
                cbTipo.Items.Remove("Task");
                cbTipo.Items.Add("Hábito");
                cbTipo.Items.Add("Tarefa");
                cbPeso.Items.Remove("Very important");
                cbPeso.Items.Remove("Important");
                cbPeso.Items.Remove("Not important");
                cbPeso.Items.Add("Muito importante");
                cbPeso.Items.Add("Importante");
                cbPeso.Items.Add("Pouco importante");
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string language;


        public string passingLanguage
        {
            get { return language; } 
            set { language = value; }   
        }

    }
}
