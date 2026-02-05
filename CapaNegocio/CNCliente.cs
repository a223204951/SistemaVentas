using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    // CLASE DE NEGOCIO - CLIENTE
    // Esta clase contiene la lógica de negocio y valida las operaciones relacionadas con clientes
    // Actúa como intermediario entre la capa de presentación y la capa de datos
    public class CNCliente
    {
        // MÉTODO PARA GUARDAR UN NUEVO CLIENTE
        // Parámetros: todos los datos del cliente a registrar (en orden del SP)
        // Retorna: "OK" si se guardó correctamente, caso contrario retorna mensaje de error
        public static string Guardar(string nombre, string apellidos, string dni, string rfc, string telefono, string estado)
        {
            CDCliente Datos = new CDCliente();
            Datos.Nombre = nombre;
            Datos.Apellidos = apellidos;
            Datos.Dni = dni;
            Datos.Rfc = rfc;
            Datos.Telefono = telefono;
            Datos.Estado = estado;

            return Datos.Guardar(Datos);
        }

        // MÉTODO PARA EDITAR UN CLIENTE EXISTENTE
        // Parámetros: id del cliente y todos los datos a actualizar (en orden del SP)
        // Retorna: "OK" si se actualizó correctamente, caso contrario retorna mensaje de error
        public static string Editar(int idcliente, string nombre, string apellidos, string dni, string rfc, string telefono, string estado)
        {
            CDCliente Datos = new CDCliente();
            Datos.Idcliente = idcliente;
            Datos.Nombre = nombre;
            Datos.Apellidos = apellidos;
            Datos.Dni = dni;
            Datos.Rfc = rfc;
            Datos.Telefono = telefono;
            Datos.Estado = estado;

            return Datos.Editar(Datos);
        }

        // MÉTODO PARA LISTAR TODOS LOS CLIENTES
        // Retorna: DataTable con todos los registros de clientes
        public static DataTable Listar()
        {
            return new CDCliente().Listar();
        }

        // MÉTODO PARA ELIMINAR UN CLIENTE
        // Parámetro: id del cliente a eliminar
        // Retorna: "OK" si se eliminó correctamente, caso contrario retorna mensaje de error
        public static string Eliminar(int idcliente)
        {
            CDCliente Datos = new CDCliente();
            Datos.Idcliente = idcliente;
            return Datos.Eliminar(Datos);
        }

        // MÉTODO PARA BUSCAR CLIENTES POR NOMBRE
        // Parámetro: texto a buscar en el nombre
        // Retorna: DataTable con los clientes que coinciden con la búsqueda
        public static DataTable BuscarNombre(string buscar)
        {
            CDCliente Datos = new CDCliente();
            Datos.Buscar = buscar;
            return Datos.BuscarNombre(Datos);
        }

        // MÉTODO PARA BUSCAR CLIENTES POR DNI
        // Parámetro: texto a buscar en el DNI
        // Retorna: DataTable con los clientes que coinciden con la búsqueda
        public static DataTable BuscarDni(string buscar)
        {
            CDCliente Datos = new CDCliente();
            Datos.Buscar = buscar;
            return Datos.BuscarDni(Datos);
        }
    }
}