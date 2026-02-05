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
    // FORMULARIO DE LISTADO DE CLIENTES
    // Este formulario muestra todos los clientes registrados y permite buscar, crear, editar y eliminar
    public partial class FrmListadoCliente : Form
    {
        // CONSTRUCTOR DEL FORMULARIO
        public FrmListadoCliente()
        {
            InitializeComponent();
        }

        // EVENTO LOAD DEL FORMULARIO
        // Se ejecuta al cargar el formulario
        private void FrmListadoCliente_Load_1(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Listar();
        }

        // MÉTODO PARA LISTAR TODOS LOS CLIENTES
        // Carga todos los clientes en el DataGridView
        private void Listar()
        {
            try
            {
                dlistado.DataSource = CNCliente.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        // EVENTO CLICK DEL BOTÓN BUSCAR
        // Busca clientes por nombre o DNI según el criterio seleccionado
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnnombre.Checked == true)
                {
                    dlistado.DataSource = CNCliente.BuscarNombre(txtbuscar.Text);
                }
                else if (rbtndni.Checked == true)
                {
                    dlistado.DataSource = CNCliente.BuscarDni(txtbuscar.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        // EVENTO CLICK DEL BOTÓN NUEVO
        // Abre el formulario de registro para crear un nuevo cliente
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FrmRegistrarCliente form = new FrmRegistrarCliente();
            form.Insert = true;
            form.Show();
            this.Hide();
        }

        // EVENTO CLICK DEL BOTÓN EDITAR
        // Abre el formulario de registro con los datos del cliente seleccionado para editarlo
        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dlistado.SelectedRows.Count > 0)
            {
                FrmRegistrarCliente form = new FrmRegistrarCliente();
                form.Edit = true;
                form.txtidcliente.Text = dlistado.CurrentRow.Cells["idcliente"].Value.ToString();
                form.txtnombre.Text = dlistado.CurrentRow.Cells["nombre"].Value.ToString();
                form.txtapellidos.Text = dlistado.CurrentRow.Cells["apellidos"].Value.ToString();
                form.txtdni.Text = dlistado.CurrentRow.Cells["dni"].Value.ToString();
                form.txtrfc.Text = dlistado.CurrentRow.Cells["rfc"].Value.ToString();
                form.txttelefono.Text = dlistado.CurrentRow.Cells["telefono"].Value.ToString();

                if (dlistado.CurrentRow.Cells["estado"].Value.ToString() == "ACTIVO")
                {
                    form.rbtnactivo.Checked = true;
                }
                else
                {
                    form.rbtninactivo.Checked = true;
                }

                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // EVENTO CLICK DEL BOTÓN ELIMINAR
        // Elimina el cliente seleccionado después de confirmación
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dlistado.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el cliente?", "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string rpta = CNCliente.Eliminar(Convert.ToInt32(dlistado.CurrentRow.Cells["idcliente"].Value));

                        if (rpta == "OK")
                        {
                            MessageBox.Show("Cliente eliminado correctamente", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Listar();
                        }
                        else
                        {
                            MessageBox.Show(rpta, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}