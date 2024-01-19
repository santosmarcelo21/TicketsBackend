using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaWebBL.Models
{
    public  class Userlogin
    {
        public string UserName { get; set; }
        public string PasswordUser { get; set; }
        public string TokenLogin { get; set; }
        public string IpUser { get; set; }
    }
}
