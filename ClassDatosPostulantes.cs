using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capa_Entidad_Postulantes;
using System;

namespace Capa_Datos_Postulantes
{
    public class ClassDatosPostulantes
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listar_postulantes()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_postulante", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_postulantes(ClassEntidadPostulantes obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_postulante", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", obje.Nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string AgregarPostulante(ClassEntidadPostulantes obje)
        {
            string mensaje = "";
            SqlCommand cmd = new SqlCommand("AgregarPostulante", cn); // Usando la conexión ya definida
            cmd.CommandType = CommandType.StoredProcedure;

            // Usamos los valores de la clase en lugar de parámetros individuales
            cmd.Parameters.AddWithValue("@DNI", obje.Dni);
            cmd.Parameters.AddWithValue("@TipoDocumento", obje.TipoDocmuento);  // Puedes ajustar el tipo de documento
            cmd.Parameters.AddWithValue("@Modalidad", obje.Modalidad);
            cmd.Parameters.AddWithValue("@CodigoVerificacion", obje.CodigoVerificacion); // O cualquier otro valor que corresponda
            cmd.Parameters.AddWithValue("FechaIncripcion", obje.FechaInscripcion);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                mensaje = "Postulante agregado correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Error al agregar el postulante: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }
        public string AgregarDatosAdicionales(ClassEntidadPostulantes obje, out string mensajeAccion)
        {
            mensajeAccion = "";
            SqlCommand cmd = new SqlCommand("AgregarDatosAdicionales", cn); // Usando la conexión ya definida
            cmd.CommandType = CommandType.StoredProcedure;

            // Usamos los valores de la clase para los parámetros
            cmd.Parameters.AddWithValue("@DNI", obje.Dni);
            cmd.Parameters.AddWithValue("@Nombres", obje.Nombre);
            cmd.Parameters.AddWithValue("@ApellidoPaterno", obje.ApellidoPaterno);
            cmd.Parameters.AddWithValue("@ApellidoMaterno", obje.ApellidoMaterno);
            cmd.Parameters.AddWithValue("@FechaNacimiento", obje.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Celular", obje.Celular);
            cmd.Parameters.AddWithValue("@Direccion", obje.Direccion);
            cmd.Parameters.AddWithValue("@Email", obje.Email);
            cmd.Parameters.AddWithValue("@Genero", obje.Genero);
            cmd.Parameters.AddWithValue("@EstadoCivil", obje.EstadoCivil);
            cmd.Parameters.AddWithValue("@RegionNacimiento", obje.RegionNacimiento);
            cmd.Parameters.AddWithValue("@ProvinciaNacimiento", obje.ProvinciaNacimiento);
            cmd.Parameters.AddWithValue("@DistritoNacimiento", obje.DistritoNacimiento);
            cmd.Parameters.AddWithValue("@RegionDomicilio", obje.RegionDomicilio);
            cmd.Parameters.AddWithValue("@ProvinciaDomicilio", obje.ProvinciaDomicilio);
            cmd.Parameters.AddWithValue("@DistritoDomicilio", obje.DistritoDomicilio);
            cmd.Parameters.AddWithValue("@AnoEgreso", obje.AnoEgreso);
            cmd.Parameters.AddWithValue("@RegionColegio", obje.RegionColegio);
            cmd.Parameters.AddWithValue("@ProvinciaColegio", obje.ProvinciaColegio);
            cmd.Parameters.AddWithValue("@DistritoColegio", obje.DistritoColegio);
            cmd.Parameters.AddWithValue("@Colegio", obje.Colegio);
            cmd.Parameters.AddWithValue("@NombresApoderado", obje.NombresApoderado);
            cmd.Parameters.AddWithValue("@ApellidoPaternoApoderado", obje.ApellidoPaternoApoderado);
            cmd.Parameters.AddWithValue("@ApellidoMaternoApoderado", obje.ApellidoMaternoApoderado);
            cmd.Parameters.AddWithValue("@CelularApoderado", obje.CelularApoderado);

            SqlParameter outputParam = new SqlParameter("@accion", SqlDbType.VarChar, 255)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                mensajeAccion = outputParam.Value.ToString();
            }
            catch (Exception ex)
            {
                mensajeAccion = "Error al actualizar los datos: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensajeAccion;
        }
        public string ActualizarCarrerasYFotos(ClassEntidadPostulantes obje)
        {
            string mensaje = "";
            SqlCommand cmd = new SqlCommand("ActualizarCarrerasYFotos", cn); // Usando la conexión ya definida
            cmd.CommandType = CommandType.StoredProcedure;

            // Usamos los valores de la clase para los parámetros
            cmd.Parameters.AddWithValue("@DNI", obje.Dni);
            cmd.Parameters.AddWithValue("@Carrera1", obje.CarreraProfesional);
            cmd.Parameters.AddWithValue("@Carrera2", obje.SegundaCarreraProfesional);
            cmd.Parameters.AddWithValue("@FotoCara", obje.FotoCara);
            cmd.Parameters.AddWithValue("@FotoDNIAdelante", obje.FotoDNIAdelante);
            cmd.Parameters.AddWithValue("@FotoDNIAtras", obje.FotoDNIAtras);
            cmd.Parameters.AddWithValue("@Recibo", obje.Recibo);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                mensaje = "Carreras y fotos actualizadas correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar las carreras y fotos: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }


    }
}
