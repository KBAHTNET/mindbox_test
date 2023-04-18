namespace ShapeLibrary
{
    // Абстрактный класс для фигур
    public abstract class Shape
    {
        // Абстрактный метод для вычисления площади
        public abstract double Area();

        // Метод для проверки, является ли фигура прямоугольной
        public virtual bool IsRightAngled()
        {
            return false;
        }
    }

    // Класс для круга
    public class Circle : Shape
    {
        // Поле для радиуса
        private double radius;

        // Конструктор с параметром радиуса
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус должен быть положительным");
            }
            this.radius = radius;
        }

        // Переопределение метода для вычисления площади круга
        public override double Area()
        {
            return Math.PI * radius * radius;
        }
    }

    // Класс для треугольника
    public class Triangle : Shape
    {
        // Поля для сторон треугольника
        private double a;
        private double b;
        private double c;

        // Конструктор с параметрами сторон треугольника
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Стороны должны быть положительными");
            }
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Сумма любых двух сторон должна быть больше третьей");
            }
            this.a = a;
            this.b = b;
            this.c = c;
        }

        // Переопределение метода для вычисления площади треугольника по формуле Герона
        public override double Area()
        {
            double p = (a + b + c) / 2; // полупериметр
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c)); // формула Герона
        }

        // Переопределение метода для проверки, является ли треугольник прямоугольным по теореме Пифагора
        public override bool IsRightAngled()
        {
            double[] sides = new double[] { a, b, c };
            Array.Sort(sides); // сортируем стороны по возрастанию
            return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1e-6; // сравниваем квадрат гипотенузы с суммой квадратов катетов с некоторой точностью
        }
    }

    // Класс для библиотеки
    public class Library
    {
        // Метод для вычисления площади фигуры без знания типа фигуры в compile-time
        public static double CalculateArea(Shape shape)
        {
            return shape.Area();
        }
    }

    // Класс для юнит-тестов
    public class Tests
    {
        // Метод для проверки равенства двух чисел с некоторой точностью
        public static bool AreEqual(double expected, double actual, double epsilon)
        {
            return Math.Abs(expected - actual) < epsilon;
        }

        // Метод для тестирования вычисления площади круга по радиусу
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