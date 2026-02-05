using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    // FORMULARIO DE REGISTRO DE CLIENTES
    // Este formulario permite registrar nuevos clientes o editar clientes existentes
    public partial class FrmRegistrarCliente : Form
    {
        // VARIABLES DE CONTROL DE OPERACIÓN
        public bool Insert = false;  // Indica si se está insertando un nuevo registro
        public bool Edit = false;    // Indica si se está editando un registro existente

        // CONSTRUCTOR DEL FORMULARIO
        public FrmRegistrarCliente()
        {
            InitializeComponent();
        }

        // EVENTO LOAD DEL FORMULARIO
        // Se ejecuta al cargar el formulario
        private void FrmRegistrarCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        // EVENTO CLICK DEL BOTÓN CANCELAR
        // Cierra el formulario actual y regresa al listado de clientes
        private void btncancelar_Click(object sender, EventArgs e)
        {
            FrmListadoCliente form = new FrmListadoCliente();
            form.Show();
            this.Hide();
        }

        // EVENTO CLICK DEL BOTÓN GUARDAR
        // Guarda o edita el cliente según el modo en que se abrió el formulario
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string estado = "";
            if (rbtnactivo.Checked == true)
            {
                estado = "ACTIVO";
            }
            else
            {
                estado = "INACTIVO";
            }

            try
            {
                if (this.txtnombre.Text == string.Empty || this.txtapellidos.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese los datos del cliente", "Sistema de Ventas",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (this.Insert == true)
                    {
                        CNCliente.Guardar(this.txtnombre.Text,
                            this.txtapellidos.Text,
                            this.txtrfc.Text,
                            this.txtdni.Text,
                            this.txttelefono.Text,
                            estado);
                        MessageBox.Show("Cliente registrado correctamente",
                            "Sistema de Ventas",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else if (this.Edit == true)
                    {
                        CNCliente.Editar(Convert.ToInt32(this.txtidcliente.Text),
                            this.txtnombre.Text,
                            this.txtapellidos.Text,
                            this.txtrfc.Text,
                            this.txtdni.Text,
                            this.txttelefono.Text,
                            estado);
                        MessageBox.Show("Cliente editado correctamente",
                            "Sistema de Ventas",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    this.Insert = false;
                    this.Edit = false;

                    FrmListadoCliente form = new FrmListadoCliente();
                    form.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}