using Microsoft.AspNetCore.Http;
using SpecialTask.Service.Helpers;
using SpecialTask.Service.Interfaces.Common;
using Microsoft.AspNetCore.Hosting;

namespace SpecialTask.Service.Services.Commons
{
    public class FileService : IFileService
    {
        private readonly string MEDIA = "media";
        private readonly string IMAGES = "images";
        private readonly string ROOTPATH;
        
        public FileService(IWebHostEnvironment env)
        {
            ROOTPATH = env.WebRootPath;
        }
        public Task<bool> DeleteAvatarAsync(string subpath)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteImageAsync(string subpath)
        {
            //throw new NotImplementedException();
            string path = Path.Combine(ROOTPATH, subpath);
            if (File.Exists(path))
            {
                await Task.Run(() =>
                {
                    File.Delete(path);
                });
                return true;
            }
            else return false;
        }

        public Task<string> UploadAvatarAsync(IFormFile avatar)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            //throw new NotImplementedException();
            string newImageName = MediaHelper.MakeImageName(image.FileName);

            string subpath = Path.Combine(MEDIA, IMAGES, newImageName);
            string path = Path.Combine(ROOTPATH, subpath);

            var stream = new FileStream(path, FileMode.Create);

            await image.CopyToAsync(stream);
            stream.Close();

            return subpath;
        }
    }
}
