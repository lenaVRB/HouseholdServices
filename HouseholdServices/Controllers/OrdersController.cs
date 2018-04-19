using AutoMapper;
using HouseholdServices.Data.Infrastructure;
using HouseholdServices.Data.Repositories;
using HouseholdServices.Entities;
using HouseholdServices.Infrastructure.Core;
using HouseholdServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public HttpResponseMessage Order(HttpRequestMessage request, int customerId, int serviceId)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var customer = _customersRepository.GetSingle(customerId);
                var service = _servicesRepository.GetSingle(serviceId);
                if (customer == null || service == null)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Customer or Service!");
                }

                else
                {


                    Order _order = new Order()
                    {
                        CustomerID = customerId,
                        OrderDate = DateTime.Now,
                        Status = "Ordered",
                    };

                    OrderService _orderService = new OrderService()
                    {
                        Service = service,
                        ServiceID = serviceId,
                        Status = "In process",
                        Order = _order
                    };
                    _orderServiceRepository.Add(_orderService);
                    _ordersRepository.Add(_order);
                    customer.Orders.Add(_order);
                    service.OrderServices.Add(_orderService);
                    _unitOfWork.Commit();
                    OrderViewModel orderVM = Mapper.Map<Order, OrderViewModel>(_order);
                    response = request.CreateResponse<OrderViewModel>(HttpStatusCode.Created, orderVM);

                }

                return response;

            });
            
        }


    }
    
}