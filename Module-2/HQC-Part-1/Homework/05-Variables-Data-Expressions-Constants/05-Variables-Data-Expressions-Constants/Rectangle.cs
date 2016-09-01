namespace Variables_Data_Expressions_Constants
{
    using System;

    /// <summary>
    /// Class for size of the a figure
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Width of the figure
        /// </summary>
        private double width;

        /// <summary>
        /// Height of the figure
        /// </summary>
        private double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">Width of the figure</param>
        /// <param name="height">Height of the figure</param>
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// The method gets the rotation size from the current size and rotation angle.
        /// </summary>
        /// <param name="rectangle">The current size of the figure.</param>
        /// <param name="rotationAngle">The rotation angle of the new figure.</param>
        /// <returns>Returns the new rotated size figure.</returns>
        public static Rectangle GetRotatedSize(Rectangle rectangle, double rotationAngle)
        {
            double rotatedRectangleCosinus = Math.Abs(Math.Cos(rotationAngle));
            double rotatedRectangleSinus = Math.Abs(Math.Sin(rotationAngle));

            double rotatedRectangleWidth = (rotatedRectangleCosinus * rectangle.width) + 
                (rotatedRectangleSinus * rectangle.height);
            double rotatedRectangleHeight = (rotatedRectangleCosinus * rectangle.width) + 
                (rotatedRectangleSinus * rectangle.height);

            Rectangle rotatedRectangle = new Rectangle(rotatedRectangleWidth, rotatedRectangleHeight);

            return rotatedRectangle;
        }
    }
}
