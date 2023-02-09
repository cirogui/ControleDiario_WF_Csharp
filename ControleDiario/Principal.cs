using ControleDiario.Models;
using ControleDiario.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Control = ControleDiario.Entities.Control;
using Mood = ControleDiario.Entities.Mood;

namespace ControleDiario
{
    public partial class Principal : Form
    {
        Control cadastro = new Control();
        Mood cadastro2 = new Mood();
        public Principal()
        {
            InitializeComponent();
            dtPrincipal.Value = DateTime.Today;
            dtpMood.Value = DateTime.Today; 
            RepeatHabit();
            ToList();
            ToListMood();
            Count();
            
        }

        //Evento mudança de valor do dtPicker Habit/Task
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cadastro.Date = dtPrincipal.Value;
            btEdit.Enabled = false;
            btMark.Enabled = false;
            btDelete.Enabled = false;
            ToList();
            ToListMood();
            Count();
        }


        //Evento mudança de valor do Mood
        private void dtpMood_ValueChanged(object sender, EventArgs e)
        {
            cadastro2.Date = dtpMood.Value;
            btEditMood.Enabled = false;
            btDeleteMood.Enabled = false;
            ToList();
            ToListMood();
            Count();
        }

        // Listar registros no DataGrid Habit/Task
        private void ToList()
        {
            try
            {
                cadastro.Date = dtPrincipal.Value;
                List<Control> list = new List<Control>();
                list = new CadModel().ToList(cadastro);               
                dgPrincipal.DataSource = list;
                dgPrincipal.Columns[0].Visible = false;
                dgPrincipal.Columns[1].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error listing" + ex);
            }
        }


        // Listar registros no DataGrid Mood
        private void ToListMood()
        {
            try
            {
                cadastro2.Date = dtpMood.Value;
                List<Mood> list2 = new List<Mood>();
                list2 = new MoodModel().ToListMood(cadastro2);
                dgMood.DataSource = list2;
                dgMood.Columns[0].Visible = false;
                dgMood.Columns[1].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error listing" + ex);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Evento ao clicar numa célula do DataGrid Habit/Task
        private void dgPrincipal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btEdit.Enabled = true;
            btMark.Enabled = true;
            btDelete.Enabled = true;
        }


        // Evento ao clicar numa célula do DataGrid Mood
        private void dgMood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btEditMood.Enabled = true;
            btDeleteMood.Enabled = true;
        }


        //Evento ao clilar no botão Edit do Habit/Task
        private void button2_Click(object sender, EventArgs e)
        {

           dgPrincipal.ReadOnly = false;

        }



        // Evento ao clicar no botão Edit do Habit/Task
        private void btEdit_Click(object sender, EventArgs e)
        {
            dgPrincipal.ReadOnly = false;
        }


        // Evento ao clicar no botão Edit do Mood
        private void btEditMood_Click(object sender, EventArgs e)
        {
            dgMood.ReadOnly = false;
        }


