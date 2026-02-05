using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    // CLASE DE CONEXIÓN A BASE DE DATOS
    // Esta clase contiene la cadena de conexión a la base de datos
    public class Conexion
    {
        // CADENA DE CONEXIÓN A SQL SERVER
        // Data Source: Nombre del servidor
        // Initial Catalog: Nombre de la base de datos
        // Integrated Security: Autenticación de Windows
        public static string Conn = "Data Source = Lani; Initial Catalog = dbventas; Integrated Security = True";
    }
}