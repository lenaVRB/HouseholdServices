using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HouseholdServices.Models
{
    public class ServiceTypeViewModel : IValidatableObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOfServices { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}