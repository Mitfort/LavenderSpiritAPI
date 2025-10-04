namespace LavenderSpiritAPI.Exceptions
{
    public class UserHasNoEventsException : Exception
    {
        public UserHasNoEventsException()
        {
        }

        public UserHasNoEventsException(string message)
            : base(message)
        {
        }

        public UserHasNoEventsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
