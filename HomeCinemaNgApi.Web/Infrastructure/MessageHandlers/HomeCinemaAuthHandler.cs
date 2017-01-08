using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using HomeCinemaNgApi.Web.Infrastructure.Extensions;
using System.Security.Principal;

namespace HomeCinemaNgApi.Web.Infrastructure.MessageHandlers
{
    public class HomeCinemaAuthHandler : DelegatingHandler
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
                    string[] tokensValues = decodedString.Split(':');
                    var membershipService = request.GetMembershipService();

                    var membershipContext = membershipService.ValidateUser(tokensValues[0], tokensValues[1]);
                    if (membershipContext.User != null)
                    {
                        IPrincipal principal = membershipContext.Principal;
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                    else
                    {
                        var response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                        var tsc = new TaskCompletionSource<HttpResponseMessage>();
                        tsc.SetResult(response);
                        return tsc.Task;
                    }
                }
                return base.SendAsync(request, cancellationToken);
            }
            catch
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
        }
    }
}