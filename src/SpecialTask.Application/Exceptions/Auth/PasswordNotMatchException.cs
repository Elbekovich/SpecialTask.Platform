namespace SpecialTask.Application.Exceptions.Auth
{
    public class PasswordNotMatchException : BadRequestException
    {
        public PasswordNotMatchException()
        {
            TitleMessage = "Password is invalid!";
        }
    }
}
