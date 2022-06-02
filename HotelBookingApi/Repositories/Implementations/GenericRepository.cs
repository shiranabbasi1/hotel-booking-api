using HotelBookingApi.Models;
using HotelBookingApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Repositories.Implementations
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Create<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete<T>(object id) where T : class
        {
            T result = _context.Set<T>().Find(id);
            if (result != null)
                _context.Set<T>().Remove(result);
        }

        public T Get<T>(object id) where T : class
        {
            T result = _context.Set<T>().Find(id);
            return result;
        }

        public List<T> Get<T>() where T : class
        {
            List<T> result = _context.Set<T>().ToList();
            return result;
        }

        public List<T> Get<T>(Func<T, bool> filter) where T : class
        {
            List<T> result = _context.Set<T>().Where(filter).ToList();
            return result;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
