using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNCliente
    {
        // MÉTODO LISTAR
        // QUE LLAMA AL MÉTODO LISTAR DE LA CLASE CDCLIENTE DE LA CAPADATOS
        public static DataTable Listar()
        {
            CDCliente Datos = new CDCliente();
            return Datos.Listar();
        }

        // MÉTODO GUARDAR
        // QUE LLAMA AL MÉTODO GUARDAR DE LA CLASE CDCLIENTE DE LA CAPADATOS
        public static string Guardar(string nombre, string apellidos, string rfc, string telefono, string estado)
        {
            CDCliente Datos = new CDCliente();
            Datos.Nombre = nombre;
            Datos.Apellidos = apellidos;
            Datos.Rfc = rfc;
            Datos.Telefono = telefono;
            Datos.Estado = estado;
            return Datos.Guardar(Datos);
        }

        // MÉTODO EDITAR
        // QUE LLAMA AL MÉTODO EDITAR DE LA CLASE CDCLIENTE DE LA CAPADATOS
        public static string Editar(int idcliente, string nombre, string apellidos, string rfc, string telefono, string estado)
        {
            CDCliente Datos = new CDCliente();
            Datos.Idcliente = idcliente;
            Datos.Nombre = nombre;
            Datos.Apellidos = apellidos;
            Datos.Rfc = rfc;
            Datos.Telefono = telefono;
            Datos.Estado = estado;
            return Datos.Editar(Datos);
        }

        // MÉTODO ELIMINAR
        // QUE LLAMA AL MÉTODO ELIMINAR DE LA CLASE CDCLIENTE DE LA CAPADATOS
        public static string Eliminar(int idcliente)
        {
            CDCliente Datos = new CDCliente();
            Datos.Idcliente = idcliente;
            return Datos.Eliminar(Datos);
        }

        // MÉTODO BUSCARNOMBRE
        // QUE LLAMA AL MÉTODO BUSCARNOMBRE DE LA CLASE CDCLIENTE DE LA CAPADATOS
        public static DataTable BuscarNombre(string textobuscar)
        {
            CDCliente Datos = new CDCliente();
            Datos.Buscar = textobuscar;
            return Datos.BuscarNombre(Datos);
        }

        // MÉTODO BUSCARDNI
        // QUE LLAMA AL MÉTODO BUSCARDNI DE LA CLASE CDCLIENTE DE LA CAPADATOS
        public static DataTable BuscarDni(string textobuscar)
        {
            CDCliente Datos = new CDCliente();
            Datos.Buscar = textobuscar;
            return Datos.BuscarDni(Datos);
        }
    }
}
