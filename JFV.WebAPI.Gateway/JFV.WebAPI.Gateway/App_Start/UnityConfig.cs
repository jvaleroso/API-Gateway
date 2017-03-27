using JFV.WebAPI.Gateway.Data;
using JFV.WebAPI.Gateway.Services;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace JFV.Gateway.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var unityContainder = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            unityContainder.RegisterType<IUnitOfWork, UnitOfWork>();
            unityContainder.RegisterType<IServiceStore, ServiceStore>();
            unityContainder.RegisterType<IServiceManager, ServiceManager>();
            config.DependencyResolver = new UnityDependencyResolver(unityContainder);
        }
    }
}