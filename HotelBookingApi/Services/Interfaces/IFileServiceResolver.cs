namespace HotelBookingApi.Services.Interfaces
{
    public interface IFileServiceResolver
    {
        IFileService Resolve<T>() where T : IFileService;
        IFileService Resolve(string fileServiceName);
    }
}
