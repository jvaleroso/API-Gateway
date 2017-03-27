using JFV.WebAPI.Gateway.Data;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace JFV.WebAPI.Gateway.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceStore _serviceStore;

        public ServiceManager(IUnitOfWork unitOfWork, IServiceStore serviceStore)
        {
            _unitOfWork = unitOfWork;
            _serviceStore = serviceStore;
        }

        public Task<List<Service>> FindAllAsync()
        {
            return _serviceStore.FindAllAsync();
        }

        public Task<Service> FindByIdAsync(string id)
        {
            return _serviceStore.FindByIdAsync(id);
        }

        public Task<Service> FindByNameAsync(string name)
        {
            return _serviceStore.FindByNameAsync(name);
        }
    }
}
