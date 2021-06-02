using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Order
    {
        public int Order_ID { get; set; }
        public int Ac_ID { get; set; }
        public int Team_ID { get; set; }
        public int Menu_ID { get; set; }

    }
}