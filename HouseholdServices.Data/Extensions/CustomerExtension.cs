using HouseholdServices.Data.Repositories;
using HouseholdServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdServices.Data.Extensions
{
    public static class CustomerExtension
    {
        public static bool UserExists(this IEntityBaseRepository<Customer> customersRepository, string email)
        {
            bool _userExists = false;

            _userExists = customersRepository.GetAll()
                .Any(c => c.Email.ToLower() == email);

            return _userExists;
        }
    }
}
