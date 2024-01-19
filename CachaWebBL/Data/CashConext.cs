using CachaWebBL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace CachaWebBL.Data
{
    public class CashConext
    {
        public SqlCommand cmd;
        public SqlConnection Conn;
        public string Conexion_uno = "";
        public void Abrir_Conexion()
        {
            try
            {
                //Conexion_uno = "Data Source = BCRITR00; Initial Catalog = APPSEGDB; Integrated Security = True";
                var appSettings = ConfigurationManager.AppSettings;
                //string Server = appSettings["Server"].ToString();
                //string catalog = appSettings["Catalog"].ToString();
                //string user = appSettings["User"].ToString();
                //string password_ky = appSettings["Password"].ToString();
                //string password = DecryptKey(password_ky);
                Conexion_uno = @"Data Source=.;Initial Catalog=CASHSBD;Integrated Security=True";
                    //"Data Source=" + Server + "; Initial Catalog=" + catalog + " ;User ID=" + user + " ;Password=" + password + "; Trusted_Connection = False;"; //ConfigurationManager.AppSettings["DB"];
                this.cmd = new SqlCommand();
                this.Conn = new SqlConnection();
                this.Conn.ConnectionString = Conexion_uno;
                this.Conn.Open();

                this.cmd.CommandTimeout = 10000;
                this.cmd.Connection = Conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString().Trim());
                CerrarConexion();
            }
        }
        public void CerrarConexion()
        {
            Conn.Close();
        }
    }
    
}
