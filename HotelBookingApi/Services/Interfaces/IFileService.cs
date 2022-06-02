namespace HotelBookingApi.Services.Interfaces
{
    public interface IFileService
    {
        Stream GetStream(string fileName);
        string GetText(string fileName);
    }
}
