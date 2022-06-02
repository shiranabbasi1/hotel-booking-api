namespace HotelBookingApi.Config.File
{
    public class FileSettings
    {
        public LocalFileServiceSettings LocalFileService { get; set; }
    }

    public class LocalFileServiceSettings
    {
        public string BasePath { get; set; }
    }
}
