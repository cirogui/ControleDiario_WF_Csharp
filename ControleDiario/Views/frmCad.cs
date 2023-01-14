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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            try
            {
                if (cbTipo.Text == "" ^ tbDesc.Text == "" ^ cbPeso.Text == "")
                {
                    cadastro.Data = dtPicker.Value;
                    cadastro.Tipo = cbTipo.Text;
                    cadastro.Descricao = tbDesc.Text;
                    switch (cbPeso.Text)
                    {
                        case "Pouco importante": cadastro.Peso = 1;
                            break;

                        case "Importante": cadastro.Peso = 2;
                            break;

                        case "Muito importante": cadastro.Peso = 3;
                            break;

                        default: cadastro.Peso =  0;
                            break;
                    }
                    cadastro.Feito = 0;
                    int x = CadModel.Insert(cadastro);
                    if (x > 0)
                    {
                        MessageBox.Show("Cadastrado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Não inserido");
                    }
                } else
                {
                    MessageBox.Show("Preencha todos os elementos");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não inserido" + ex);
            }
            
          
        }
    }
}
