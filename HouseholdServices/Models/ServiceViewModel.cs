using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HouseholdServices.Infrastructure.Validators;

namespace HouseholdServices.Models
{
   
    public class ServiceViewModel : IValidatableObject
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ServiceType { get; set; }
        public int ServiceTypeID { get; set; }
        public decimal? Price { get; set; }          
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new ServiceViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}