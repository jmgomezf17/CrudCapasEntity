using CrudCapas.Common.DTO;
using CrudCapas.WebAppAuto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CrudCapas.WebAppAuto.Controllers
{
    public class PersonaController : Controller
    {

        private string urlApiRest = "http://localhost:52569/";

        private HttpClient httpClient = new HttpClient();


        public ActionResult Index()
        {
            List<PersonaModel> listaPersonas = new List<PersonaModel>();

            try
            {
                //HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
                //response.EnsureSuccessStatusCode();
                //string responseBody = await response.Content.ReadAsStringAsync();

                //HttpResponseMessage response = await client.GetAsync(path);
                //if (response.IsSuccessStatusCode)
                //{
                //    product = await response.Content.ReadAsAsync<Product>();
                //}

                string response = this.httpClient.GetStringAsync(new Uri(this.urlApiRest + "api/persona/all")).Result;
                listaPersonas = this.ConvertirJSONaListaModelo<PersonaModel>(response);
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return View(listaPersonas);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            PersonaModel personaUpd;

            PersonaModel persona = new PersonaModel {
                id = Convert.ToInt32(id)
            };

            string objetoSerializado = JsonConvert.SerializeObject(persona);

            try
            {
                HttpContent httpContent = new StringContent(objetoSerializado, Encoding.UTF8, "application/json");

                HttpResponseMessage response = this.httpClient.PostAsync(this.urlApiRest + "api/persona/getPersona", httpContent).Result;
                HttpStatusCode estadoRespuesta = response.EnsureSuccessStatusCode().StatusCode;
                string respuesta = response.Content.ReadAsStringAsync().Result;

                personaUpd = ConvertirJSONaModelo<PersonaModel>(respuesta);
            }
            catch (Exception)
            {
                throw;
            }

            return View(personaUpd);
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            PersonaModel personaUpd;

            PersonaModel persona = new PersonaModel
            {
                id = Convert.ToInt32(id)
            };

            string objetoSerializado = JsonConvert.SerializeObject(persona);

            try
            {
                HttpContent httpContent = new StringContent(objetoSerializado, Encoding.UTF8, "application/json");

                HttpResponseMessage response = this.httpClient.PostAsync(this.urlApiRest + "api/persona/getPersona", httpContent).Result;
                HttpStatusCode estadoRespuesta = response.EnsureSuccessStatusCode().StatusCode;
                string respuesta = response.Content.ReadAsStringAsync().Result;

                personaUpd = ConvertirJSONaModelo<PersonaModel>(respuesta);
            }
            catch (Exception)
            {
                throw;
            }

            return View(personaUpd);
        }

        public List<T> ConvertirJSONaListaModelo<T>(string response) {
            List<T> lista = new List<T>();
            lista = JsonConvert.DeserializeObject<List<T>>(response);
            return lista;
        }

        public T ConvertirJSONaModelo<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}