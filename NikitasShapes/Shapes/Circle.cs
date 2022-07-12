namespace NikitasShapes.Shapes
{
    using System;
    using NikitasShapes.Interfaces;

    /// <summary>
    /// Круг.
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Радиус.
        /// </summary>
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius have to be more than zero.");
            }

            Radius = radius;
        }

        /// <inheritdoc/>
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
