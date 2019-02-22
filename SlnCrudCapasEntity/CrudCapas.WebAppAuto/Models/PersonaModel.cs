using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudCapas.WebAppAuto.Models
{
    public class PersonaModel
    {
        /// <summary>
        /// Identificador de persona
        /// </summary>
        
        public int id { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        /// <summary>
        /// Apellido
        /// </summary>
        [DisplayName("Apellido")]
        public string apellido { get; set; }

        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        [DisplayName("Fecha")]
        public DateTime? fechaNacimiento { get; set; }

        /// <summary>
        /// Identificador de la ciudad
        /// </summary>
        [DisplayName("Ciudad")]
        public int? idCiudad { get; set; }

        [DisplayName("Ciudad")]
        public SelectList listaCiudades { get; set; } 
    }
}