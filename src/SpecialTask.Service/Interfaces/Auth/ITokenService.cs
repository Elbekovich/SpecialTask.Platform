using SpecialTask.Domain.Entities.Users;

namespace SpecialTask.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);

}
