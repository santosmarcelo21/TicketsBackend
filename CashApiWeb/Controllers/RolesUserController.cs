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
    public class RolesUserController : ApiController
    {
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

        // POST api/<controller>
        GenericServices servicio = new GenericServices();

        [HttpPost]
        public IHttpActionResult Post([FromBody] Roles_Usuario oRoles_Usuario)
        {
            RespuestaUser resp = new RespuestaUser();
            resp = servicio.InsertarRoles(oRoles_Usuario);
            string valor = "";
            if (resp.Registro == "1")
            {
                valor = "OK";
            }
            else
            {
                valor = "";
            }
            return Ok(resp);
        }


        // PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}