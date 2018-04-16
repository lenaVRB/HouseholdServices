using HouseholdServices.Entities;
using HouseholdServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseholdServices.Infrastructure.Extensions
{
    public static class EntitiesExtension
    {
        public static void UpdateService(this Service service, ServiceViewModel serviceVm)
        {
            service.Title = serviceVm.Title;
            service.Description = serviceVm.Description;
            service.ServiceTypeID = serviceVm.ServiceTypeID;
            service.Price = serviceVm.Price;           
        }
    }
}