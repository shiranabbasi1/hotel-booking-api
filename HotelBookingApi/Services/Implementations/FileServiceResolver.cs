using HotelBookingApi.Config.File;
using HotelBookingApi.Services.Interfaces;
using System.Reflection;

namespace HotelBookingApi.Services.Implementations
{
    public class FileServiceResolver : IFileServiceResolver
    {
        private readonly FileSettings _fileSettings;
        public FileServiceResolver(FileSettings fileSettings)
        {
            _fileSettings = fileSettings;
        }

        public IFileService Resolve<T>() where T : IFileService
        {
            IFileService fileService = null;
            if (typeof(T).Equals(typeof(LocalFileService)))
                fileService = new LocalFileService(_fileSettings.LocalFileService.BasePath);
            return fileService;
        }

        public IFileService Resolve(string fileServiceName)
        {
            string basePath = "HotelBookingApi.Services.Implementations";
            // it assumes that the fileServiceName contains a valid FileService inheriting from IFileService interface
            Type type = Type.GetType($"{basePath}.{fileServiceName}");
            // it assumes that file service has a default parameterless contructor
            IFileService instance = (IFileService)Activator.CreateInstance(type);
            IFileService fileService = null;
            if (instance.GetType().Equals(typeof(LocalFileService)))
                fileService = new LocalFileService(_fileSettings.LocalFileService.BasePath);
            return fileService;
        }
    }
}
