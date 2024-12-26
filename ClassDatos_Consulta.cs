using Capa_Entidad_Postulantes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class ClassDatos_Consulta
    {
        private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public string ActualizarConsulta(ClassConsulta consulta)
        {
            try
            {
                conexion.Open(); // Abre la conexión a la base de datos

                // Consulta SQL para actualizar los campos de la tabla
                string query = @"UPDATE Consulta
        SET Observacion = @Observacion,
            Estado = @estado
        WHERE [Nro de Solicitud] = @codigo;";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Observacion", consulta.descripcion);
                comando.Parameters.AddWithValue("@Estado", consulta.Estado);
                comando.Parameters.AddWithValue("@Codigo", consulta.codigo);

                // Ejecuta la consulta y verifica si se actualizó algún registro
                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0 ? "Actualización realizada con éxito" : "No se encontró el registro para actualizar";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar: {ex.Message}";
            }
            finally
            {
                conexion.Close(); // Asegura que la conexión se cierre
            }
        }
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listar_consulta_()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_consulta", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_consulta(ClassConsulta obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_consulta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nro", obje.codigo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
