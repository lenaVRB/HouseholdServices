namespace HouseholdServices.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HouseholdServices.Entities;
    using HouseholdServices.Data.Configurations;

    public partial class HouseholdServiceModel : DbContext
    {
        public HouseholdServiceModel()
            : base("name=HouseholdServiceModel")
        {
          Database.SetInitializer<HouseholdServiceModel>(null);
        }

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Error> Errors { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderService> OrderServices { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<Service> Services { get; set; }
        public IDbSet<ServiceType> ServiceTypes { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        public IDbSet<User> Users { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderServiceConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ServiceConfiguration());
            modelBuilder.Configurations.Add(new ServiceTypeConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            
        }
    }
}
