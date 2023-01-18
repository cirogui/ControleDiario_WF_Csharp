using ControleDiario.Models;
using ControleDiario.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control = ControleDiario.Entities.Control;

namespace ControleDiario
{
    public partial class Principal : Form
    {
        Control cadastro = new Control();
        public Principal()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmMark frmM = new frmMark();
            frmM.ShowDialog();
        }
    }
}
