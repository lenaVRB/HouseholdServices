using AutoMapper;
using HouseholdServices.Data.Infrastructure;
using HouseholdServices.Data.Repositories;
using HouseholdServices.Entities;
using HouseholdServices.Infrastructure.Core;
using HouseholdServices.Infrastructure.Extensions;
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
    [RoutePrefix("api/services")]
    public class ServicesController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Service> _servicesRepository;

        public ServicesController(IEntityBaseRepository<Service> servicesRepository,
            IEntityBaseRepository<Error> errorsRepository, 
            IUnitOfWork unitOfWork) 
            : base(errorsRepository, unitOfWork)
        {
            _servicesRepository = servicesRepository;
        }

        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var service = _servicesRepository.GetSingle(id);

                ServiceViewModel serviceVM = Mapper.Map<Service, ServiceViewModel>(service);

                response = request.CreateResponse(HttpStatusCode.OK, serviceVM);

                return response;
            });
        }

        

        [AllowAnonymous]
        [Route("{page:int=0}/{pageSize=3}/{filter?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Service> services = null;
                int totalServices = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    services = _servicesRepository
                        .FindBy(s => s.Title.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(s => s.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalServices = _servicesRepository
                        .FindBy(s => s.Title.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    services = _servicesRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalServices = _servicesRepository.GetAll().Count();
                }

                IEnumerable<ServiceViewModel> moviesVM = Mapper.Map<IEnumerable<Service>, IEnumerable<ServiceViewModel>>(services);

                PaginationSet<ServiceViewModel> pagedSet = new PaginationSet<ServiceViewModel> ()
                {
                    Page = currentPage,
                    TotalCount = totalServices,
                    TotalPages = (int)Math.Ceiling((decimal)totalServices / currentPageSize),
                    Items = moviesVM
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request,ServiceViewModel service)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Service newService = new Service();
                    newService.UpdateService(service);

                    _servicesRepository.Add(newService);

                    _unitOfWork.Commit();

                    // Update view model
                    service = Mapper.Map<Service, ServiceViewModel>(newService);
                    response = request.CreateResponse<ServiceViewModel>(HttpStatusCode.Created, service);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ServiceViewModel service)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var serviceDb = _servicesRepository.GetSingle(service.ID);
                    if (serviceDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid service.");
                    else
                    {
                        serviceDb.UpdateService(service);
                        service.Image = serviceDb.Image;
                        _servicesRepository.Edit(serviceDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<ServiceViewModel>(HttpStatusCode.OK, service);
                    }
                }
                return response;
            });
        }

  /*   
        [Route("images/upload")]
        public async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request, int serviceId)
        {
            HttpResponseMessage response = null;

            var serviceOld = _moviesRepository.GetSingle(movieId);
            if (movieOld == null)
                response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid movie.");
            else
            {
                var uploadPath = HttpContext.Current.Server.MapPath("~/Content/images/movies");

                var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);

                // Read the MIME multipart asynchronously 
                await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

                string _localFileName = multipartFormDataStreamProvider
                    .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

                // Create response
                FileUploadResult fileUploadResult = new FileUploadResult
                {
                    LocalFilePath = _localFileName,

                    FileName = Path.GetFileName(_localFileName),

                    FileLength = new FileInfo(_localFileName).Length
                };

                // update database
                movieOld.Image = fileUploadResult.FileName;
                _moviesRepository.Edit(movieOld);
                _unitOfWork.Commit();

                response = request.CreateResponse(HttpStatusCode.OK, fileUploadResult);
            }

            return response;
        }
    }*/
    }
}
