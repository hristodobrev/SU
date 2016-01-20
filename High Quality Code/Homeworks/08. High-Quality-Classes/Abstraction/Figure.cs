using System;

namespace Abstraction
{
    abstract class Figure
    {
        protected Figure()
        {
        }

        public abstract double CalcSurface();

        public abstract double CalcPerimeter();
    }
}
