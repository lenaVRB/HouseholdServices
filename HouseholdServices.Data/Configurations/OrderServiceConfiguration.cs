using HouseholdServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdServices.Data.Configurations
{
    public class OrderServiceConfiguration : EntityBaseConfiguration<OrderService>
    {
        public OrderServiceConfiguration()
        {
           Property(e => e.Status)
             .IsUnicode(false);

        }
    }
}
