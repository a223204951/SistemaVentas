using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNProveedor
    {
        public static DataTable Listar()
        {
            return new CDProveedor().Listar();
        }

        public static string Guardar(string razonsocial, string dni, string rfc, string telefono, string direccion, string estado)
        {
            CDProveedor obj = new CDProveedor();

            obj.Razonsocial = razonsocial;
            obj.Dni = dni;
            obj.Rfc = rfc;
            obj.Telefono = telefono;
            obj.Direccion = direccion;
            obj.Estado = estado;

            return obj.Guardar(obj);
        }

        public static string Editar(int idproveedor, string razonsocial, string dni, string rfc, string telefono, string direccion, string estado)
        {
            CDProveedor obj = new CDProveedor();

            obj.Idproveedor = idproveedor;
            obj.Razonsocial = razonsocial;
            obj.Dni = dni;
            obj.Rfc = rfc;
            obj.Telefono = telefono;
            obj.Direccion = direccion;
            obj.Estado = estado;

            return obj.Editar(obj);
        }

        public static string Eliminar(int idproveedor)
        {
            CDProveedor obj = new CDProveedor();
            obj.Idproveedor = idproveedor;

            return obj.Eliminar(obj);
        }

        public static DataTable BuscarRazonsocial(string texto)
        {
            CDProveedor obj = new CDProveedor();
            obj.Buscar = texto;

            return obj.BuscarRazonsocial(obj);
        }

        public static DataTable BuscarDni(string texto)
        {
            CDProveedor obj = new CDProveedor();
            obj.Buscar = texto;

            return obj.BuscarDni(obj);
        }
    }
}