using HouseholdServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdServices.Data.Configurations
{
    public class RoleConfiguration : EntityBaseConfiguration<Role>
    {
        public RoleConfiguration()
        {
           Property(e => e.Name)
               .IsUnicode(false);

           HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
