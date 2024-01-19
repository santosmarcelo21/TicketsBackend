using CachaWebBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaWebBL.Services
{
    public interface IGenericServices//<TEntity> where TEntity : class
    {
        //Task<TEntity> Insert(TEntity entity);

        RespuestaUser InsertarRoles(Roles_Usuario oRoles_Usuario);
        RespuestaUser InsertaUsuario(Usuario oUsuario);
        RespuestaUser InsertEmpresa(Empresa oEmpresa);
        bool RegitrarTarjet(Tarjeta oTarjeta);
    }
}
