using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Account
    {
        public int Ac_ID { get; set; }
        public string Ac_Account { get; set; }
        public string Password { get; set; }
        public int Ac_Level { get; set; }
        public string Ac_Pic { get; set; }

    }
}