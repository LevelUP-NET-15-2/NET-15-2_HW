using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160128_Inheritance
{
    class Point : Figures
    {
        private double _x;
        private double _y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point(Point p)
            : this(p._x, p._y)
        {
        }

        public double X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
    }
}
