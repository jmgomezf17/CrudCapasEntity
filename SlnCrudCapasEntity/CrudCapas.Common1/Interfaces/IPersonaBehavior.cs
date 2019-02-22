using CrudCapas.Common.DTO;
using System.Collections.Generic;

namespace CrudCapas.Common.Interfaces
{
    public interface IPersonaBehavior
    {
        /// <summary>
        /// Adicionar persona
        /// </summary>
        /// <param name="persona">Persona</param>
        /// <returns>True/False</returns>
        bool AddPersona(PersonaDTO persona);

        /// <summary>
        /// Actualizar persona
        /// </summary>
        /// <param name="persona">Persona</param>
        /// <returns>True/False</returns>
        bool UpdatePersona(PersonaDTO persona);

        /// <summary>
        /// Eliminar Persona
        /// </summary>
        /// <param name="idPersona">Codigo persona</param>
        /// <returns>True/False</returns>
        bool DeletePersona(int idPersona);

        /// <summary>
        /// Consultar todas las personas
        /// </summary>
        /// <returns>Lista personas</returns>
        List<PersonaDTO> getAllPersonas();

        /// <summary>
        /// Consultar una persona
        /// </summary>
        /// <param name="persona">Datos a buscar</param>
        /// <returns>Persona</returns>
        PersonaDTO GetPersona(PersonaDTO persona);

    }
}
