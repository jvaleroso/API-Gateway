using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace JFV.WebAPI.Gateway.Data
{
    public class ServiceStore : IServiceStore
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Service>> FindAllAsync()
        {
            var dbContext = _unitOfWork.DbContext();
            return (from s in dbContext.Services
                    select s).ToListAsync();
        }

        public Task<Service> FindByIdAsync(string id)
        {
            return _unitOfWork.DbContext().Services.FindAsync(id);
        }

        public Task<Service> FindByNameAsync(string name)
        {
            var dbContext = _unitOfWork.DbContext();
            return (from s in dbContext.Services
                    where s.Name == name
                    select s).SingleOrDefaultAsync();
        }
    }
}
