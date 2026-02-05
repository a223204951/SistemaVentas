using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    // CLASE DE DATOS - CLIENTE
    // Esta clase maneja todas las operaciones de acceso a datos relacionadas con clientes
    public class CDCliente
    {
        // PROPIEDADES DEL CLIENTE
        public int Idcliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Rfc { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public string Buscar { get; set; }


        // MÉTODO LISTAR CLIENTES
        // Obtiene todos los clientes de la base de datos ejecutando el stored procedure splistar_cliente
        // RETORNA:
        //   - DataTable con todos los registros de clientes
        //   - null en caso de error
        // BASE DE DATOS:
        //   - SP: splistar_cliente
        //   - Tabla: dbo.cliente
        //   - Operación: SELECT idcliente, nombre, apellidos, dni, rfc, telefono, estado FROM cliente ORDER BY nombre ASC
        public DataTable Listar()
        {
            DataTable resul = new DataTable("Cliente");
            SqlConnection conexion = new SqlConnection();

            try
            {
                // Configurar la conexión
                conexion.ConnectionString = Conexion.Conn;

                // Configurar el comando para ejecutar el stored procedure
                SqlCommand Cmd = new SqlCommand("splistar_cliente", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                // Usar SqlDataAdapter para llenar el DataTable con los resultados del SP
                SqlDataAdapter SqlDat = new SqlDataAdapter(Cmd);
                SqlDat.Fill(resul);  // Ejecuta el SP y llena el DataTable
            }
            catch (Exception ex)
            {
                resul = null;
                throw ex;
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return resul;
        }

        // MÉTODO GUARDAR CLIENTE
        // Inserta un nuevo cliente en la base de datos ejecutando el stored procedure spguardar_cliente
        // PARÁMETROS:
        //   - Cli: Objeto CDCliente con todos los datos del cliente a insertar
        // RETORNA:
        //   - "OK" si se insertó correctamente
        //   - Mensaje de error en caso de fallo
        // BASE DE DATOS:
        //   - SP: spguardar_cliente
        //   - Tabla: dbo.cliente
        //   - Operación: INSERT INTO cliente (nombre, apellidos, dni, rfc, telefono, estado) VALUES (...)
        public string Guardar(CDCliente Cli)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                // Abrir conexión a la base de datos
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                // Configurar el comando para ejecutar el stored procedure
                SqlCommand Cmd = new SqlCommand("spguardar_cliente", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                // Agregar parámetros del stored procedure
                Cmd.Parameters.AddWithValue("@idcliente", SqlDbType.Int).Direction = ParameterDirection.Output;  // Parámetro de salida
                Cmd.Parameters.AddWithValue("@nombre", Cli.Nombre);
                Cmd.Parameters.AddWithValue("@apellidos", Cli.Apellidos);
                Cmd.Parameters.AddWithValue("@dni", Cli.Dni);
                Cmd.Parameters.AddWithValue("@rfc", Cli.Rfc);
                Cmd.Parameters.AddWithValue("@telefono", Cli.Telefono);
                Cmd.Parameters.AddWithValue("@estado", Cli.Estado);

                // Ejecutar el stored procedure
                // ExecuteNonQuery() retorna el número de filas afectadas
                resul = Cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el registro";
            }
            catch (Exception ex)
            {
                resul = ex.Message;
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }

        // MÉTODO EDITAR CLIENTE
        // Actualiza los datos de un cliente existente ejecutando el stored procedure speditar_cliente
        // PARÁMETROS:
        //   - cli: Objeto CDCliente con todos los datos actualizados del cliente
        // RETORNA:
        //   - "OK" si se actualizó correctamente
        //   - Mensaje de error en caso de fallo
        // BASE DE DATOS:
        //   - SP: speditar_cliente
        //   - Tabla: dbo.cliente
        //   - Operación: UPDATE cliente SET nombre=@nombre, apellidos=@apellidos, ... WHERE idcliente=@idcliente
        public string Editar(CDCliente cli)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                // Abrir conexión a la base de datos
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                // Configurar el comando para ejecutar el stored procedure
                SqlCommand Cmd = new SqlCommand("speditar_cliente", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                // Agregar parámetros del stored procedure
                Cmd.Parameters.AddWithValue("@idcliente", cli.Idcliente);  // ID del cliente a actualizar
                Cmd.Parameters.AddWithValue("@nombre", cli.Nombre);
                Cmd.Parameters.AddWithValue("@apellidos", cli.Apellidos);
                Cmd.Parameters.AddWithValue("@dni", cli.Dni);
                Cmd.Parameters.AddWithValue("@rfc", cli.Rfc);
                Cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                Cmd.Parameters.AddWithValue("@estado", cli.Estado);

                // Ejecutar el stored procedure
                // ExecuteNonQuery() retorna el número de filas afectadas (debe ser 1)
                resul = Cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                resul = ex.Message;
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }

        // MÉTODO ELIMINAR CLIENTE
        // Elimina un cliente de la base de datos ejecutando el stored procedure speliminar_cliente
        // PARÁMETROS:
        //   - cli: Objeto CDCliente con el ID del cliente a eliminar
        // RETORNA:
        //   - "OK" si se eliminó correctamente
        //   - Mensaje de error en caso de fallo
        // BASE DE DATOS:
        //   - SP: speliminar_cliente
        //   - Tabla: dbo.cliente
        //   - Operación: DELETE FROM cliente WHERE idcliente = @idcliente
        public string Eliminar(CDCliente cli)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                // Abrir conexión a la base de datos
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                // Configurar el comando para ejecutar el stored procedure
                SqlCommand Cmd = new SqlCommand("speliminar_cliente", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                // Agregar parámetro del stored procedure (solo necesita el ID)
                Cmd.Parameters.AddWithValue("@idcliente", cli.Idcliente);

                // Ejecutar el stored procedure
                // ExecuteNonQuery() retorna el número de filas afectadas (debe ser 1)
                resul = Cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                resul = ex.Message;
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }

        // MÉTODO BUSCAR CLIENTE POR NOMBRE
        // Busca clientes cuyo nombre o apellidos contengan el texto especificado
        // PARÁMETROS:
        //   - cli: Objeto CDCliente con la propiedad Buscar (texto a buscar)
        // RETORNA:
        //   - DataTable con los clientes que coinciden con la búsqueda
        //   - null en caso de error
        // BASE DE DATOS:
        //   - SP: spbuscar_cliente_nombre
        //   - Tabla: dbo.cliente
        //   - Operación: SELECT * FROM cliente WHERE nombre LIKE '%@nombre%' OR apellidos LIKE '%@nombre%'
        public DataTable BuscarNombre(CDCliente cli)
        {
            DataTable resul = new DataTable("Cliente");
            SqlConnection conexion = new SqlConnection();
            try
            {
                // Configurar la conexión
                conexion.ConnectionString = Conexion.Conn;

                // Configurar el comando para ejecutar el stored procedure
                SqlCommand Cmd = new SqlCommand("spbuscar_cliente_nombre", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                // Agregar parámetro de búsqueda
                Cmd.Parameters.AddWithValue("@nombre", cli.Buscar);

                // Usar SqlDataAdapter para llenar el DataTable con los resultados del SP
                SqlDataAdapter SqlDat = new SqlDataAdapter(Cmd);
                SqlDat.Fill(resul);  // Ejecuta el SP y llena el DataTable con los resultados filtrados
            }
            catch (Exception ex)
            {
                resul = null;
                throw ex;
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }

        // MÉTODO BUSCAR CLIENTE POR DNI
        // Busca clientes cuyo DNI contenga el texto especificado
        // PARÁMETROS:
        //   - cli: Objeto CDCliente con la propiedad Buscar (texto a buscar en el DNI)
        // RETORNA:
        //   - DataTable con los clientes que coinciden con la búsqueda
        //   - null en caso de error
        // BASE DE DATOS:
        //   - SP: spbuscar_cliente_dni
        //   - Tabla: dbo.cliente
        //   - Operación: SELECT * FROM cliente WHERE dni LIKE '%@dni%'
        public DataTable BuscarDni(CDCliente cli)
        {
            DataTable resul = new DataTable("Cliente");
            SqlConnection conexion = new SqlConnection();
            try
            {
                // Configurar la conexión
                conexion.ConnectionString = Conexion.Conn;

                // Configurar el comando para ejecutar el stored procedure
                SqlCommand Cmd = new SqlCommand("spbuscar_cliente_dni", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                // Agregar parámetro de búsqueda
                Cmd.Parameters.AddWithValue("@dni", cli.Buscar);

                // Usar SqlDataAdapter para llenar el DataTable con los resultados del SP
                SqlDataAdapter SqlDat = new SqlDataAdapter(Cmd);
                SqlDat.Fill(resul);  // Ejecuta el SP y llena el DataTable con los resultados filtrados
            }
            catch (Exception ex)
            {
                resul = null;
                throw ex;
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }
    }
}