# Работа с проектом

1. Добавить библиотеку в список зависимостей:
    1. Зависмости
	2. Добавить ссылку на модель COM
	3. Обзор
	4. Выбрать файл с библиотекой
	5. ОК
2. Добавить пространство имен:
```c#
using namespace ShapeLibrary;
```
3. Для создания фигур:
    1. Треугольник:
	```c#
	Triangle triangle = new Triangle(3, 4, 5);
	double area = triangle.Area(); // фактическая площадь треугольника
	if(triangle.IsRightAngled())
	{
		Console.WriteLine("Треугольник является прямоугольным");
	}
	```
	2. Круг:
	```c#
	Circle circle = new Circle(3);
	double area = circle.Area(); // фактическая площадь треугольника
	```
	
Пример кода:
```c#
using ShapeLibrary;

namespace Example
{
    public class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Circle circle = new Circle(5);
            if (triangle.IsRightAngled())
            {
                Console.WriteLine("Треугольник прямоугольный");
            }
            else
            {
                Console.WriteLine("Треугольник не прямоугольный");
            }
            Console.WriteLine($"Площадь треугольник: {triangle.Area()}");
            Console.WriteLine($"Площадь круга: {circle.Area()}");
        }
    }
}
```

___

# Описание решения

Решение содержит 2 проекта:
1. Исходный код библиотеки
2. Юнит-тесты для библиотеки, проверяющие правильность работы ключевых методов

