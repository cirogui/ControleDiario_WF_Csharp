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

namespace ControleDiario
{
    public partial class Principal : Form
    {
        Control cadastro = new Control();
        public Principal()
        {
            InitializeComponent();
            dtPrincipal.Value = DateTime.Today;
            ToList();
            Count();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cadastro.Date = dtPrincipal.Value;
            btEdit.Enabled = false;
            btMark.Enabled = false;
            btDelete.Enabled = false;
            ToList();
            Count();
        }

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

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmCad frmC = new frmCad();
            frmC.passingLanguage = comboBox1.Text;
            frmC.ShowDialog();
            ToList();
            Count();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgPrincipal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btEdit.Enabled = true;
            btMark.Enabled = true;
            btDelete.Enabled = true;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmMark frmM = new frmMark();
            frmM.ShowDialog();
            Mark();
            ToList();
            Count();

        }

        private void button2_Click(object sender, EventArgs e)
        {

           dgPrincipal.ReadOnly = false;

        }

        private void dgPrincipal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btEdit.Visible = false;
            btSave.Visible = true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            btSave.Visible = false;
            btEdit.Visible = true;
            
            Update();
            ToList();
            Count();


        }

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

        private void Delete()
        {
            cadastro.Id = Convert.ToInt32(dgPrincipal.CurrentRow.Cells[0].Value);
            int d = CadModel.Delete(cadastro);

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            Delete();
            ToList();
            Count();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCad frmC = new frmCad();
            frmC.passingLanguage = comboBox1.Text;
            frmC.ShowDialog();
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
