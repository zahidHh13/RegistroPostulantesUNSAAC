using System;


namespace Capa_Entidad_Postulantes
{
    //DECLARACIÓN DE VARIABLES 
    public class ClassEntidadPostulantes
    {
        public string Codigo { get; set; }
        public string TipoDocmuento { get; set; }
        public string Dni { get; set; }
        public string CodigoVerificacion { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        
        public string RegionNacimiento { get; set; }
        public string ProvinciaNacimiento { get; set; }
        public string DistritoNacimiento { get; set; }
        public string RegionDomicilio { get; set; }
        public string ProvinciaDomicilio { get; set; }
        public string DistritoDomicilio { get; set; }
        public string AnoEgreso { get; set; }
        public string RegionColegio { get; set; }
        public string ProvinciaColegio { get; set; }
        public string DistritoColegio { get; set; }
        public string Colegio { get; set; }
        public string NombresApoderado { get; set; }
        public string ApellidoPaternoApoderado { get; set; }
        public string ApellidoMaternoApoderado { get; set; }
        public string CelularApoderado { get; set; }
        public string Modalidad { get; set; }
        public string CarreraProfesional { get; set; }
        public string SegundaCarreraProfesional { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public byte[] FotoCara { get; set; }
        public byte[] FotoDNIAdelante { get; set; }
     
        public byte[] FotoDNIAtras { get; set; }
        public byte[] Recibo { get; set; }
    }


    //Para subir la foto

    //PARA subir elemento pdf 
}
