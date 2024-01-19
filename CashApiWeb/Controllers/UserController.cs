using CachaWebBL.Models;
using CachaWebBL.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CashApiWeb.Controllers
{
    public class UserController : ApiController
    {
        GenericServices servicio = new GenericServices();

        [HttpPost]
        public IHttpActionResult  Post([FromBody] Usuario oUsuario)
        {
            RespuestaUser resp = new RespuestaUser();
            resp = servicio.InsertaUsuario(oUsuario);
            string valor = "";
            if (resp.Registro== "1") 
            {
                valor = "OK";
            }
            else 
            {
                valor = "";
            }
            return Ok(resp);
        }

        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}