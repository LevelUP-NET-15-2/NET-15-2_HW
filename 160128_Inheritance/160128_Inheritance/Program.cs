using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160128_Inheritance
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

            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);
            Point p3 = new Point(x3, y3);

            Triangle t = new Triangle(p1, p2, p3);

            t.A = Calc.SideLength(p1, p2);
            t.B = Calc.SideLength(p2, p3);
            t.C = Calc.SideLength(p1, p3);

            t.Perimeter = Calc.TriPerimeter(t);

            t.Area = Calc.TriArea(t);

            r = Calc.CircleRadius(t);

            p0 = Calc.CircleCenter(t);

            Circle c = new Circle(p0, r);

            c.Area = Calc.CircleArea(c);

            Console.WriteLine("{0} \nin \n{1}", t, c);

            Console.ReadKey();
        }
    }
}
