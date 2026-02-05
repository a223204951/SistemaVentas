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
        // Carga todos los clientes registrados en el DataGridView desde la base de datos
        // PROCESO:
        // 1. Llama a CNCliente.Listar() de la capa de negocio
        // 2. Este método ejecuta el SP splistar_cliente
        // 3. El SP hace un SELECT * FROM dbo.cliente ORDER BY nombre ASC
        // 4. Retorna un DataTable con todos los registros
        // 5. Asigna el DataTable al DataSource del DataGridView para mostrar los datos
        private void Listar()
        {
            try
            {
                // Obtener todos los clientes de la base de datos y mostrarlos en el grid
                dlistado.DataSource = CNCliente.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        // EVENTO CLICK DEL BOTÓN BUSCAR
        // Busca clientes por nombre o DNI según el criterio seleccionado en la base de datos
        // PROCESO:
        // 1. Verifica cuál RadioButton está seleccionado (Nombre o DNI)
        // 2. Si es por Nombre: Llama a CNCliente.BuscarNombre() que ejecuta spbuscar_cliente_nombre
        //    - El SP hace: SELECT * FROM cliente WHERE nombre LIKE '%@nombre%' OR apellidos LIKE '%@nombre%'
        // 3. Si es por DNI: Llama a CNCliente.BuscarDni() que ejecuta spbuscar_cliente_dni
        //    - El SP hace: SELECT * FROM cliente WHERE dni LIKE '%@dni%'
        // 4. Retorna un DataTable con los resultados filtrados
        // 5. Actualiza el DataGridView con los resultados de la búsqueda
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Buscar por NOMBRE o APELLIDOS
                if (rbtnnombre.Checked == true)
                {
                    dlistado.DataSource = CNCliente.BuscarNombre(txtbuscar.Text);
                }
                // Buscar por DNI
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
        // PROCESO:
        // 1. Crea una nueva instancia del formulario FrmRegistrarCliente
        // 2. Establece la bandera Insert=true para indicar que es un nuevo registro
        // 3. Muestra el formulario de registro en blanco
        // 4. Al hacer clic en Guardar, se ejecutará el SP spguardar_cliente
        // 5. El SP insertará el nuevo cliente en la tabla dbo.cliente de la base de datos
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FrmRegistrarCliente form = new FrmRegistrarCliente();
            form.Insert = true;  // Bandera para indicar modo INSERTAR
            form.Show();
            this.Hide();
        }

        // EVENTO CLICK DEL BOTÓN EDITAR
        // Abre el formulario de registro con los datos del cliente seleccionado para editarlo
        // PROCESO:
        // 1. Verifica que haya un cliente seleccionado en el DataGridView
        // 2. Crea una nueva instancia del formulario FrmRegistrarCliente
        // 3. Establece la bandera Edit=true para indicar modo edición
        // 4. Carga todos los datos del cliente seleccionado en los campos del formulario
        // 5. Al hacer clic en Guardar, se ejecutará el SP speditar_cliente
        // 6. El SP actualizará el registro en la tabla dbo.cliente WHERE idcliente = @idcliente
        private void btneditar_Click(object sender, EventArgs e)
        {
            // Verificar que haya un cliente seleccionado
            if (dlistado.SelectedRows.Count > 0)
            {
                FrmRegistrarCliente form = new FrmRegistrarCliente();
                form.Edit = true;  // Bandera para indicar modo EDITAR

                // Cargar los datos del cliente seleccionado en los campos del formulario
                form.txtidcliente.Text = dlistado.CurrentRow.Cells["idcliente"].Value.ToString();
                form.txtnombre.Text = dlistado.CurrentRow.Cells["nombre"].Value.ToString();
                form.txtapellidos.Text = dlistado.CurrentRow.Cells["apellidos"].Value.ToString();
                form.txtdni.Text = dlistado.CurrentRow.Cells["dni"].Value.ToString();
                form.txtrfc.Text = dlistado.CurrentRow.Cells["rfc"].Value.ToString();
                form.txttelefono.Text = dlistado.CurrentRow.Cells["telefono"].Value.ToString();

                // Establecer el estado del cliente en los RadioButton
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
                // Mostrar mensaje si no hay cliente seleccionado
                MessageBox.Show("Seleccione un cliente para editar", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // EVENTO CLICK DEL BOTÓN ELIMINAR
        // Elimina el cliente seleccionado de la base de datos después de confirmación
        // PROCESO:
        // 1. Verifica que haya un cliente seleccionado en el DataGridView
        // 2. Muestra un mensaje de confirmación al usuario
        // 3. Si el usuario confirma, llama a CNCliente.Eliminar()
        // 4. Este método ejecuta el SP speliminar_cliente
        // 5. El SP hace un DELETE en la tabla dbo.cliente WHERE idcliente = @idcliente
        // 6. Actualiza el listado para reflejar la eliminación
        private void btneliminar_Click(object sender, EventArgs e)
        {
            // Verificar que haya un cliente seleccionado
            if (dlistado.SelectedRows.Count > 0)
            {
                // Mostrar mensaje de confirmación antes de eliminar
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el cliente?", "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar al método Eliminar que ejecuta el SP speliminar_cliente
                        // El SP elimina físicamente el registro de la tabla dbo.cliente
                        string rpta = CNCliente.Eliminar(Convert.ToInt32(dlistado.CurrentRow.Cells["idcliente"].Value));

                        // Verificar si la eliminación fue exitosa
                        if (rpta == "OK")
                        {
                            MessageBox.Show("Cliente eliminado correctamente", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Actualizar el listado para reflejar los cambios en la base de datos
                            this.Listar();
                        }
                        else
                        {
                            // Mostrar mensaje de error si no se pudo eliminar
                            MessageBox.Show(rpta, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Mostrar mensaje de error en caso de excepción
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }
            }
            else
            {
                // Mostrar mensaje si no hay cliente seleccionado
                MessageBox.Show("Seleccione un cliente para eliminar", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}