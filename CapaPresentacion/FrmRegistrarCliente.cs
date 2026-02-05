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
        // PROCESO:
        // 1. Determina el estado del cliente según el RadioButton seleccionado
        // 2. Valida que los campos obligatorios estén llenos
        // 3. Si Insert=true: Llama a CNCliente.Guardar() que ejecuta el SP spguardar_cliente
        // 4. Si Edit=true: Llama a CNCliente.Editar() que ejecuta el SP speditar_cliente
        // 5. Ambos SP ejecutan INSERT o UPDATE respectivamente en la tabla dbo.cliente
        // 6. Regresa al listado de clientes para ver los cambios reflejados
        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Determinar el estado según el RadioButton seleccionado
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
                // Validar que los campos obligatorios no estén vacíos
                if (this.txtnombre.Text == string.Empty || this.txtapellidos.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese los datos del cliente", "Sistema de Ventas",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // MODO INSERTAR: Agregar nuevo cliente a la base de datos
                    if (this.Insert == true)
                    {
                        // Llamar al método Guardar con el orden correcto: nombre, apellidos, dni, rfc, telefono, estado
                        // Este método ejecuta el stored procedure: spguardar_cliente
                        // El SP hace un INSERT en la tabla dbo.cliente
                        CNCliente.Guardar(this.txtnombre.Text,
                            this.txtapellidos.Text,
                            this.txtdni.Text,
                            this.txtrfc.Text,
                            this.txttelefono.Text,
                            estado);
                        MessageBox.Show("Cliente registrado correctamente",
                            "Sistema de Ventas",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    // MODO EDITAR: Actualizar cliente existente en la base de datos
                    else if (this.Edit == true)
                    {
                        // Llamar al método Editar con el orden correcto: idcliente, nombre, apellidos, dni, rfc, telefono, estado
                        // Este método ejecuta el stored procedure: speditar_cliente
                        // El SP hace un UPDATE en la tabla dbo.cliente WHERE idcliente = @idcliente
                        CNCliente.Editar(Convert.ToInt32(this.txtidcliente.Text),
                            this.txtnombre.Text,
                            this.txtapellidos.Text,
                            this.txtdni.Text,
                            this.txtrfc.Text,
                            this.txttelefono.Text,
                            estado);
                        MessageBox.Show("Cliente editado correctamente",
                            "Sistema de Ventas",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    // Resetear las banderas de control
                    this.Insert = false;
                    this.Edit = false;

                    // Regresar al listado de clientes para ver los cambios
                    FrmListadoCliente form = new FrmListadoCliente();
                    form.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de fallo
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}