using SpecialTask.Domain.Entities;

namespace SpecialTask.DataAccsess.ViewModels
{
    public class UserViewModel : Auditable
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public bool PhoneNumerConfirmed { get; set; } = false;
        public string ImagePath { get; set; } = String.Empty;
    }
}
