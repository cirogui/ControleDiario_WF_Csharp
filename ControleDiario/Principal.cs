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
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cadastro.Data = dtPrincipal.Value;
            ToList();
        }

        private void ToList()
        {
            try
            {
                cadastro.Data = dtPrincipal.Value;
                List<Control> list = new List<Control>();
                list = new CadModel().ToList(cadastro);               
                dgPrincipal.DataSource = list;
                dgPrincipal.Columns[0].Visible = false;
                dgPrincipal.Columns[1].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível listar" + ex);
            }
        }
        /* private void ToListAll()
        {
            try
            {
                List<Control> list = new List<Control>();
                list = new CadModel().ToList(cadastro);
                dgPrincipal.DataSource = list;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível listar" + ex);
            }
        }
        */
        private void btAdd_Click(object sender, EventArgs e)
        {
            frmCad frmC = new frmCad();
            frmC.ShowDialog();
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
            cadastro.Data = dtPrincipal.Value;
            ToList();


        }

        private void Update()
        {
            try
            {
                cadastro.Id = Convert.ToInt32(dgPrincipal.CurrentRow.Cells[0].Value);
                cadastro.Data = (DateTime)dgPrincipal.CurrentRow.Cells[1].Value;
                cadastro.Tipo = Convert.ToString(dgPrincipal.CurrentRow.Cells[2].Value);
                cadastro.Peso = Convert.ToInt32(dgPrincipal.CurrentRow.Cells[3].Value);
                cadastro.Descricao = Convert.ToString(dgPrincipal.CurrentRow.Cells[4].Value);
                cadastro.Feito = Convert.ToInt32(dgPrincipal.CurrentRow.Cells[5].Value);
                int y = CadModel.Update(cadastro);
                if (y > 0)
                {
                    MessageBox.Show("Atualizado com sucesso!");
                } else
                {
                    MessageBox.Show("Não inserido!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não inserido" + ex);
            }
        }
        private void Mark()
        {
            try
            {

                cadastro.Feito = frmMark.done;
                cadastro.Id = Convert.ToInt32(dgPrincipal.CurrentRow.Cells[0].Value);

                int z = CadModel.Mark(cadastro);
                if (z > 0)
                {
                    MessageBox.Show("Marked!");
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }
    }
}