        // Evento ao modificar o conteúdo de uma célula do DataGrid Habit/Task
        private void dgPrincipal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btEdit.Visible = false;
            btSave.Visible = true;
        }


        // Evento ao modificar o conteúdo de uma célula do DataGrid Mood
        private void dgMood_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btEditMood.Visible = false;
            btSaveMood.Visible = true;
        }







        // Evento ao clicar no botão Save do Habit/Task
        private void btSave_Click_1(object sender, EventArgs e)
        {
            btSave.Visible = false;
            btEdit.Visible = true;
            dgPrincipal.ReadOnly = true;
            Update();
            ToList();
            Count();
        }


        // Evento ao clicar no botão Save do Mood
        private void btSaveMood_Click(object sender, EventArgs e)
        {
            btSaveMood.Visible = false;
            btEditMood.Visible = true;
            dgMood.ReadOnly = true;
            UpdateMood();
            ToList();
            ToListMood();
            Count();
        }


        // Função Update Habit/Task
        private void Update()
        {
            try
            {
                cadastro.Id = Convert.ToInt32(dgPrincipal.CurrentRow.Cells[0].Value);
                cadastro.Date = (DateTime)dgPrincipal.CurrentRow.Cells[1].Value;
                cadastro.Type = Convert.ToString(dgPrincipal.CurrentRow.Cells[2].Value);
                cadastro.Importance = Convert.ToString(dgPrincipal.CurrentRow.Cells[3].Value);
                cadastro.Description = Convert.ToString(dgPrincipal.CurrentRow.Cells[4].Value);
                cadastro.Done = Convert.ToString(dgPrincipal.CurrentRow.Cells[5].Value);
                int y = CadModel.Update(cadastro);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }



        // Função Update Mood
        private void UpdateMood()
        {
            try
            {
                cadastro2.Id = Convert.ToInt32(dgMood.CurrentRow.Cells[0].Value);
                cadastro2.Date = (DateTime)dgMood.CurrentRow.Cells[1].Value;
                cadastro2.Feelings = Convert.ToString(dgMood.CurrentRow.Cells[2].Value);
                cadastro2.Intensity = Convert.ToInt32(dgMood.CurrentRow.Cells[3].Value);
                cadastro2.Note = Convert.ToString(dgMood.CurrentRow.Cells[4].Value);
                int z = MoodModel.UpdateMood(cadastro2);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }



        // Função registrar Habit/Task
        private void Mark()
        {
            try
            {

                cadastro.Done = frmMark.done;
                cadastro.Id = Convert.ToInt32(dgPrincipal.CurrentRow.Cells[0].Value);

                int z = CadModel.Mark(cadastro);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }



        // Função calcular produtividade Habit/Task
        private void Count()
        {
            try
            {

                cadastro.Date = dtPrincipal.Value;

                int c = CadModel.Count(cadastro);

                if (c > 0)
                {
                    label3.Text = Convert.ToString(c) + "%";
                    progressBar1.Value = Convert.ToInt32(c);

                } else
                {
                    label3.Text = "0%";
                    progressBar1.Value = 0;
                   
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }


        // Função delete Habit/Task
        private void Delete()
        {
            cadastro.Id = Convert.ToInt32(dgPrincipal.CurrentRow.Cells[0].Value);
            int d = CadModel.Delete(cadastro);

        }


        // Função delete Habit/Task
        private void DeleteMood()
        {
            cadastro.Id = Convert.ToInt32(dgMood.CurrentRow.Cells[0].Value);
            int e = MoodModel.DeleteMood(cadastro2);

        }


        /* private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Português")
            {
                arquivoToolStripMenuItem.Text = "Arquivo";
                relatóriosToolStripMenuItem.Text = "Relatórios";
                addToolStripMenuItem.Text = "Adicionar";
                exitToolStripMenuItem.Text = "Sair";
                label1.Text = "Hábitos e tarefas do dia:";
                label4.Text = "Idioma";
                btAdd.Text = "Adicionar";
                btSave.Text = "Salvar";
                btMark.Text = "Registrar";
                btDelete.Text = "Excluir";
                btEdit.Text = "Editar";
                label2.Text = "Nível de produtividade:";
                label1.Text = "Tipo";
                
                
            } else
            {
                arquivoToolStripMenuItem.Text = "File";
                relatóriosToolStripMenuItem.Text = "Reports";
                addToolStripMenuItem.Text = "Add";
                exitToolStripMenuItem.Text = "Exit";
                label1.Text = "Today tasks and habits:";
                label4.Text = "Language";
                btAdd.Text = "Add";
                btSave.Text = "Save";
                btMark.Text = "Mark";
                btDelete.Text = "Delete";
                btEdit.Text = "Edit";
                label2.Text = "Productivity level:";
                label1.Text = "Type";
            }
        } */

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        // Evento ao clicar no botão Add do menu do Habit/Task
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCad frmC = new frmCad();
            frmC.passingLanguage = comboBox1.Text;
            frmC.ShowDialog();
            ToList();
            Count();
        }


        // Evento ao clicar no botão Add do Habit/Task
        private void btAdd_Click_1(object sender, EventArgs e)
        {
            frmCad frmC = new frmCad();
            //frmC.passingLanguage = comboBox1.Text;
            frmC.ShowDialog();
            ToList();
            Count();
        }


        // Evento ao clicar no botão Add do Mood
        private void btAddMood_Click(object sender, EventArgs e)
        {
            frmCadMood frmCadM = new frmCadMood();
            frmCadM.ShowDialog();
            ToListMood();
        }

        // Função para repetir o hábito do dia anterior
        private void RepeatHabit()
        {
            try
            {
                int qtd = CadModel.RepeatHabit(cadastro);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail" + ex);
            }
        }


        // Evento ao clicar no botão Delete do Habit/Task
        private void btDelete_Click_1(object sender, EventArgs e)
        {
            Delete();
            ToList();
            Count();
        }


        // Evento ao clicar no botão Delete do Mood
        private void btDeleteMood_Click(object sender, EventArgs e)
        {
            DeleteMood();
            ToListMood();
        }


        // Evento ao clicar no botão Mark do Habit/Task
        private void btMark_Click(object sender, EventArgs e)
        {
            frmMark frmM = new frmMark();
            frmM.ShowDialog();
            Mark();
            ToList();
            Count();
        }







        private void Principal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'controlediarioDataSet.produtividade2' table. You can move, or remove it, as needed.
            this.produtividade2TableAdapter.Fill(this.controlediarioDataSet.produtividade2);

        }

       














    }
}
