using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HouseholdServices.Models
{
    public class ServiceViewModel : IValidatableObject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
        decimal? Price { get; set; }          
        public int NumberOfStocks { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}