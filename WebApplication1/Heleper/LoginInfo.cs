using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Heleper
{
    public class LoginInfo
    {
        public int Ac_ID { get; set; }
        public string Ac_Account { get; set; }
        public string Password { get; set; }
        public Ac_Level Level { get; set; }
    }
}