namespace LavenderSpiritAPI.Exceptions
{
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException()
        {
        }

        public EventNotFoundException(string message)
            : base(message)
        {
        }

        public EventNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
