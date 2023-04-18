namespace ShapeLibrary.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        // Метод для проверки равенства двух чисел с некоторой точностью
        public static bool AreEqual(double expected, double actual, double epsilon)
        {
            return Math.Abs(expected - actual) < epsilon;
        }

        // Метод для тестирования вычисления площади круга по радиусу
        [Test]
        public static void TestCircleArea()
        {
            Circle circle = new Circle(5); // создаем круг
            double expected = Math.PI * 25; // ожидаемая площадь круга
            double actual = circle.Area(); // фактическая площадь круга
            double epsilon = 1e-6; // точность сравнения
            if (AreEqual(expected, actual, epsilon)) // если площади равны с заданной точностью
            {
                Console.WriteLine("TestCircleArea passed"); // то тест пройден
            }
            else // иначе
            {
                Console.WriteLine("TestCircleArea failed"); // то тест не пройден
            }
        }

        // Метод для тестирования вычисления площади треугольника по трем сторонам
        [Test]
        public static void TestTriangleArea()
        {
            Triangle triangle = new Triangle(3, 4, 5); // создаем треугольник
            double expected = 6; // ожидаемая площадь треугольника
            double actual = triangle.Area(); // фактическая площадь треугольника
            double epsilon = 1e-6; // точность сравнения
            if (AreEqual(expected, actual, epsilon)) // если площади равны с заданной точностью
            {
                Console.WriteLine("TestTriangleArea passed"); // то тест пройден
            }
            else // иначе
            {
                Console.WriteLine("TestTriangleArea failed"); // то тест не пройден
            }
        }

        // Метод для тестирования проверки, является ли треугольник прямоугольным
        [Test]
        public static void TestTriangleIsRightAngled()
        {
            Triangle rightTriangle = new Triangle(3, 4, 5); // создаем прямоугольный треугольник
            Triangle notRightTriangle = new Triangle(2, 3, 4); // создаем непрямоугольный треугольник
            if (rightTriangle.IsRightAngled() && !notRightTriangle.IsRightAngled()) // если проверка работает корректно
            {
                Console.WriteLine("TestTriangleIsRightAngled passed"); // то тест пройден
            }
            else // иначе
            {
                Console.WriteLine("TestTriangleIsRightAngled failed"); // то тест не пройден
            }
        }

        // Метод для тестирования вычисления площади фигуры без знания типа фигуры в compile-time
        [Test]
        public static void TestCalculateArea()
        {
            Shape circle = new Circle(5); // создаем круг как фигуру
            Shape triangle = new Triangle(3, 4, 5); // создаем треугольник как фигуру
            double expectedCircle = Math.PI * 25; // ожидаемая площадь круга
            double expectedTriangle = 6; // ожидаемая площадь треугольника
            double actualCircle = Library.CalculateArea(circle); // фактическая площадь круга
            double actualTriangle = Library.CalculateArea(triangle); // фактическая площадь треугольника
            double epsilon = 1e-6; // точность сравнения
            if (AreEqual(expectedCircle, actualCircle, epsilon) && AreEqual(expectedTriangle, actualTriangle, epsilon)) // если площади равны с заданной точностью для обоих фигур
            {
                Console.WriteLine("TestCalculateArea passed"); // то тест пройден
            }
            else // иначе
            {
                Console.WriteLine("TestCalculateArea failed"); // то тест не пройден
            }
        }

        // Метод для запуска всех тестов
        public static void RunAllTests()
        {
            TestCircleArea();
            TestTriangleArea();
            TestTriangleIsRightAngled();
            TestCalculateArea();
        }
    }
}