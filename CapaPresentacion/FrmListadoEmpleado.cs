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
    public partial class FrmListadoEmpleado : Form
    {
        public FrmListadoEmpleado()
        {
            InitializeComponent();
        }

        private void FrmListadoEmpleado_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Mostrar();

        }
        public void Mostrar()
        {
            dlistado.DataSource = CNEmpleado.Listar();
        }

        public void BuscarNombre()
        {
            dlistado.DataSource = CNEmpleado.BuscarNombre(txtbuscar.Text);
        }

        public void BuscarDni()
        {
            dlistado.DataSource = CNEmpleado.BuscarDni(txtbuscar.Text);
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (rbtnnombre.Checked) BuscarNombre();
            else if (rbtndni.Checked) BuscarDni();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FrmRegistrarEmpleado form = new FrmRegistrarEmpleado();
            form.Insert = true;
            form.Show();
            this.Hide();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            FrmRegistrarEmpleado form = new FrmRegistrarEmpleado();
            form.Edit = true;

            form.txtidempleado.Text = dlistado.CurrentRow.Cells["idempleado"].Value.ToString();
            form.txtnombre.Text = dlistado.CurrentRow.Cells["nombre"].Value.ToString();
            form.txtapellidos.Text = dlistado.CurrentRow.Cells["apellidos"].Value.ToString();
            form.txtdni.Text = dlistado.CurrentRow.Cells["dni"].Value.ToString();
            form.txttelefono.Text = dlistado.CurrentRow.Cells["telefono"].Value.ToString();
            form.txtdireccion.Text = dlistado.CurrentRow.Cells["direccion"].Value.ToString();

            form.Show();
            this.Hide();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dlistado.SelectedRows.Count > 0)
            {
                string id = dlistado.CurrentRow.Cells["idempleado"].Value.ToString();
                CNEmpleado.Eliminar(Convert.ToInt32(id));
                Mostrar();
            }
        }
    }
}
