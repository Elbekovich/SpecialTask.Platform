namespace SpecialTask.Application.Exceptions.Users
{
    public class UserAlreadyException : AlreadyExistsException
    {
        public UserAlreadyException()
        {
            this.TitleMessage = "User already exists!";
        }
        public UserAlreadyException(string phone)
        {
            TitleMessage = "This phone is already registered";
        }
    }
}
