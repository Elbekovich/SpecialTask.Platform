using SpecialTask.Application.Utils;
using SpecialTask.DataAccsess.ViewModels;
using SpecialTask.Persistance.Dtos.Users;

namespace SpecialTask.Service.Interfaces.Users
{
    public interface IUserService
    {
        public Task<long> CountAsync();
        public Task<bool> DeleteAsync(long id);
        public Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params);
        public Task<UserViewModel> GetByIdAsync(long id);
        public Task<bool> UpdateAsync(long id, UserUpdateDto dto);
    }
}
