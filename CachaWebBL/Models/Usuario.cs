using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaWebBL.Models
{

    public class Cliente 
    {
        public string id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipo_documento { get; set; }
        public string documento { get; set; }
        public string correo { get; set; }
        public string celular { get; set; }
        public string equipaje { get; set; }
        public DateTime fecha_registro { get; set; }
    }
    public class Usuario
    {
        public string id_usuario { get; set; }
        public string id_empresa { get; set; }
        public string id_rol { get; set; }
        public string nombre_usuario { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string ci { get; set; }
        public string email { get; set; }
        public DateTime fecha_registro { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string usuario_modificacion { get; set; }
        public string usuario_registro { get; set; }
        public string estado { get; set; }

    }
    public class Empresa 
    {
        public string id_empresa { get; set; }
        public string nombre_empresa { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public string celular { get; set; }
        public string telefono { get; set; }
        public string correo_empresa { get; set; }
        public DateTime fecha_registro { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string usuario_registro { get; set; }
        public string usuario_modificacion { get; set; }
        public string estado { get; set; }
    }
    public class Conductor 
    {
        public string id_conductor { get; set; }
        public string id_aut { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string celular { get; set; }
        public string ci { get; set; }
        public string licencia { get; set; }
        public DateTime fecha_registro { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string usuario_registro { get; set; }
        public string usuario_modificacion { get; set; }
    }
    public class Viaje 
    {
        public string id_viaje { get; set; }
        public string ciudad_origen { get; set; }
        public string ciudad_destino { get; set; }
        public string precio { get; set; }
        public DateTime fecha_salida { get; set; }
        public DateTime fecha_llegada { get; set; }
        public string hora_salida { get; set; }
        public string hora_llegada { get; set; }
        public DateTime fecha_registro { get; set; }
    }
    public class Roles_Usuario
    {
        public string tiporol { get; set; }
        public DateTime fecha_resgistro { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string usuario_registro { get; set; }
        public string usuario_modificacion { get; set; }
        public string estado { get; set; }

    }
}
