namespace HouseholdServices.Data.Migrations
{
    using HouseholdServices.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HouseholdServices.Data.HouseholdServiceModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HouseholdServices.Data.HouseholdServiceModel context)
        {
            context.Customers.AddOrUpdate(GenerateCustomers());
            context.Roles.AddOrUpdate(GenerateRoles());
            context.Services.AddOrUpdate(g => g.Title, GenerateServices());
            context.ServiceTypes.AddOrUpdate(GenerateServiceTypes());

            // username: krutota, password: homecinema
            context.Users.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
                    ID=1,
                    Email="lenawwgg@mail.ru",
                    Username="Adminushka",
                    HashedPassword ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                }
            });

            context.UserRoles.AddOrUpdate(new UserRole[] {
                new UserRole() {
                    ID=1,
                    RoleID = 1, // Admin
                    UserID = 1  // Adminushka
                }
            });
        }

        private ServiceType[] GenerateServiceTypes()
        {
            ServiceType[] serviceTypes = new ServiceType[]
            {
                new ServiceType(){ Name = "Сантехнические работы", ID = 1},
                new ServiceType(){ Name = "Ремонт квартир", ID = 2},
                new ServiceType(){ Name = "Электромонтажные работы", ID = 3},
                new ServiceType(){ Name = "Ремонт бытовой техники", ID = 4},
                new ServiceType(){ Name = "Уборка помещений", ID = 5},
            };

            return serviceTypes;
        }
        
        private Service[] GenerateServices()
        {
            Service[] services = new Service[]
            {
                new Service()
                {
                    ID=1,
                    Title = "Установка смесителей",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 1,

                },
                new Service()
                {
                    ID=2,
                    Title = "Установка умывальника",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 1,
                },
               
                
                new Service()
                {
                    ID=4,
                    Title = "Поклейка обоев",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 2,
                },
                new Service()
                {
                    ID=5,
                    Title = "Демонтаж",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 2,
                },
              
                new Service()
                {
                    ID=6,
                    Title = "Установка светильников",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 3,
                },
                new Service()
                {
                    ID=7,
                    Title = "Ремонт электропроводки",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 3,
                },
                

                new Service()
                {
                    ID=8,
                    Title = "Ремонт стиральных машин",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 4,
                },
                new Service()
                {
                    ID=9,
                    Title = "Ремонт телевизоров",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 4,
                },
               
                new Service()
                {
                    ID=10,
                    Title = "Химчистка мягкой мебели",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 5,
                },
                new Service()
                {
                    ID=11,
                    Title = "Генеральная уборка",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 5,
                },
               
            };
            return services;
        }

        private Customer[] GenerateCustomers()
        {
            List<Customer> _customers = new List<Customer>();

            for (int i = 0; i < 20; i++)
            {
                Customer customer = new Customer()
                {
                    ID=i,
                    FirstName = MockData.Person.FirstName(),
                    LastName = MockData.Person.Surname(),
                    Email = MockData.Internet.Email(),
                    DateOfBirth = new DateTime(1985, 10, 20).AddMonths(i).AddDays(10),
                    RegistrationDate = DateTime.Now.AddDays(i),
                    Mobile = "+375333081319"
                };

                _customers.Add(customer);
            }

            return _customers.ToArray();
        }

        private Role[] GenerateRoles()
        {
            Role[] _roles = new Role[]{
                new Role()
                {
                    ID=1,
                    Name="Admin"
                }
            };
            return _roles;
        }

    }
}
