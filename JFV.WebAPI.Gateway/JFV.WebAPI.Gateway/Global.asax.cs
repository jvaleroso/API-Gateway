using JFV.Gateway.Web;
using JFV.Gateway.Web.Filters;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace JFV.WebAPI.Gateway
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(UnityConfig.RegisterComponents);
            GlobalConfiguration.Configuration.Filters.Add(new GenericExceptionFilter());
            AreaRegistration.RegisterAllAreas();
        }
    }
}
