using JFV.Gateway.Web.Filters;
using JFV.WebAPI.Gateway.Services;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JFV.Gateway.Web.Controllers
{
    /// <summary>
    /// Service API Controller
    /// </summary>
    [RoutePrefix("api/service")]
    public class ServiceController: ApiController
    {
        private readonly IServiceManager _serviceManager;
        /// <summary>
        /// Service Controller constructor
        /// </summary>
        /// <param name="serviceManager"></param>
        public ServiceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Gets a particular service by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> FindByIdAsync(string id)
        {
            var service = await _serviceManager.FindByIdAsync(id);
            if (service == null) return NotFound();

            return Ok(service);
        }

        //[HttpGet]
        //public async Task<IHttpActionResult> FindByAll()
        //{
        //    var services = await _serviceManager.FindAllAsync();
        //    if (services == null) return NotFound();

        //    return Ok(services);
        //}
        
        /// <summary>
        /// Gets all the services.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> FindByAll()
        {
            var services = await _serviceManager.FindAllAsync();
            if (services == null) return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, services);
        }
        /// <summary>
        /// Gets a service by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> FindByNameAsync(string name)
        {
            var service = await _serviceManager.FindByNameAsync(name);
            if (service == null) return NotFound();

            return Ok(service);
        }
    }
}