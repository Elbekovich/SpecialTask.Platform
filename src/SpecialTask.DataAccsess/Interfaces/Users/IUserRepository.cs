using SpecialTask.Application.Utils;
using SpecialTask.DataAccsess.Common;
using SpecialTask.DataAccsess.ViewModels;
using SpecialTask.Domain.Entities.Users;

namespace SpecialTask.DataAccsess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>, IGetAll<UserViewModel>
{
    public Task<IList<UserViewModel>> SearchAsync(string search, PaginationParams @params);
    public Task<int> SearchCountAsync(string search);
    public Task<User?> GetByPhoneAsync(string phone);
    public Task<int> UpdateAsync(long id, UserViewModel users);
    public Task<IList<UserViewModel>> GetALlPostByUserId(long userId);
}
