using System;

namespace CrudCapas.Common.DTO
{
    public class PersonaDTO
    {
        /// <summary>
        /// Identificador de persona
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// Nombre
        /// </summary>
        public string nombre { get; set; }

        /// <summary>
        /// Apellido
        /// </summary>
        public string apellido { get; set; }

        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        public DateTime? fechaNacimiento { get; set; }

        /// <summary>
        /// Identificador de la ciudad
        /// </summary>
        public int? idCiudad { get; set; }
    }
}
