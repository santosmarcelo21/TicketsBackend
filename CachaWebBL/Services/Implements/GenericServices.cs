using CachaWebBL.Models;
using CachaWebBL.Repositories;
using CachaWebBL.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaWebBL.Services.Implements
{
    public class GenericServices: IGenericServices //<TEntity> : IGenericServices<TEntity> where TEntity : class
    {
        //private IGenericRepository<TEntity> genericRepository;
        //public async Task<TEntity> Insert(TEntity entity) 
        //{
        //    return await genericRepository.Insert(entity);
        //}
        GenericRepository reposi = new GenericRepository();
        public RespuestaUser InsertarRoles(Roles_Usuario oRoles_Usuario)
        {
            RespuestaUser success = new RespuestaUser();
            try
            { 
                success= reposi.InsertarRoles(oRoles_Usuario);
            }
            catch (Exception e)
            {
                //if (ControladorExcepciones.ControlarExcepcion(exFuncional, PoliticasEnum.Servicios))
                //    throw new FaultException<FaultFunctionalException>(new FaultFunctionalException(exFuncional.Message), new FaultReason(exFuncional.Message), new FaultCode("Server"));
            }
            return success;
        }
        public bool RegitrarTarjet(Tarjeta oTarjeta)
        {
            bool success = false;
            try
            {
                success = reposi.RegitrarTarjet(oTarjeta);
            }
            catch (Exception e)
            {
                //if (ControladorExcepciones.ControlarExcepcion(exFuncional, PoliticasEnum.Servicios))
                //    throw new FaultException<FaultFunctionalException>(new FaultFunctionalException(exFuncional.Message), new FaultReason(exFuncional.Message), new FaultCode("Server"));
            }
            return success;
        }
        public RespuestaUser InsertaUsuario(Usuario oUsuario)
        {
            RespuestaUser resp = new RespuestaUser();
            try
            {
                resp = reposi.InsertaUsuario(oUsuario);
            }
            catch (Exception e)
            {
                //if (ControladorExcepciones.ControlarExcepcion(exFuncional, PoliticasEnum.Servicios))
                //    throw new FaultException<FaultFunctionalException>(new FaultFunctionalException(exFuncional.Message), new FaultReason(exFuncional.Message), new FaultCode("Server"));
            }
            return resp;
        }
        public RespuestaUser InsertEmpresa(Empresa oEmpresa)
        {
            RespuestaUser resp = new RespuestaUser();
            try
            {
                resp = reposi.InsertEmpresa(oEmpresa);
            }
            catch (Exception e)
            {
                //if (ControladorExcepciones.ControlarExcepcion(exFuncional, PoliticasEnum.Servicios))
                //    throw new FaultException<FaultFunctionalException>(new FaultFunctionalException(exFuncional.Message), new FaultReason(exFuncional.Message), new FaultCode("Server"));
            }
            return resp;
        }
    }
}
