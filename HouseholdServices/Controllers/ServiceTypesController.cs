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
using System.Web.Http;

namespace HouseholdServices.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/serviceTypes")]
    public class ServiceTypesController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<ServiceType> _serviceTypesRepository;
        public ServiceTypesController(IEntityBaseRepository<ServiceType> serviceTypesRepository,
            IEntityBaseRepository<Error> errorsRepository, 
            IUnitOfWork unitOfWork) 
            : base(errorsRepository, unitOfWork)
        {
            _serviceTypesRepository = serviceTypesRepository;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var types = _serviceTypesRepository.GetAll().ToList();

                IEnumerable<ServiceTypeViewModel> serviceTypesVM = Mapper.Map<IEnumerable<ServiceType>, IEnumerable<ServiceTypeViewModel>>(types);

                response = request.CreateResponse<IEnumerable<ServiceTypeViewModel>>(HttpStatusCode.OK, serviceTypesVM);

                return response;
            });
        }


    }
}
