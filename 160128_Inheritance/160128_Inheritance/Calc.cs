using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160128_Inheritance
{
    class Calc
    {
        static public double SideLength(Point p1, Point p2)
        {
            double sidelen = Math.Sqrt(Math.Pow(p2.X - p1.X, 2.0) + Math.Pow(p2.Y - p1.Y, 2.0));
            return sidelen;
        }

        static public double TriPerimeter(Triangle t)
        {
            double perimeter = t.A + t.B + t.C;
            return perimeter;
        }

        static public double TriArea(Triangle t)
        {
            double area = Math.Sqrt((t.Perimeter/2.0) * ((t.Perimeter/2.0) - t.A) * ((t.Perimeter / 2.0) - t.B) * ((t.Perimeter / 2.0) - t.C));
            return area;
        }

        static public Point CircleCenter(Triangle t)
        {
            double x = -((((t.P1.Y - t.P2.Y) * (Math.Pow(t.P3.X, 2.0) + Math.Pow(t.P3.Y, 2.0))) + ((t.P2.Y - t.P3.Y)
            * (Math.Pow(t.P1.X, 2.0) + Math.Pow(t.P1.Y, 2.0))) + ((t.P3.Y - t.P1.Y) * (Math.Pow(t.P2.X, 2.0) + Math.Pow(t.P2.Y, 2.0))))
            / (2.0 * (((t.P1.X - t.P2.X) * (t.P3.Y - t.P1.Y)) - ((t.P1.Y - t.P2.Y) * (t.P3.X - t.P1.X)))));

            double y = -((((t.P1.X - t.P2.X) * (Math.Pow(t.P3.X, 2.0) + Math.Pow(t.P3.Y, 2.0))) + ((t.P2.X - t.P3.X)
            * (Math.Pow(t.P1.X, 2.0) + Math.Pow(t.P1.Y, 2.0))) + ((t.P3.X - t.P1.X) * (Math.Pow(t.P2.X, 2.0) + Math.Pow(t.P2.Y, 2.0))))
            / (2.0 * (((t.P1.X - t.P2.X) * (t.P3.Y - t.P1.Y)) - ((t.P1.Y - t.P2.Y) * (t.P3.X - t.P1.X)))));

            Point circlecenter = new Point(x, y); 
            return circlecenter;
        }

        static public double CircleRadius(Triangle t)
        {
            double radius = (t.A * t.B * t.C)
                / (4.0 * Math.Sqrt((t.Perimeter / 2.0) * ((t.Perimeter / 2.0) - t.A) * ((t.Perimeter / 2.0) - t.B) * ((t.Perimeter / 2.0) - t.C))); ;
            return radius;
        }

        static public double CircleArea(Circle c)
        {
            double r = Math.PI * Math.Pow(c.Radius, 2.0);
            return r;
        }
    }
}
