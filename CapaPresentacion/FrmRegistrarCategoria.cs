using CapaNegocio;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmRegistrarCategoria : Form
    {
        public bool Insert = false;
        public bool Edit = false;

        public FrmRegistrarCategoria()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtidcategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmRegistrarCategoria_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtdescripcion.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese los datos de la categoria", "Sistema de Ventas",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (this.Insert == true)
                    {
                        CNCategoria.Guardar(this.txtdescripcion.Text.Trim().ToUpper());
                        MessageBox.Show("Categoria registrada correctamente", "Sistema de Ventas.",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (this.Edit == true)
                    {
                        CNCategoria.Editar(Convert.ToInt32(this.txtidcategoria.Text),
                            this.txtdescripcion.Text.Trim().ToUpper());

                        MessageBox.Show("Categoria editada correctamente", "Sistema de Ventas.",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Insert = false;
                    this.Edit = false;

                    FrmListadoCategoria form = new FrmListadoCategoria();
                    form.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            FrmListadoCategoria form = new FrmListadoCategoria();
            form.Show();
            this.Hide();
        }
    }
}
