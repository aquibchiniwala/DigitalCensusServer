using System;

namespace Shared.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException(int id) : base($"User, with ID {id}, does not exist")
        {
        }
    }
}
