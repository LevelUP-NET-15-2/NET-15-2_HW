using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160211_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = 0;
            double y1 = 0;

            double x2 = 0;
            double y2 = 0;

            double x3 = 0;
            double y3 = 0;

            double r = 0;

            Point p0 = new Point(0, 0);

            Console.WriteLine("Приготовьтесь вводить координаты точек треугольника");
            Console.ReadKey();

            for (int i = 0; i < 6; i++)
            {
                Console.Clear();

                if (i == 0)
                {
                    Console.WriteLine("Введите X-координату первой точки: ");
                    double.TryParse(Console.ReadLine(), out x1);
                }

                if (i == 1)
                {
                    Console.WriteLine("Введите Y-координату первой точки: ");
                    double.TryParse(Console.ReadLine(), out y1);
                }

                if (i == 2)
                {
                    Console.WriteLine("Введите X-координату второй точки: ");
                    double.TryParse(Console.ReadLine(), out x2);
                }

                if (i == 3)
                {
                    Console.WriteLine("Введите Y-координату второй точки: ");
                    double.TryParse(Console.ReadLine(), out y2);
                }

                if (i == 4)
                {
                    Console.WriteLine("Введите X-координату третьей точки: ");
                    double.TryParse(Console.ReadLine(), out x3);
                }

                if (i == 5)
                {
                    Console.WriteLine("Введите Y-координату третьей точки: ");
                    double.TryParse(Console.ReadLine(), out y3);
                }
            }
            Console.Clear();

            Console.WriteLine("Введите радиус окружности: ");
            bool isDouble = double.TryParse(Console.ReadLine(), out r);

            while (!isDouble)
            {
                Console.WriteLine("Введите радиус окружности: ");
                isDouble = double.TryParse(Console.ReadLine(), out r);
            }

            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);
            Point p3 = new Point(x3, y3);

            Triangle t = new Triangle(p1, p2, p3);

            Circle c = new Circle(p1, r);

            Square s = new Square(p1, p2);

            Console.WriteLine(t);

            Console.WriteLine(c);

            Console.WriteLine(s);

            Console.ReadKey();

            Console.WriteLine("Хотите сдвинуть фигуру?");

            Console.WriteLine("Нажмите 1, чтобы сдвинуть треугольник.");
            Console.WriteLine("Нажмите 2, чтобы сдвинуть окружность.");
            Console.WriteLine("Нажмите 3, чтобы сдвинуть квадрат.");
            Console.WriteLine("Нажмите любую кнопку, чтобы выйти.");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    {
                        double mx = 0;
                        double my = 0;

                        Console.WriteLine("Введите, насколько сдвинуть X-координату: ");
                        bool isDouble1 = double.TryParse(Console.ReadLine(), out mx);

                        while (!isDouble1)
                        {
                            Console.WriteLine("Введите, насколько сдвинуть X-координату: ");
                            isDouble1 = double.TryParse(Console.ReadLine(), out mx);
                        }

                        Console.WriteLine("Введите, насколько сдвинуть Y-координату: ");
                        bool isDouble2 = double.TryParse(Console.ReadLine(), out my);

                        while (!isDouble2)
                        {
                            Console.WriteLine("Введите, насколько сдвинуть Y-координату: ");
                            isDouble1 = double.TryParse(Console.ReadLine(), out my);
                        }

                        t.Move(mx, my);

                        Console.WriteLine(t);

                        Console.ReadKey();

                        break;
                    }

                case "2":
                    {
                        double mx = 0;
                        double my = 0;

                        Console.WriteLine("Введите, насколько сдвинуть X-координату: ");
                        bool isDouble1 = double.TryParse(Console.ReadLine(), out mx);

                        while (!isDouble1)
                        {
                            Console.WriteLine("Введите, насколько сдвинуть X-координату: ");
                            isDouble1 = double.TryParse(Console.ReadLine(), out mx);
                        }

                        Console.WriteLine("Введите, насколько сдвинуть Y-координату: ");
                        bool isDouble2 = double.TryParse(Console.ReadLine(), out my);

                        while (!isDouble2)
                        {
                            Console.WriteLine("Введите, насколько сдвинуть Y-координату: ");
                            isDouble1 = double.TryParse(Console.ReadLine(), out my);
                        }

                        c.Move(mx, my);

                        Console.WriteLine(c);

                        Console.ReadKey();

                        break;
                    }

                case "3":
                    {
                        double mx = 0;
                        double my = 0;

                        Console.WriteLine("Введите, насколько сдвинуть X-координату: ");
                        bool isDouble1 = double.TryParse(Console.ReadLine(), out mx);

                        while (!isDouble1)
                        {
                            Console.WriteLine("Введите, насколько сдвинуть X-координату: ");
                            isDouble1 = double.TryParse(Console.ReadLine(), out mx);
                        }

                        Console.WriteLine("Введите, насколько сдвинуть Y-координату: ");
                        bool isDouble2 = double.TryParse(Console.ReadLine(), out my);

                        while (!isDouble2)
                        {
                            Console.WriteLine("Введите, насколько сдвинуть Y-координату: ");
                            isDouble1 = double.TryParse(Console.ReadLine(), out my);
                        }

                        s.Move(mx, my);

                        Console.WriteLine(s);

                        Console.ReadKey();

                        break;
                    }
                default: break;
            }

            Console.ReadKey();
        }
    }
}
