using HouseholdServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdServices.Data.Configurations
{
    public class ServiceTypeConfiguration : EntityBaseConfiguration<ServiceType>
    {
        public ServiceTypeConfiguration()
        {
           Property(e => e.Name)
               .IsUnicode(false);

          HasMany(e => e.Services)
                .WithRequired(e => e.ServiceType)
                .WillCascadeOnDelete(false);
        }
    }
}
