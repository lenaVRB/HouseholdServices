namespace HouseholdServices.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HouseholdServices.Entities;
    

    internal sealed class Configuration : DbMigrationsConfiguration<HouseholdServices.Data.HouseholdServiceModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HouseholdServiceModel context)
        {
            context.Customers.AddOrUpdate(GenerateCustomers());
            context.Roles.AddOrUpdate(GenerateRoles());
            context.Services.AddOrUpdate(g=>g.Title,GenerateServices());
            context.ServiceTypes.AddOrUpdate(g=>g.Name,GenerateServiceTypes());

            // username: krutota, password: homecinema
            context.Users.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
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
                    RoleID = 1, // Admin
                    UserID = 1  // Adminushka
                }
            });


        }

        private ServiceType[] GenerateServiceTypes()
        {
            ServiceType[] serviceTypes = new ServiceType[]
            {
                new ServiceType(){ Name = "�������������� ������", ID = 1},
                new ServiceType(){ Name = "������ �������", ID = 2},
                new ServiceType(){ Name = "���������������� ������", ID = 3},
                new ServiceType(){ Name = "������ ������� �������", ID = 4},
                new ServiceType(){ Name = "������ ���������", ID = 5},
            };

            return serviceTypes;
        }

        private Service[] GenerateServices()
        {
            Service[] services = new Service[]
            {
                new Service()
                {
                    Title = "��������� ����������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 1,

                },
                new Service()
                {
                    Title = "��������� �����������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 1,
                },
                new Service()
                {
                    Title = "��������� �������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 1,
                },
                new Service()
                {
                    Title = "��������� ����",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 1,
                },
                new Service()
                {
                    Title = "�������� �����",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 2,
                },
                new Service()
                {
                    Title = "��������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 2,
                },
                new Service()
                {
                    Title = "������� ����",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 2,
                },
                new Service()
                {
                    Title = "��������� ������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 2,
                },
                new Service()
                {
                    Title = "��������� ������������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 3,
                },
                new Service()
                {
                    Title = "������ ���������������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 3,
                },
                new Service()
                {
                    Title = "������ �������, ������������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 3,
                },

                new Service()
                {
                    Title = "������ ���������� �����",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 4,
                },
                new Service()
                {
                    Title = "������ �������������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 4,
                },
                new Service()
                {
                    Title = "������ �����������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 4,
                },

                new Service()
                {
                    Title = "��������� ������ ������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 5,
                },
                new Service()
                {
                    Title = "����������� ������",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 5,
                },
                new Service()
                {
                    Title = "����� ����",
                    Price = null,
                    Image = "",
                    Description= "",
                    ServiceTypeID = 5,
                }

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
                    Name="Admin"
                }
            };
            return _roles;
        }



    }
}
