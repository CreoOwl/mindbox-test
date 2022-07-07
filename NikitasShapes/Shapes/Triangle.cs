namespace NikitasShapes.Shapes
{
    using System;
    using System.Linq;
    using NikitasShapes.Extenstions;
    using NikitasShapes.Interfaces;

    /// <summary>
    /// Треугольник.
    /// </summary>
    public class Triangle : IShape
    {
        public double EdgeA { get; }

        public double EdgeB { get; }

        public double EdgeC { get; }


        public Triangle(double edgeA, double edgeB, double edgeC)
        {
            if (edgeA <= 0 || edgeB <= 0 || edgeC <= 0)
            {
                throw new ArgumentOutOfRangeException("All triangle's edges have to be more than zero.");
            }

            if (!IsValid(edgeA, edgeB, edgeC))
            {
                throw new ArgumentException("Every edge of an triangle have to be less than sum of remaining two edges.");
            }

            EdgeA = edgeA;
            EdgeB = edgeB;
            EdgeC = edgeC;
        }

        /// <inheritdoc/>
        public double GetArea()
        {
            return IsRight() ? GetAreaOfRightTriangle() : GetAreaByThreeEdges();
        }

        /// <summary>
        /// Получить площадь треугольника по трем сторонам.
        /// </summary>
        /// <returns>Размер площади.</returns>
        private double GetAreaByThreeEdges()
        {
            double semiperimeter = (EdgeA + EdgeB + EdgeC) / 2;
            double areaSquared = semiperimeter * (semiperimeter - EdgeA) * (semiperimeter - EdgeB) * (semiperimeter - EdgeC);
            double area = Math.Sqrt(areaSquared);
            return area;
        }

        /// <summary>
        /// Получить площадь прямоугольного треугольника.
        /// </summary>
        /// <returns>Размер площади.</returns>
        private double GetAreaOfRightTriangle()
        {
            double[] edgesSorted = new double[] { EdgeA, EdgeB, EdgeC }.OrderBy(edge => edge).ToArray();
            double a = edgesSorted[0];
            double b = edgesSorted[1];
            double area = (a * b) / 2;
            return area;
        }

        /// <summary>
        /// Является ли треугольник прямоугольным?
        /// </summary>
        /// <returns><c>true</c> - если да, иначе <c>false</c>.</returns>
        public bool IsRight()
        {
            return (EdgeA * EdgeA + EdgeB * EdgeB).IsApproximatelyEqualTo(EdgeC * EdgeC)
                || (EdgeA * EdgeA + EdgeC * EdgeC).IsApproximatelyEqualTo(EdgeB * EdgeB)
                || (EdgeB * EdgeB + EdgeC * EdgeC).IsApproximatelyEqualTo(EdgeA * EdgeA);
        }

        /// <summary>
        /// Проверить, корректной ли длины стороны треугольника.
        /// Длина стороны треугольника должна меньше суммы длин двух других сторон.
        /// </summary>
        /// <param name="a">Сторона a.</param>
        /// <param name="b">Сторона b.</param>
        /// <param name="c">Сторона c.</param>
        /// <returns><c>true</c> - если треугольник корректный, иначе <c>false</c>.</returns>
        private bool IsValid(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
