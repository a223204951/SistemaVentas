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
    public partial class FrmListadoProveedor : Form
    {
        public FrmListadoProveedor()
        {
            InitializeComponent();
        }

        private void FrmListadoProveedor_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        public void Mostrar()
        {
            dlistado.DataSource = CNProveedor.Listar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (rbtnrazonsocial.Checked)
                dlistado.DataSource = CNProveedor.BuscarRazonsocial(txtbuscar.Text);
            else
                dlistado.DataSource = CNProveedor.BuscarDni(txtbuscar.Text);
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FrmRegistrarProveedor f = new FrmRegistrarProveedor();
            f.Insert = true;
            f.Show();
            this.Hide();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            FrmRegistrarProveedor f = new FrmRegistrarProveedor();
            f.Edit = true;

            f.txtidproveedor.Text = dlistado.CurrentRow.Cells["idproveedor"].Value.ToString();
            f.txtrazonsocial.Text = dlistado.CurrentRow.Cells["razonsocial"].Value.ToString();
            f.txtdni.Text = dlistado.CurrentRow.Cells["dni"].Value.ToString();

            f.Show();
            this.Hide();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            string id = dlistado.CurrentRow.Cells["idproveedor"].Value.ToString();
            CNProveedor.Eliminar(Convert.ToInt32(id));
            Mostrar();
        }
    }
}
