using CachaWebBL.Data;
using CachaWebBL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaWebBL.DTOs
{
    public class ContextDtos
    {
        CashConext contexto = new CashConext();

        static string GenerateCode(string code)
        {
            int p_CodeLength = code.Length;
            string result = "";
            // Nuestro patrón de caracteres para formar el código
            string pattern = "0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            // Creamos una instancia del generador de números aleatorios
            // cogemos como semilla los Ticks de reloj de esta forma nos 
            // aseguramos de no generar códigos con la misma semilla.
            Random myRndGenerator = new Random((int)DateTime.Now.Ticks);
            // Procedemos a conformar el código
            for (int i = 0; i < p_CodeLength; i++)
            {
                // Obtenemos un número aleatorio que se corresponde con una
                // posición dentro del pattern.
                int mIndex = myRndGenerator.Next(pattern.Length);
                // Vamos formando el código
                result += pattern[mIndex];
            }

            return result;
        }
        public RespuestaUser InsertarRoles(Roles_Usuario oRoles_Usuario)
        {
            RespuestaUser valor = new RespuestaUser();
            try
            {
                contexto.Abrir_Conexion();
                SqlCommand cmd = new SqlCommand("[dbo].[insert_roles]", contexto.Conn);
                cmd.Parameters.AddWithValue("@tiporol", oRoles_Usuario.tiporol);
                cmd.Parameters.AddWithValue("@fecha_registro", oRoles_Usuario.fecha_resgistro);
                cmd.Parameters.AddWithValue("@usuario_modificacion", oRoles_Usuario.usuario_modificacion);
                cmd.Parameters.AddWithValue("@usuario_registro", oRoles_Usuario.usuario_registro);
                cmd.Parameters.AddWithValue("@estado", oRoles_Usuario.estado);
                cmd.CommandType = CommandType.StoredProcedure;

                var errorMsgParam = cmd.Parameters.Add(new SqlParameter("@Msg", SqlDbType.NVarChar, -1));
                errorMsgParam.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var errorMsgResult = cmd.Parameters["@Msg"].Value;
                valor.Registro = errorMsgResult.ToString();
            }
            catch (Exception x)
            {
                string b = x.Message.ToString();
            }
            return valor;
        }
        public string AdicionarTarjet(Tarjeta oTarjeta)
        {
            string valor = "";
            try
            {
                contexto.Abrir_Conexion();
                SqlCommand cmd = new SqlCommand("[dbo].[InserTarjeta]", contexto.Conn);
                cmd.Parameters.AddWithValue("@empresatarjeta", oTarjeta.empresatarjeta);
                cmd.Parameters.AddWithValue("@numerotarjeta", oTarjeta.numerotarjeta);
                cmd.Parameters.AddWithValue("@fechavencimientarjeta", oTarjeta.fechavencimientarjeta);
                cmd.Parameters.AddWithValue("@tipotarjeta", oTarjeta.tipotarjeta);
                cmd.Parameters.AddWithValue("@codigotarjeta", oTarjeta.codigotarjeta);
                cmd.Parameters.AddWithValue("@codsuario", oTarjeta.codsuario);
                cmd.Parameters.AddWithValue("@usuario", oTarjeta.usuario);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable objdataset = new DataTable();
                adapter.Fill(objdataset);
                contexto.CerrarConexion();
                foreach (DataRow row in objdataset.Rows)
                {
                    valor = row[0].ToString();
                }
            }
            catch (Exception x)
            {
                string b = x.Message.ToString();
            }
            return valor;
        }
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            //contexto.Abrir_Conexion();
            //SqlCommand cmd = new SqlCommand("ListaUser", contexto.Conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //try
            //{
            //    cmd.ExecuteNonQuery();
            //    using (SqlDataReader dr = cmd.ExecuteReader())
            //    {

            //        while (dr.Read())
            //        {
            //            oListaUsuario.Add(new Usuario()
            //            {
            //                usuario = dr["usuario"].ToString(),
            //                nombre = dr["nombre"].ToString(),
            //                apellido = dr["apellido"].ToString(),
            //                //codsuario = dr["idtarjeta"].ToString(),
            //            });
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    return oListaUsuario;
            //}
            return oListaUsuario;
        }
        public RespuestaUser  InsertaUsuario(Usuario oUsuario)
        {
            RespuestaUser valor = new RespuestaUser();
            string codUserReserva = "";
            codUserReserva= oUsuario.ci+Guid.NewGuid().ToString();
            try
            {
                contexto.Abrir_Conexion();
                SqlCommand cmd = new SqlCommand("[dbo].[InserUser]", contexto.Conn);
                cmd.Parameters.AddWithValue("@id_usuario", codUserReserva);
                cmd.Parameters.AddWithValue("@id_empresa", oUsuario.id_empresa);
                cmd.Parameters.AddWithValue("@id_rol", oUsuario.id_rol);
                cmd.Parameters.AddWithValue("@nombre_usuario", oUsuario.nombre_usuario);
                cmd.Parameters.AddWithValue("@password", oUsuario.password);
                cmd.Parameters.AddWithValue("@apellido", oUsuario.apellido);
                cmd.Parameters.AddWithValue("@ci", oUsuario.ci);
                cmd.Parameters.AddWithValue("@email", oUsuario.email);
                cmd.Parameters.AddWithValue("@usuario_modificacion", oUsuario.usuario_modificacion);
                cmd.Parameters.AddWithValue("@usuario_registro", oUsuario.usuario_registro);
                cmd.Parameters.AddWithValue("@estado", oUsuario.estado);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //adapter.SelectCommand = cmd;
                //DataTable objdataset = new DataTable();
                //adapter.Fill(objdataset);
                //contexto.CerrarConexion();
                //foreach (DataRow row in objdataset.Rows)
                //{
                //    valor = row[0].ToString();
                //}
                var errorMsgParam = cmd.Parameters.Add(new SqlParameter("@Msg", SqlDbType.NVarChar, -1));
                errorMsgParam.Direction = ParameterDirection.Output;
                var processIdParam = cmd.Parameters.Add(new SqlParameter("@processId", SqlDbType.NVarChar, -1));
                processIdParam.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var errorMsgResult = cmd.Parameters["@Msg"].Value;
                valor.Registro = errorMsgResult.ToString();
                var processIDResult = cmd.Parameters["@processId"].Value;
                valor.Id = processIDResult.ToString();
            }
            catch (Exception x)
            {
                string b = x.Message.ToString();
            }
            return valor;
        }
        public RespuestaUser InsertEmpresa(Empresa oEmpresa)
        {
            RespuestaUser valor = new RespuestaUser();
            string codUserReserva = "";
            codUserReserva = oEmpresa.nit + Guid.NewGuid().ToString();
            try
            {
                contexto.Abrir_Conexion();
                SqlCommand cmd = new SqlCommand("[dbo].[Inserta_Enpresa]", contexto.Conn);
                cmd.Parameters.AddWithValue("@id_empresa", codUserReserva);
                cmd.Parameters.AddWithValue("@nombre_empresa", oEmpresa.nombre_empresa);
                cmd.Parameters.AddWithValue("@nit", oEmpresa.nit);
                cmd.Parameters.AddWithValue("@direccion", oEmpresa.direccion);
                cmd.Parameters.AddWithValue("@telefono", oEmpresa.telefono);
                cmd.Parameters.AddWithValue("@correo_empresa", oEmpresa.correo_empresa);
                cmd.Parameters.AddWithValue("@fecha_registro", oEmpresa.fecha_registro);
                cmd.Parameters.AddWithValue("@fecha_modificacion", oEmpresa.fecha_modificacion);
                cmd.Parameters.AddWithValue("@usuario_modificacion", oEmpresa.usuario_modificacion);
                cmd.Parameters.AddWithValue("@usuario_registro", oEmpresa.usuario_registro);
                cmd.Parameters.AddWithValue("@estado", oEmpresa.estado);
                cmd.CommandType = CommandType.StoredProcedure;
                var errorMsgParam = cmd.Parameters.Add(new SqlParameter("@Msg", SqlDbType.NVarChar, -1));
                errorMsgParam.Direction = ParameterDirection.Output;
                var processIdParam = cmd.Parameters.Add(new SqlParameter("@processId", SqlDbType.NVarChar, -1));
                processIdParam.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var errorMsgResult = cmd.Parameters["@Msg"].Value;
                valor.Registro = errorMsgResult.ToString();
                var processIDResult = cmd.Parameters["@processId"].Value;
                valor.Id = processIDResult.ToString();
            }
            catch (Exception x)
            {
                string b = x.Message.ToString();
            }
            return valor;
        }
    }
}
