using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.View
{
    public class TeamViewModel
    {
        public int Team_ID { get; set; }
        public string TeamName { get; set; }
        public string Img { get; set; }
        public int Ac_ID { get; set; }
        public int Shop_ID { get; set; }
        public string State { get; set; }
        public string Shop_Name { get; set; }
        public string Ac_Account { get; set; }

    }
}