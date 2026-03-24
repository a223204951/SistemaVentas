using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNEmpleado
    {
        public static DataTable Listar()
        {
            return new CDEmpleado().Listar();
        }

        public static string Guardar(string nombre, string apellidos, string dni,
            string telefono, string direccion, string estado)
        {
            CDEmpleado obj = new CDEmpleado();

            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Dni = dni;
            obj.Telefono = telefono;
            obj.Direccion = direccion;
            obj.Estado = estado;

            return obj.Guardar(obj);
        }

        public static string Editar(int idempleado, string nombre, string apellidos,
            string dni, string telefono, string direccion, string estado)
        {
            CDEmpleado obj = new CDEmpleado();

            obj.Idempleado = idempleado;
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Dni = dni;
            obj.Telefono = telefono;
            obj.Direccion = direccion;
            obj.Estado = estado;

            return obj.Editar(obj);
        }

        public static string Eliminar(int idempleado)
        {
            CDEmpleado obj = new CDEmpleado();
            obj.Idempleado = idempleado;
            return obj.Eliminar(obj);
        }

        public static DataTable BuscarNombre(string texto)
        {
            CDEmpleado obj = new CDEmpleado();
            obj.Buscar = texto;
            return obj.BuscarNombre(obj);
        }

        public static DataTable BuscarDni(string texto)
        {
            CDEmpleado obj = new CDEmpleado();
            obj.Buscar = texto;
            return obj.BuscarDni(obj);
        }
    }
}