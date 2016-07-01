namespace Military.Exceptions
{
    using System;
    public class NotExistingElementException : Exception
    {
        public NotExistingElementException()
        {
        }

        public NotExistingElementException(string message)
            : base(message)
        {
        }

        public NotExistingElementException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
