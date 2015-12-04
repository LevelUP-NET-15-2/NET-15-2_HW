using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _151129_StructHW4_Part2
{
    class Program
    {
        struct Point
        {
            public double _x;
            public double _y;

            public override string ToString()
            {
                return string.Format("({0};{1})", _x, _y);
            }
        }

        struct Square_1
        {
            public Point _p1;
            public Point _p2;

            public double _length;
            public double _diagonal;

            public override string ToString()
            {
                return string.Format("Square #1: \nPoint 1: {0} \nPoint 2: {1} \nLength: {2} \nDiagonal: {3}", _p1, _p2, _length, _diagonal);
            }
        }

        struct Circle
        {
            public Square_1 _p;
            public double _r;
        }

        struct Square_2
        { 
            public Circle _length;
            public Circle _diagonal;
        }

        static void Main(string[] args)
        {
            Point p1;
            Square_1 s1;
            Circle c1;
            Square_2 s2;

            p1._x = 0;
            p1._y = 0;

            s1._p1._x = 0;
            s1._p1._y = 0;
            s1._p2._x = 0;
            s1._p2._y = 0;
            s1._length = 0;
            s1._diagonal = 0;

            c1._p._p1._x = 0;
            c1._p._p1._y = 0;
            c1._r = 0;

            s2._length._p._length = 0;
            s2._diagonal._p._diagonal = 0;

            Console.WriteLine("Приготовьтесь вводить координаты точек первого квадрата");
            Console.ReadKey();

            for (int i = 0; i < 4; i++)
            {
                Console.Clear();

                if (i == 0)
                {
                    Console.WriteLine("Введите X-координату первой точки: ");
                    Double.TryParse(Console.ReadLine(), out s1._p1._x);
                }

                if (i == 1)
                {
                    Console.WriteLine("Введите Y-координату первой точки: ");
                    Double.TryParse(Console.ReadLine(), out s1._p1._y);
                }

                if (i == 2)
                {
                    Console.WriteLine("Введите X-координату второй точки: ");
                    Double.TryParse(Console.ReadLine(), out s1._p2._x);
                }

                if (i == 3)
                {
                    Console.WriteLine("Введите Y-координату второй точки: ");
                    Double.TryParse(Console.ReadLine(), out s1._p2._y);
                }
            }

            s1._diagonal = Math.Sqrt(Math.Pow(s1._p2._x - s1._p1._x, 2) + Math.Pow(s1._p2._y - s1._p1._y, 2)); ;
            s1._length = (s1._diagonal / Math.Sqrt(2));

            c1._p._p1._x = ((s1._p1._x + s1._p2._x) / 2);
            c1._p._p1._y = ((s1._p1._y + s1._p2._y) / 2);
            c1._r = (s1._length / 2);

            s2._length._p._length = ((2 * c1._r) / Math.Sqrt(2));
            s2._diagonal._p._diagonal = (2 * c1._r);

            Console.WriteLine(s1);

            Console.WriteLine("Circle: \nCenter: ({0};{1}) \nRadius: {2}", c1._p._p1._x, c1._p._p1._y, c1._r);

            Console.WriteLine("Square #2: \nLength: {0} \nDiagonal: {1}", s2._length._p._length, s2._diagonal._p._diagonal);

            Console.ReadKey();
            }
        }
    }
