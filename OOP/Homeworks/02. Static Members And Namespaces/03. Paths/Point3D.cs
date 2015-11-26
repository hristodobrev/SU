using System;

public class Point3D
{
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

    public override string ToString()
    {
        return String.Format("[{0}, {1}, {2}]", this.X, this.Y, this.Z);
    }
}
