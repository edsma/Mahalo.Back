using Mahalo.Shared.DTOs;

namespace Mahalo.Back.UnitsOfWork.Interfaces
{
    public interface IUploadFilesUnitOfWork
    {
        Task<string> UploadFileFirebase(IFormFile archivo);

        Task<FilesDto> UploadFileLocal(IFormFile archivo);

        Task<bool> DeleteFileAync(string fileLocation);

    }
}
