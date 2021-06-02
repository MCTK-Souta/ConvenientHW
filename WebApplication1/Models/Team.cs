using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Team
    {
        public int Team_ID { get; set; }
        public string TeamName { get; set; }
        public string Img { get; set; }
        public int Ac_ID { get; set; }
        public int Shop_ID { get; set; }
        public bool? State { get; set; }


    }
}