namespace Space3D
{
    public struct Point3D
    {
        // fields
        private static readonly Point3D ZeroPoint = new Point3D(0, 0, 0);

        // constructors
        public Point3D(double coordinateX, double coordinateY, double coordinateZ)
            : this()
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
            this.CoordinateZ = coordinateZ;
        }

        // properties
        public static Point3D O
        {
            get
            {
                return ZeroPoint;
            }
        }

        public double CoordinateX { get; private set; }

        public double CoordinateY { get; private set; }

        public double CoordinateZ { get; private set; }

        // methods
        public override string ToString()
        {
            return string.Format("{{{0}, {1}, {2}}}", this.CoordinateX, this.CoordinateY, this.CoordinateZ);
        }
    }
}
