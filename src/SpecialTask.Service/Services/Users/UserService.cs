using SpecialTask.Application.Exceptions.Users;
using SpecialTask.Application.Utils;
using SpecialTask.DataAccsess.Common.Helpers;
using SpecialTask.DataAccsess.Interfaces.Users;
using SpecialTask.DataAccsess.Repositories.Users;
using SpecialTask.DataAccsess.ViewModels;
using SpecialTask.Persistance.Dtos.Users;
using SpecialTask.Service.Interfaces.Common;
using SpecialTask.Service.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialTask.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPaginator _paginator;
        private IFileService _fileService;
        public UserService(IUserRepository repository, IPaginator paginator, IFileService fileService)
        {
            this._repository = repository;
            this._paginator = paginator;
            this._fileService = fileService;
        }
        public async Task<long> CountAsync()
        {
            var db = await _repository.CountAsync();
            return db;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var js = await _repository.GetByIdAsync(id);
            if (js == null) throw new UserNotFoundException();
            var dbResult = await _repository.DeleteAsync(id);

            return dbResult > 0;
        }

        public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
        {
            var users1 = await _repository.GetAllAsync(@params);
            var count = await _repository.CountAsync();
            _paginator.Paginate(count, @params);

            return users1;
        }

        public async Task<UserViewModel> GetByIdAsync(long id)
        {
            var users1 = await _repository.GetByIdAsync(id);
            if (users1 is null) throw new UserNotFoundException();

            return users1;
        }

        public async Task<bool> UpdateAsync(long id, UserUpdateDto dto)
        {
            var user1 = await _repository.GetByIdAsync(id);
            if (user1 is null) throw new UserNotFoundException();
            user1.FirstName = dto.FirstName;
            user1.LastName = dto.LastName;
            user1.PhoneNumber = dto.PhoneNumber;
            user1.PhoneNumerConfirmed = true;

            if (dto.ImagePath is not null)
            {
                string newImagePath = await _fileService.UploadImageAsync(dto.ImagePath);
                user1.ImagePath = newImagePath;
            }
            user1.UpdatedAt = TimeHelper.GetDateTime();
            var dbRes = await _repository.UpdateAsync(id, user1);

            return dbRes > 0;
        }
    }
}
