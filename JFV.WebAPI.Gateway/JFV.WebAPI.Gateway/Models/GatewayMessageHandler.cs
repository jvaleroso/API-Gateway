using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace JFV.Gateway.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GatewayMessageHandler : DelegatingHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}