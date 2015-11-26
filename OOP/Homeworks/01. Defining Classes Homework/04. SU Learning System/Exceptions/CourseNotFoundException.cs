using System;

namespace _04.SU_Learning_System.Exceptions
{
    class CourseNotFoundException : Exception
    {
        public CourseNotFoundException()
        {
        }

        public CourseNotFoundException(string message)
            : base(message)
        {
        }

        public CourseNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
