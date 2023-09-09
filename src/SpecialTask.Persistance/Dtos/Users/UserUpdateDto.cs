using Microsoft.AspNetCore.Http;

namespace SpecialTask.Persistance.Dtos.Users;

public class UserUpdateDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
    public IFormFile ImagePath { get; set; } = default!;
}
