namespace MindboxTest
{
    using System.Collections.Generic;
    using NikitasShapes.Interfaces;
    using NikitasShapes.Shapes;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>()
            {
                new Triangle(3, 4, 5),
                new Circle(5),
            };

            foreach(var shape in shapes)
            {
                Console.WriteLine(shape.GetArea());
            }

            Console.ReadKey();
        }
    }
}
