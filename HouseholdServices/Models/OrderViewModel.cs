using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseholdServices.Models
{
    public class OrderViewModel 
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public string CustomerID { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
    }
}