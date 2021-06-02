using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MenuModel
    {
        public int Menu_ID { get; set; }
        public string Menu_Name { get; set; }
        public Decimal Meny_Price { get; set; }
        public int Shop_ID { get; set; }
        public string Menu_Pic { get; set; }

    }
}