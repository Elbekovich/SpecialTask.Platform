﻿namespace SpecialTask.Application.Exceptions.Users
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException()
        {
            this.TitleMessage = "User not found";
        }
    }
}
