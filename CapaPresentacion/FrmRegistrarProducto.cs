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
    public partial class FrmRegistrarProducto : Form
    {
        public bool Insert = false;
        public bool Edit = false;

        public FrmRegistrarProducto()
        {
            InitializeComponent();
            CargarCategoria();
        }

        private void CargarCategoria()
        {
            cboidcategoria.DataSource = CNCategoria.Listar();
            cboidcategoria.ValueMember = "idcategoria";
            cboidcategoria.DisplayMember = "descripcion";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmRegistrarProducto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string estado = rbtnactivo.Checked ? "ACTIVO" : "INACTIVO";

            try
            {
                if (string.IsNullOrEmpty(this.txtnombre.Text) || string.IsNullOrEmpty(this.txtcodigo.Text))
                {
                    MessageBox.Show("Ingrese los datos del producto", "Sistema de Ventas",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (this.Insert == true)
                    {
                        CNProducto.Guardar(
                            this.txtcodigo.Text,
                            this.txtnombre.Text,
                            this.txtdescripcion.Text,
                            this.dtpfingreso.Value,
                            this.dtpfvencimiento.Value,
                            Convert.ToDouble(this.txtpcompra.Text),
                            Convert.ToDouble(this.txtpventa.Text),
                            Convert.ToInt32(this.txtstock.Text),
                            estado,
                            Convert.ToInt32(cboidcategoria.SelectedValue)
                        );

                        MessageBox.Show("Producto registrado correctamente", "Sistema de Ventas.",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (this.Edit == true)
                    {
                        CNProducto.Editar(
                            Convert.ToInt32(this.txtidproducto.Text),
                            this.txtcodigo.Text,
                            this.txtnombre.Text,
                            this.txtdescripcion.Text,
                            this.dtpfingreso.Value,
                            this.dtpfvencimiento.Value,
                            Convert.ToDouble(this.txtpcompra.Text),
                            Convert.ToDouble(this.txtpventa.Text),
                            Convert.ToInt32(this.txtstock.Text),
                            estado,
                            Convert.ToInt32(cboidcategoria.SelectedValue)
                        );

                        MessageBox.Show("Producto editado correctamente", "Sistema de Ventas.",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Insert = false;
                    this.Edit = false;

                    FrmListadoProducto form = new FrmListadoProducto();
                    form.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtstock_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            FrmListadoProducto form = new FrmListadoProducto();
            form.Show();
            this.Hide();
        }

        private void txtcategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbocategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
