using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using HouseholdServices.Services;
using HouseholdServices.Services.Abstract;
using HouseholdServices.Entities;
using HouseholdServices.Data.Repositories;
using System.Web.Http.Dependencies;

namespace HouseholdServices.Infrastructure.Extensions
{
    public static class RequestMessageExtension
    {
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request)
        {
            return request.GetService<IMembershipService>();
        }

        internal static IEntityBaseRepository<T> GetDataRepository<T>(this HttpRequestMessage request) where T: class,IEntityBase, new()
        {
            return request.GetService<IEntityBaseRepository<T>>();
        } 

        internal static TService GetService<TService> (this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }

    }
}