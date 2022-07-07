namespace NikitasShapes.Tests
{
    using System;
    using NikitasShapes.Shapes;
    using NUnit.Framework;

    [TestFixture]
    class TriangleTest
    {
        [TestCase(10.0, 2.0, 3.0)]
        [TestCase(2.0, 10.0, 3.0)]
        [TestCase(3.0, 2.0, 10.0)]
        public void NewTriangle_OneEdgeIsMoreThanSumOfRemainingTwoEdges_ArgumentException(double edgeA, double edgeB, double edgeC)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(edgeA, edgeB, edgeC));
        }

        [TestCase(0.0, 1.0, 1.0)]
        [TestCase(1.0, 0.0, 1.0)]
        [TestCase(1.0, 1.0, 0.0)]
        [TestCase(-1.0, 1.0, 1.0)]
        [TestCase(1.0, -1.0, 1.0)]
        [TestCase(1.0, 1.0, -1.0)]
        public void NewTriangle_EdgeIsLessOrEqualsZero_ArgumentOutOfRangeException(double edgeA, double edgeB, double edgeC)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(edgeA, edgeB, edgeC));
        }

        [TestCase(5.0, 3.0, 4.0)]
        [TestCase(4.0, 5.0, 3.0)]
        [TestCase(3.0, 4.0, 5.0)]
        public void IsRight_RightTriangle_True(double edgeA, double edgeB, double edgeC)
        {
            Assert.IsTrue(new Triangle(edgeA, edgeB, edgeC).IsRight());
        }

        [TestCase(2.0, 3.0, 4.0)]
        [TestCase(4.0, 2.0, 3.0)]
        [TestCase(3.0, 4.0, 2.0)]
        public void IsRight_NotRightTriangle_False(double edgeA, double edgeB, double edgeC)
        {
            Assert.IsFalse(new Triangle(edgeA, edgeB, edgeC).IsRight());
        }

        [TestCase(5.0, 3.0, 4.0)]
        [TestCase(4.0, 5.0, 3.0)]
        [TestCase(3.0, 4.0, 5.0)]
        public void GetArea_RightTriangle_CorrectResult(double edgeA, double edgeB, double edgeC)
        {
            Triangle triangle = new Triangle(edgeA, edgeB, edgeC);
            Assert.AreEqual(triangle.GetArea(), 6.0);
        }

        [TestCase(6.5, 6.5, 5)]
        [TestCase(6.5, 5, 6.5)]
        [TestCase(5, 6.5, 6.5)]
        public void GetArea_NotRightTriangle_CorrectResult(double edgeA, double edgeB, double edgeC)
        {
            Triangle triangle = new Triangle(edgeA, edgeB, edgeC);
            Assert.AreEqual(triangle.GetArea(), 15.0);
        }
    }
}
