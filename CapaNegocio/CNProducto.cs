using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNProducto
    {
        public static DataTable Listar()
        {
            CDProducto Datos = new CDProducto();
            return Datos.Listar();
        }

        public static string Guardar(string codigo, string nombre, string descripcion, DateTime fingreso, DateTime fvencimiento, double pcompra, double pventa, int stock, string estado, int idcategoria)
        {
            CDProducto Datos = new CDProducto();
            Datos.Codigo = codigo;
            Datos.Nombre = nombre;
            Datos.Descripcion = descripcion;
            Datos.Fingreso = fingreso;
            Datos.Fvencimiento = fvencimiento;
            Datos.Pcompra = pcompra;
            Datos.Pventa = pventa;
            Datos.Stock = stock;
            Datos.Estado = estado;
            Datos.Idcategoria = idcategoria;

            return Datos.Guardar(Datos);
        }

        public static string Editar(int idproducto, string codigo, string nombre, string descripcion, DateTime fingreso, DateTime fvencimiento, double pcompra, double pventa, int stock, string estado, int idcategoria)
        {
            CDProducto Datos = new CDProducto();
            Datos.Idproducto = idproducto;
            Datos.Codigo = codigo;
            Datos.Nombre = nombre;
            Datos.Descripcion = descripcion;
            Datos.Fingreso = fingreso;
            Datos.Fvencimiento = fvencimiento;
            Datos.Pcompra = pcompra;
            Datos.Pventa = pventa;
            Datos.Stock = stock;
            Datos.Estado = estado;
            Datos.Idcategoria = idcategoria;

            return Datos.Editar(Datos);
        }

        public static string Eliminar(int idproducto)
        {
            CDProducto Datos = new CDProducto();
            Datos.Idproducto = idproducto;
            return Datos.Eliminar(Datos);
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            CDProducto Datos = new CDProducto();
            Datos.Buscar = textobuscar;
            return Datos.BuscarNombre(Datos);
        }

        public static DataTable BuscarCodigo(string textobuscar)
        {
            CDProducto Datos = new CDProducto();
            Datos.Buscar = textobuscar;
            return Datos.BuscarCodigo(Datos);
        }
    }
}
