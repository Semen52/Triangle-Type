using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace triangle
{
    public enum TriangleType
    {
        RightTriangle = 1,  // Прямоугольный
        OxygonTriangle = 2, //Остроугольный
        ObtuseTriangle = 3, //Тупоугольный
        Error = 4
    }

    public class Triangle
    {
        public static TriangleType GetTriangleType(double a, double b, double c)
        {
            double[] arr = { a, b, c };

            Array.Sort(arr);
            Console.WriteLine("After sorting: {0} {1} {2}", arr[0], arr[1], arr[2]);

            if (arr[0] <= 0)
            {
                Console.WriteLine("Side should be positive");
                return TriangleType.Error;
            }

            if (arr[0] + arr[1] <= arr[2])
            {
                Console.WriteLine("Two sides should be > than third");
                return TriangleType.Error;
            }

            double e = 0.001;

            if (Math.Abs(arr[0] * arr[0] + arr[1] * arr[1] - arr[2] * arr[2]) < e)
            {
                Console.WriteLine("Прямоугольный");
                return TriangleType.RightTriangle;
            }

            if (arr[0] * arr[0] + arr[1] * arr[1] > arr[2] * arr[2])
            {
                Console.WriteLine("Остроугольный");
                return TriangleType.OxygonTriangle;
            }

            Console.WriteLine("Тупоугольный");
            return TriangleType.ObtuseTriangle;
        }
    }

    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void TestTriangle()
        {
            Assert.AreEqual(TriangleType.Error,
                            Triangle.GetTriangleType(4, 0, 4),
                            "GetTriangleType(4, 0, 4) did not return Error");

            Assert.AreEqual(TriangleType.Error,
                            Triangle.GetTriangleType(1, 4, 2),
                            "GetTriangleType(1, 4, 2) did not return Error");

            Assert.AreEqual(TriangleType.RightTriangle,
                            Triangle.GetTriangleType(1, 1, Math.Sqrt(2)),
                            "GetTriangleType(1, 1, Math.Sqrt(2)) did not return RightTriangle");

            Assert.AreEqual(TriangleType.OxygonTriangle,
                            Triangle.GetTriangleType(4, 1, 4),
                            "GetTriangleType(4, 1, 4) did not return OxygonTriangle");

            Assert.AreEqual(TriangleType.ObtuseTriangle,
                            Triangle.GetTriangleType(655, 650, 50),
                            "GetTriangleType(655, 650, 50) did not return ObtuseTriangle");
        }
    }
}
