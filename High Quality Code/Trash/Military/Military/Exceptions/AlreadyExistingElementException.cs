namespace Military.Exceptions
{
    using System;
    public class AlreadyExistingElementException : Exception
    {
        public AlreadyExistingElementException()
        {
        }

        public AlreadyExistingElementException(string message)
            : base(message)
        {
        }

        public AlreadyExistingElementException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}