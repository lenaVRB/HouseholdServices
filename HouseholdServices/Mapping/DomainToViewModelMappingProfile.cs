using AutoMapper;
using HouseholdServices.Entities;
using HouseholdServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseholdServices.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {       
        public DomainToViewModelMappingProfile()
        { 
            CreateMap<Service, ServiceViewModel>()
                .ForMember(vm => vm.ServiceType, map => map.MapFrom(s => s.ServiceType.Name))
                .ForMember(vm => vm.ServiceTypeID, map => map.MapFrom(s => s.ServiceType.ID))
                .ForMember(vm => vm.Image, map => map.MapFrom(s => s.Image));

            CreateMap<ServiceType, ServiceTypeViewModel>()
            .ForMember(vm => vm.NumberOfServices, map => map.MapFrom(st => st.Services.Count()));

            CreateMap<Customer, CustomerViewModel>();
               
                 
        }
    }
}