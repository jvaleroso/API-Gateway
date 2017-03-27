using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace JFV.WebAPI.Gateway.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork()
        {
            _context = new AppDbContext();
        }
        public object Context => _context;

        public bool IsDisposed { get; private set; }

        public void Delete<TModel>(TModel entity) where TModel : class
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            if (IsDisposed)
                throw new ObjectDisposedException("UnitOfWork already disposed");

            _context.Dispose();
            IsDisposed = true;
        }

        public Task Reload<T>(T entity) where T : class
        {
            return _context.Entry(entity).ReloadAsync();
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public void Add<TModel>(TModel entity) where TModel : class, IModel
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                if (string.IsNullOrWhiteSpace(entity.Id))
                {
                    entity.Id = Guid.NewGuid().ToString();
                    entry.State = EntityState.Modified;
                }
                else {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }
}
