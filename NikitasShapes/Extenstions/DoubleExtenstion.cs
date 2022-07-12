namespace NikitasShapes.Extenstions
{
    using System;

    /// <summary>
    /// Методы расширения для сравнения двух переменных типа <see cref="double"/>.
    /// </summary>
    public static class DoubleExtenstion
    {
        /// <summary>
        /// Приблизительно равно.
        /// </summary>
        /// <param name="thisValue">Текущее число.</param>
        /// <param name="value">Число для сравнения.</param>
        /// <returns><c>true</c> - если числа приблизительно равны, иначе <c>false</c>.</returns>
        public static bool IsApproximatelyEqualTo(this double thisValue, double value)
        {
            return IsApproximatelyEqualTo(thisValue, value, 0.0000001);
        }

        /// <summary>
        /// Приблизительно равно.
        /// </summary>
        /// <param name="thisValue">Текущее число.</param>
        /// <param name="value">Число для сравнения.</param>
        /// /// <param name="precision">Точность сравнения.</param>
        /// <returns><c>true</c> - если числа приблизительно равны, иначе <c>false</c>.</returns>
        public static bool IsApproximatelyEqualTo(this double thisValue, double value, double precision)
        {
            return Math.Abs(thisValue - value) < precision;
        }
    }
}
