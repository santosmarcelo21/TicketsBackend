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
    public class CardController : ApiController
    {

        GenericServices servicio = new GenericServices();
        [HttpPost]
        public IHttpActionResult Post([FromBody] Tarjeta oTarjeta)
        {
            string valor = "";
            if (servicio.RegitrarTarjet(oTarjeta) == true)
            {
                valor = "OK";
            }
            else
            {
                valor = "";
            }
            return Ok(valor);
        }
    }
}