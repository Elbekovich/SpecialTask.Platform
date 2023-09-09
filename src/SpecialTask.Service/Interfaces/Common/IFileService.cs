using Microsoft.AspNetCore.Http;

namespace SpecialTask.Service.Interfaces.Common;

public interface IFileService
{
    public Task<string> UploadImageAsync(IFormFile image);
    public Task<bool> DeleteImageAsync(string subpath);
    // returns sub path of this avatar
    public Task<string> UploadAvatarAsync(IFormFile avatar);
    public Task<bool> DeleteAvatarAsync(string subpath);
}
