using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFV.WebAPI.Gateway.Data
{
    public interface IUnitOfWork: IDisposable
    {
        object Context { get; }
        bool IsDisposed { get; }
        void Add<TModel>(TModel entity) where TModel : class, IModel;
        void Delete<TModel>(TModel entity) where TModel : class;
        Task SaveChanges();
        Task Reload<T>(T entity) where T : class;

    }
}
