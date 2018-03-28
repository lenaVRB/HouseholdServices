using HouseholdServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdServices.Data.Configurations
{
    public class CustomerConfiguration : EntityBaseConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(e => e.FirstName).IsUnicode(false);
            Property(e => e.LastName).IsUnicode(false);
            Property(e => e.Email).IsUnicode(false);
            Property(e => e.Mobile).IsUnicode(false);
            Property(e => e.Salt).IsUnicode(false);
            HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);
        }
    }
}
