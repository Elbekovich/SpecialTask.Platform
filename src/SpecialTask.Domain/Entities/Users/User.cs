namespace SpecialTask.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
    public bool PhoneNumerConfirmed { get; set; } = false;
    public string ImagePath { get; set; } = String.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = String.Empty;

}
