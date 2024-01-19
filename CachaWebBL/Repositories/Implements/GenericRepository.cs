using CachaWebBL.Data;
using CachaWebBL.Models;
using CachaWebBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaWebBL.Repositories.Implements
{
    public class GenericRepository : IGenericRepository //<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        ContextDtos inf = new ContextDtos();
        public  RespuestaUser InsertarRoles(Roles_Usuario oRoles_Usuario)
        {
            RespuestaUser success = new RespuestaUser();
            success = inf.InsertarRoles(oRoles_Usuario);
           
            return success;
        }
        public bool RegitrarTarjet(Tarjeta oTarjeta)
        {
            bool success = false;
            string resp = "";
            resp = inf.AdicionarTarjet(oTarjeta);
            if (resp == "1")
            {
                success = true;
            }
            return success;
        }
        public RespuestaUser InsertaUsuario(Usuario oUsuario) 
        {
            RespuestaUser success = new RespuestaUser();
            success = inf.InsertaUsuario(oUsuario);
            return success;
        }
        public RespuestaUser InsertEmpresa(Empresa oEmpresa)
        {
            RespuestaUser success = new RespuestaUser();
            success = inf.InsertEmpresa(oEmpresa);
            return success;
        }
    }
}

