using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdServices.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        HouseholdServiceModel dbContext;

        public HouseholdServiceModel Init()
        {
            return dbContext ?? (dbContext = new HouseholdServiceModel());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
