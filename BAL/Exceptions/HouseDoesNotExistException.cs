using System;

namespace BAL.Exceptions
{
    public class HouseDoesNotExistException : Exception
    {
        public HouseDoesNotExistException(int id) : base($"House, with ID {id}, does not exist")
        {
        }
    }
}
