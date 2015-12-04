using System;

namespace _151129_StructHW4
{
    class Program
    {
        struct Point
        {
            public double _x;
            public double _y;

            public override string ToString()
            {
                return string.Format("({0},{1})", _x, _y);
            }
        }

        struct Circle
        {
            public Point _p;
            public double _r;

            public override string ToString()
            {
                return string.Format("Circle: \nCenter: {0} \nRadius: {1}", _p, _r);
            }
        }

        struct Triangle
        {
            public Circle _p1;
            public Circle _p2;
            public Circle _p3;
            public double _ab;
            public double _bc;
            public double _ac;
            public double _per;

            public override string ToString()
            {
                return string.Format("Triangle: \nPoint 1: {0} \nPoint 2: {1} \nPoint 3: {2} \nAB: {3} \nBC: {4} \nAC: {5} \nPerimeter: {6}", _p1._p, _p2._p, _p3._p, _ab, _bc, _ac, _per * 2);
            }
        }

        static void Main(string[] args)
        {
            Point p1;
            Circle c1;
            Triangle t1;

            //Начало координат
            p1._x = 0;
            p1._y = 0;

            //Точки треугольника
            t1._p1._p._x = 0;
            t1._p1._p._y = 0;

            t1._p2._p._x = 0;
            t1._p2._p._y = 0;

            t1._p3._p._x = 0;
            t1._p3._p._y = 0;

            Console.WriteLine("Приготовьтесь вводить координаты точек треугольника");
            Console.ReadKey();

            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                
                if (i == 0)
                {
                    Console.WriteLine("Введите X-координату первой точки: ");
                    Double.TryParse(Console.ReadLine(), out t1._p1._p._x);
                }

                if (i == 1)
                {
                    Console.WriteLine("Введите Y-координату первой точки: ");
                    Double.TryParse(Console.ReadLine(), out t1._p1._p._y);
                }

                if (i == 2)
                {
                    Console.WriteLine("Введите X-координату второй точки: ");
                    Double.TryParse(Console.ReadLine(), out t1._p2._p._x);
                }

                if (i == 3)
                {
                    Console.WriteLine("Введите Y-координату второй точки: ");
                    Double.TryParse(Console.ReadLine(), out t1._p2._p._y);
                }

                if (i == 4)
                {
                    Console.WriteLine("Введите X-координату третьей точки: ");
                    Double.TryParse(Console.ReadLine(), out t1._p3._p._x);
                }

                if (i == 5)
                {
                    Console.WriteLine("Введите Y-координату третьей точки: ");
                    Double.TryParse(Console.ReadLine(), out t1._p3._p._y);
                }

            }

            //Длины сторон
            t1._ab = Math.Sqrt(Math.Pow(t1._p2._p._x - t1._p1._p._x, 2) + Math.Pow(t1._p2._p._y - t1._p1._p._y, 2));
            t1._bc = Math.Sqrt(Math.Pow(t1._p3._p._x - t1._p2._p._x, 2) + Math.Pow(t1._p3._p._y - t1._p2._p._y, 2));
            t1._ac = Math.Sqrt(Math.Pow(t1._p3._p._x - t1._p1._p._x, 2) + Math.Pow(t1._p3._p._y - t1._p1._p._y, 2));

            //Полупериметр
            t1._per = (0.5) * (t1._ab + t1._bc + t1._ac);

            //Радиус описанной окружности
            c1._r = (t1._ab * t1._bc * t1._ac) / (4 * Math.Sqrt(t1._per * (t1._per - t1._ab) * (t1._per - t1._bc) * (t1._per - t1._ac)));

            //X-координата центра описанной окружности
            c1._p._x = -((((t1._p1._p._y - t1._p2._p._y) * (Math.Pow(t1._p3._p._x, 2) + Math.Pow(t1._p3._p._y, 2))) + ((t1._p2._p._y - t1._p3._p._y) * (Math.Pow(t1._p1._p._x, 2) + Math.Pow(t1._p1._p._y, 2))) + ((t1._p3._p._y - t1._p1._p._y) * (Math.Pow(t1._p2._p._x, 2) + Math.Pow(t1._p2._p._y, 2)))) / (2 * (((t1._p1._p._x - t1._p2._p._x) * (t1._p3._p._y - t1._p1._p._y)) - ((t1._p1._p._y - t1._p2._p._y) * (t1._p3._p._x - t1._p1._p._x)))));

            //Y-координата центра описанной окружности
            c1._p._y = -((((t1._p1._p._x - t1._p2._p._x) * (Math.Pow(t1._p3._p._x, 2) + Math.Pow(t1._p3._p._y, 2))) + ((t1._p2._p._x - t1._p3._p._x) * (Math.Pow(t1._p1._p._x, 2) + Math.Pow(t1._p1._p._y, 2))) + ((t1._p3._p._x - t1._p1._p._x) * (Math.Pow(t1._p2._p._x, 2) + Math.Pow(t1._p2._p._y, 2)))) / (2 * (((t1._p1._p._x - t1._p2._p._x) * (t1._p3._p._y - t1._p1._p._y)) - ((t1._p1._p._y - t1._p2._p._y) * (t1._p3._p._x - t1._p1._p._x)))));

            Console.Clear();
            Console.WriteLine(c1);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Triangle:");
            Console.WriteLine("Point 1: ({0};{1}) \nPoint 2: ({2};{3}) \nPoint 3: ({4};{5})", t1._p1._p._x, t1._p1._p._y, t1._p2._p._x, t1._p2._p._y, t1._p3._p._x, t1._p3._p._y);
            Console.WriteLine("AB: {0} | BC: {1} | AC: {2}", t1._ab, t1._bc, t1._ac);
            Console.WriteLine("Perimeter: {0}", t1._per * 2);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
