using HouseholdServices.Data.Infrastructure;
using HouseholdServices.Data.Repositories;
using HouseholdServices.Entities;
using HouseholdServices.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseholdServices.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Order> _ordersRepository;
        private readonly IEntityBaseRepository<OrderService> _orderServiceRepository;
        private readonly IEntityBaseRepository<Customer> _customersRepository;
        private readonly IEntityBaseRepository<Service> _servicesRepository;

        public OrdersController(IEntityBaseRepository<Order> ordersRepository,
            IEntityBaseRepository<Customer> customersRepository,
            IEntityBaseRepository<OrderService> orderServiceRepository,
            IEntityBaseRepository<Service> servicesRepository,
            IEntityBaseRepository<Error> errorsRepository,
            IUnitOfWork unitOfWork) : base(errorsRepository, unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _orderServiceRepository = orderServiceRepository;
            _servicesRepository = servicesRepository;
            _customersRepository = customersRepository;
        }
    }
}