using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using HouseholdServices.Models;

namespace HouseholdServices.Infrastructure.Validators
{
    public class ServiceViewModelValidator : AbstractValidator<ServiceViewModel>
    {
        public ServiceViewModelValidator()
        {
            RuleFor(service => service.Description).NotEmpty().WithMessage("Select a description!");
            RuleFor(service =>service.ServiceTypeId).GreaterThan(0)
                .WithMessage("Select a service type!");
        }
    }
}