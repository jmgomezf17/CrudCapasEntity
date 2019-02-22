using CrudCapas.Bussiness.BL;
using CrudCapas.Common.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudCapas.ApiRest.Controllers
{
    public class PersonaController : ApiController
    {
        /// <summary>
        /// Propiedad de Bussiness
        /// </summary>
        private PersonaBL personaBL = new PersonaBL();

        /// <summary>
        /// Consultar todas las personas
        /// </summary>
        /// <returns>ResponseMessage</returns>
        [Route("api/persona/all")]
        [HttpGet]
        public HttpResponseMessage getAllPersonas()
        {
            List<PersonaDTO> lista = new List<PersonaDTO>();

            try
            {
                lista = this.personaBL.getAllPersonas();
                if (lista != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lista);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Personas No Content ");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);  
            }
        }

        /// <summary>
        /// Consultar persona
        /// </summary>
        /// <param name="persona">Datos de persona</param>
        /// <returns>ResponseMessage</returns>
        [Route("api/persona/getPersona")]
        [HttpPost]
        public HttpResponseMessage getPersona(PersonaDTO persona)
        {
            PersonaDTO personaFind = new PersonaDTO();

            if (persona == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                personaFind = this.personaBL.GetPersona(persona);
                if (personaFind != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, personaFind);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Persona No Content");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Adicionar persona
        /// </summary>
        /// <param name="persona">Persona</param>
        /// <returns>ResponseMessage</returns>
        [Route("api/persona/addPersona")]
        [HttpPost]
        public HttpResponseMessage addPersona(PersonaDTO persona)
        {
            bool respuesta = false;

            try
            {
                respuesta = this.personaBL.AddPersona(persona);
                if (respuesta == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, respuesta);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Error al crear persona");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Actualizar persona
        /// </summary>
        /// <param name="persona">Persona</param>
        /// <returns>ResponseMessage</returns>
        [Route("api/persona/updatePersona")]
        [HttpPut]
        public HttpResponseMessage updatePersona(PersonaDTO persona)
        {
            bool respuesta = false;

            try
            {
                respuesta = this.personaBL.UpdatePersona(persona);
                if (respuesta == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, respuesta);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Error al modificar persona");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Eliminar persona
        /// </summary>
        /// <param name="idPersona">Codigo persona</param>
        /// <returns>ResponseMessage</returns>
        [Route("api/persona/deletePersona/{idPersona}")]
        [HttpDelete]
        public HttpResponseMessage deletePersona(int idPersona)
        {
            bool respuesta = false;

            try
            {
                respuesta = this.personaBL.DeletePersona(idPersona);
                if (respuesta == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, respuesta);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Error al eliminar persona");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
