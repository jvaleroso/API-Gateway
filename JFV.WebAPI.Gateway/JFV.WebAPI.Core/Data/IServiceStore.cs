using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFV.WebAPI.Gateway.Data
{
    public interface IServiceStore
    {
        Task<List<Service>> FindAllAsync();
        Task<Service> FindByIdAsync(string id);
        Task<Service> FindByNameAsync(string name);
    }
}
