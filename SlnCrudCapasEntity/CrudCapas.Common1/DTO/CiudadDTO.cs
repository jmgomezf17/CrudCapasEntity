namespace CrudCapas.Common.DTO
{
    public class CiudadDTO
    {
        /// <summary>
        /// Identificador de la ciudad
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        public string descripcion { get; set; }

        /// <summary>
        /// Estado de la ciudad
        /// </summary>
        public bool estado { get; set; }

        /// <summary>
        /// Identificador del departamento
        /// </summary>
        public int idDepartamento { get; set; }

    }
}
