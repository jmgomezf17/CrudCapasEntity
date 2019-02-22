using CrudCapas.Common.DTO;
using CrudCapas.Common.Interfaces;
using CrudCapas.DataAcces.DAL;
using System;
using System.Collections.Generic;

namespace CrudCapas.Bussiness.BL
{
    public class PersonaBL : IPersonaBehavior
    {
        /// <summary>
        /// Propiedad de persona Bussiness
        /// </summary>
        private PersonaDAL personaDAL = new PersonaDAL();

        /// <summary>
        /// Adicionar persona
        /// </summary>
        /// <param name="persona">Datos de la persona</param>
        /// <returns>True/False</returns>
        public bool AddPersona(PersonaDTO persona)
        {
            try
            {
                return this.personaDAL.AddPersona(persona);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Eliminar persona
        /// </summary>
        /// <param name="idPersona">Codigo de la persona</param>
        /// <returns>True/False</returns>
        public bool DeletePersona(int idPersona)
        {
            try
            {
                return this.personaDAL.DeletePersona(idPersona);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Consultar todas las personas
        /// </summary>
        /// <returns>Lista de personas</returns>
        public List<PersonaDTO> getAllPersonas()
        {
            List<PersonaDTO> lista = new List<PersonaDTO>();

            try
            {
                return this.personaDAL.getAllPersonas();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Consultar persona
        /// </summary>
        /// <param name="persona">datos de persona</param>
        /// <returns>Persona</returns>
        public PersonaDTO GetPersona(PersonaDTO persona)
        {
            PersonaDTO personaFind = new PersonaDTO();
            try
            {
                return this.personaDAL.GetPersona(persona);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualizar persona
        /// </summary>
        /// <param name="persona">Persona</param>
        /// <returns>True/False</returns>
        public bool UpdatePersona(PersonaDTO persona)
        {
            try
            {
                return this.personaDAL.UpdatePersona(persona);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
