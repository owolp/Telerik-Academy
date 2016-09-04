namespace CohesionAndCoupling.Models
{
    using System.Text;
    using Contracts;

    public class Box : IBox
    {
        public Box(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width { get; set; }
               
        public double Height { get; set; }
               
        public double Depth { get; set; }

        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;

            return volume;
        }

        public double CalculateDiagonalXY()
        {
            var point2D = new Point2D(0, 0, this.Width, this.Height);
            double distance = point2D.CalculateDistance();

            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            var point2D = new Point2D(0, 0, this.Width, this.Depth);
            double distance = point2D.CalculateDistance();

            return distance;
        }

        public double CalculateDiagonalYZ()
        {
            var point2D = new Point2D(0, 0, this.Height, this.Depth);
            double distance = point2D.CalculateDistance();

            return distance;
        }

        public double CalculateDiagonalXYZ()
        {
            var point3D = new Point3D(0, 0, 0, this.Width, this.Height, this.Depth);
            double distance = point3D.CalculateDistance();

            return distance;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            var volume = this.CalculateVolume();
            stringBuilder.AppendFormat("Volume = {0:F2}\n", volume);

            var diagonalXY = this.CalculateDiagonalXY();
            stringBuilder.AppendFormat("Diagonal XY = {0:F2}\n", diagonalXY);

            var diagonalXZ = this.CalculateDiagonalXZ();
            stringBuilder.AppendFormat("Diagonal XZ = {0:F2}\n", diagonalXZ);

            var diagonalYZ = this.CalculateDiagonalYZ();
            stringBuilder.AppendFormat("Diagonal YZ = {0:F2}\n", diagonalYZ);

            var diagonalXYZ = this.CalculateDiagonalXYZ();
            stringBuilder.AppendFormat("Diagonal XYZ = {0:F2}", diagonalXYZ);

            return stringBuilder.ToString();
        }
    }
}
