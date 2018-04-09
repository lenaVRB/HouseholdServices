﻿using HouseholdServices.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace HouseholdServices.Infrastructure.MessageHandlers
{
    public class HouseholdServicesAuthHandler : DelegatingHandler
    {
        IEnumerable<string> authHeaderValues = null;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                request.Headers.TryGetValues("Authorization", out authHeaderValues);
                if (authHeaderValues == null)
                    return base.SendAsync(request, cancellationToken);

                var tokens = authHeaderValues.FirstOrDefault();
                tokens = tokens.Replace("Basic", "").Trim();
                if (!string.IsNullOrEmpty(tokens))
                {
                    byte[] data = Convert.FromBase64String(tokens);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedString.Split(':');
                    var membershipService = request.GetMembershipService();

                    var membershipContext = membershipService.ValidateUser(tokenValues[0], tokenValues[1]);

                    if(membershipContext.User != null)
                    {
                        IPrincipal principal = membershipContext.Principal;
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }

                    else // Unauthorized access - wrong credentials
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        var tsc = new TaskCompletionSource<HttpResponseMessage>();
                        tsc.SetResult(response);
                        return tsc.Task;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    var taskComplSource = new TaskCompletionSource<HttpResponseMessage>();
                    taskComplSource.SetResult(response);
                    return taskComplSource.Task;
                }
                return base.SendAsync(request, cancellationToken);
            }
            catch
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var taskComplSource = new TaskCompletionSource<HttpResponseMessage>();
                taskComplSource.SetResult(response);
                return taskComplSource.Task;

            }
        }

    }
}