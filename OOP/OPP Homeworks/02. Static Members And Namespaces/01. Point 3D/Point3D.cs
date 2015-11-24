using System;

class Point3D
{
    private static Point3D StartingPoint = new Point3D(0, 0, 0);

    private double x;
    private double y;
    private double z;

    public Point3D(double x, double y, double z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public double X { get; set; }

    public double Y { get; set; }

    public double Z { get; set; }

    public static Point3D InitialCoordinate{
        get
        {
            return StartingPoint;
        }
    }

    public override string ToString()
    {
        return String.Format("[{0}, {1}, {2}]", this.X, this.Y, this.Z);
    }
}
