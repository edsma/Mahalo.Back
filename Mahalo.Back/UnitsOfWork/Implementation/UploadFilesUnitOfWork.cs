using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Constants;
using Mahalo.Shared.DTOs;

namespace Mahalo.Back.UnitsOfWork.Implementation
{
    public class UploadFilesUnitOfWork : IUploadFilesUnitOfWork
    {
        private readonly string bucketName;
        private readonly string _rutaDestino = Path.Combine(Directory.GetCurrentDirectory(), "Files");


        public async Task<string> UploadFileFirebase(IFormFile archivo)
        {
            var storage = StorageClient.Create();

            // Nombre único para el archivo (UUID + nombre original)
            string nombreArchivo = $"{Guid.NewGuid()}_{archivo.FileName}";

            // Subir archivo a Firebase Storage
            using (var stream = archivo.OpenReadStream())
            {
                await storage.UploadObjectAsync(bucketName, nombreArchivo, null, stream);
            }

            // URL pública del archivo en Firebase Storage
            return $"https://storage.googleapis.com/{bucketName}/{nombreArchivo}";
        }

        public  async Task<bool> DeleteFileAync(string fileRoute)
        {
            return await Task.Run(() =>
            {
                try
                {
                    if (File.Exists(fileRoute))
                    {
                        File.Delete(fileRoute);
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            });
        }


        public async Task<FilesDto> UploadFileLocal(IFormFile file)
        {
            FilesDto result = new FilesDto();
            if (file == null || file.Length == 0)
            {
                result.resultProcess = false;
                return result;
            }

            try
            {
                string fileName = $"{Guid.NewGuid()}_{file.FileName}"; // Nombre único
                string location = Path.Combine(_rutaDestino, fileName);

                using (var stream = new FileStream(location, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                result.route = location;
                result.name = file.FileName;
                result.resultProcess = true;
                return result;
            }
            catch (Exception ex)
            {
                result.resultProcess = false;
                return result;
            }
        }
    }
}
