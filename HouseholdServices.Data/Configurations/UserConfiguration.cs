using HouseholdServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdServices.Data.Configurations
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        public UserConfiguration()
        {
           Property(e => e.Username)
               .IsUnicode(false);

          Property(e => e.Email)
                .IsUnicode(false);

          Property(e => e.HashedPassword)
                .IsUnicode(false);

           HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
