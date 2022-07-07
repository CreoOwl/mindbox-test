namespace NikitasShapes.Tests
{
    using System;
    using NikitasShapes.Shapes;
    using NUnit.Framework;

    [TestFixture]
    public class CircleTest
    {
        [TestCase(-1.0)] 
        [TestCase(0.0)] 
        public void NewCircle_RadiusIsNegativeOrZero_ThrowException(double radius)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
        }

        [Test]
        public void GetArea_CorrectRadius_CorrectResult()
        {
            double expectedResult = Math.PI * Math.Pow(2, 2);
            Circle circle = new Circle(2);
            double actualResult = circle.GetArea();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
