using HotelBookingApi.Services.Interfaces;

namespace HotelBookingApi.Services.Implementations
{
    public class LocalFileService : IFileService
    {
        private readonly string _basePath;
        public LocalFileService()
        {}
        public LocalFileService(string basePath)
        {
            _basePath = basePath;
        }
        public Stream GetStream(string fileName)
        {
            string filePath = Path.Combine(_basePath, fileName);
            FileStream result = File.Open(filePath, FileMode.Open, FileAccess.Read);
            return result;
        }

        public string GetText(string fileName)
        {
            string result = null;
            string filePath = Path.Combine(_basePath, fileName);
            using (StreamReader reader = new StreamReader(filePath))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
