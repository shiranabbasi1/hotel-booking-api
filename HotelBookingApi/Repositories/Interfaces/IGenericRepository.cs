namespace HotelBookingApi.Repositories.Interfaces
{
    public interface IGenericRepository
    {
        void Create<T>(T entity) where T : class;
        T Get<T>(object id) where T : class;
        List<T> Get<T>() where T : class;
        List<T> Get<T>(Func<T, bool> filter) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(object id) where T : class;
        void Save();
    }
}
