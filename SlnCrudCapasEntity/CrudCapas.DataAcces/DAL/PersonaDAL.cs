using CrudCapas.Common.DTO;
using CrudCapas.Common.Interfaces;
using CrudCapas.DataAcces.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CrudCapas.DataAcces.DAL
{
    public class PersonaDAL : IPersonaBehavior
    {
        /// <summary>
        /// Propiedad del contexto
        /// </summary>
        PruebaCapasEntities contexto;

        /// <summary>
        /// Adicionar una persona
        /// </summary>
        /// <param name="persona">Objeto persona</param>
        /// <returns>True/False</returns>
        public bool AddPersona(PersonaDTO persona)
        {
            bool susses = false;

            using (contexto = new PruebaCapasEntities())
            {
                Persona perNew = this.personaDTOtoEF(persona);
                contexto.Persona.Add(perNew);
                contexto.SaveChanges();

                susses = true;
            }
            return susses;
        }

        /// <summary>
        /// Eliminar una persona
        /// </summary>
        /// <param name="idPersona">Condigo de la persona</param>
        /// <returns>True/False</returns>
        public bool DeletePersona(int idPersona)
        {
            bool susses = false;

            using (contexto = new PruebaCapasEntities())
            {
                // Obtener personadb
                Persona personaDB = contexto.Persona.SingleOrDefault(p => p.id == idPersona);

                if (personaDB != null)
                {
                    contexto.Persona.Remove(personaDB);
                    contexto.SaveChanges();

                    susses = true;
                }
            }
            return susses;
        }

        /// <summary>
        /// Buscar todas las personas
        /// </summary>
        /// <returns>Lista Personas</returns>
        public List<PersonaDTO> getAllPersonas()
        {
            List<PersonaDTO> lista = new List<PersonaDTO>();

            using (contexto = new PruebaCapasEntities()) {
                lista = contexto.Persona.Select(p => new PersonaDTO() {
                    id = p.id,
                    nombre = p.nombre,
                    apellido = p.apellido,
                    fechaNacimiento = p.fechaNacimiento,
                    idCiudad = p.idCiudad
                }).ToList();
            }

            return lista;
        }

        /// <summary>
        /// Buscar una persona
        /// </summary>
        /// <param name="persona">Datos de busqueda</param>
        /// <returns>Persona</returns>
        public PersonaDTO GetPersona(PersonaDTO persona)
        {
            PersonaDTO personaFind = new PersonaDTO();

            using (contexto = new PruebaCapasEntities()) {
                personaFind = (from per in contexto.Persona
                               where (per.id == persona.id || persona.id == 0 )
                               where (per.nombre == persona.nombre || persona.nombre == null )
                               where (per.apellido == persona.apellido || persona.apellido == null)
                               where (per.fechaNacimiento == persona.fechaNacimiento || persona.fechaNacimiento == null)
                               where (per.idCiudad == persona.idCiudad || persona.idCiudad == null)
                               select new PersonaDTO {
                                   id = per.id,
                                   nombre = per.nombre,
                                   apellido = per.apellido,
                                   fechaNacimiento = per.fechaNacimiento,
                                   idCiudad = per.idCiudad
                               }
                           ).SingleOrDefault();

                return personaFind;
            }
        }

        /// <summary>
        /// Actualizar una persona
        /// </summary>
        /// <param name="persona">Persona</param>
        /// <returns>True/False</returns>
        public bool UpdatePersona(PersonaDTO persona)
        {
            bool susses = false;

            using (contexto = new PruebaCapasEntities())
            {
                // Obtener personadb
                Persona personaDB = contexto.Persona.SingleOrDefault(p => p.id == persona.id);

                if (personaDB != null)
                {
                    this.personaUpdate(persona, ref personaDB);
                    contexto.SaveChanges();

                    susses = true;
                }
            }
            return susses;
        }

        /// <summary>
        /// Convertir DTO a EF
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        private Persona personaDTOtoEF(PersonaDTO persona)
        {
            Persona perNew;

                 perNew = new Persona
                {
                    id = persona.id,
                    nombre = persona.nombre,
                    apellido = persona.apellido,
                    fechaNacimiento = persona.fechaNacimiento,
                    idCiudad = persona.idCiudad
                };

            return perNew;
        }

        /// <summary>
        /// Setear persona a modificar
        /// </summary>
        /// <param name="persona">Datos persona a modificar</param>
        /// <param name="personaDB">Persona de la base</param>
        private void personaUpdate(PersonaDTO persona, ref Persona personaDB)
        {
            personaDB.id = persona.id > 0 ? persona.id : personaDB.id;
            personaDB.nombre = persona.nombre != null ? persona.nombre : personaDB.nombre;
            personaDB.apellido = persona.apellido != null ? persona.apellido : personaDB.apellido;
            personaDB.fechaNacimiento = string.IsNullOrEmpty(persona.fechaNacimiento.Value.ToString()) ? personaDB.fechaNacimiento : persona.fechaNacimiento;
            personaDB.idCiudad = persona.idCiudad > 0 ? persona.idCiudad : personaDB.id;
        }
    }
}
