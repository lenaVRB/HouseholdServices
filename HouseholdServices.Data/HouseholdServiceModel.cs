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
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderService> OrderServices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
