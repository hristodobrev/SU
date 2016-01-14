namespace CohesionAndCoupling
{
    public class Shape
    {
        public Shape(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Depth { get; set; }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = MathUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = MathUtils.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = MathUtils.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = MathUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
