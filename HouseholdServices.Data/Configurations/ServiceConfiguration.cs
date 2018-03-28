using HouseholdServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdServices.Data.Configurations
{
   public class ServiceConfiguration : EntityBaseConfiguration<Service>
    {
        public ServiceConfiguration()
        {
            Property(e => e.Title)
              .IsUnicode(false);

            Property(e => e.Price)
                .HasPrecision(19, 4);

           Property(e => e.Description)
                .IsUnicode(false);

            HasMany(e => e.OrderServices)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);
        }
    }
}
