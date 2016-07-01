namespace Military.Exceptions
{
    using System;
    public class InconsistentEquipmentException : Exception
    {
        public InconsistentEquipmentException()
        {
        }

        public InconsistentEquipmentException(string message)
            : base(message)
        {
        }

        public InconsistentEquipmentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
