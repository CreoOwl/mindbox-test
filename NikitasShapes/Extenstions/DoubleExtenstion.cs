namespace NikitasShapes.Extenstions
{
    using System;

    public static class DoubleExtenstion
    {
        public static bool IsApproximatelyEqualTo(this double thisValue, double value)
        {
            return IsApproximatelyEqualTo(thisValue, value, 0.0000001);
        }

        public static bool IsApproximatelyEqualTo(this double thisValue, double value, double precision)
        {
            return Math.Abs(thisValue - value) < precision;
        }
    }
}
