namespace LavenderSpiritAPI.Exceptions
{
    public class UnauthorizedEventAccessException : Exception
    {
        public UnauthorizedEventAccessException()
        {
        }

        public UnauthorizedEventAccessException(string message)
            : base(message)
        {
        }

        public UnauthorizedEventAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
