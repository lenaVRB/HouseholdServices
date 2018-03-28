using HouseholdServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdServices.Data.Configurations
{
    public class OrderConfiguration : EntityBaseConfiguration<Order>
    {
        public OrderConfiguration()
        {         
                Property(e => e.Status)
                .IsUnicode(false);
          
                Property(e => e.Address)
                .IsUnicode(false);
    
                HasMany(e => e.OrderServices)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

        }
    }
}
