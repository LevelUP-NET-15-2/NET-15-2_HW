using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160128_Inheritance
{
    class Triangle : Figures
    {
        private Point _p1;
        private Point _p2;
        private Point _p3;

        private double _perimeter;
        private double _area;
        private double _a;
        private double _b;
        private double _c;

        public Triangle(Point p1, Point p2, Point p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public Point P1
        {
            get
            {
                return _p1;
            }

            set
            {
                _p1 = value;
            }
        }

        public Point P2
        {
            get
            {
                return _p2;
            }

            set
            {
                _p2 = value;
            }
        }

        public Point P3
        {
            get
            {
                return _p3;
            }

            set
            {
                _p3 = value;
            }
        }

        public double A
        {
            get
            {
                return _a;
            }

            set
            {
                _a = value;
            }
        }

        public double B
        {
            get
            {
                return _b;
            }

            set
            {
                _b = value;
            }
        }

        public double C
        {
            get
            {
                return _c;
            }

            set
            {
                _c = value;
            }
        }

        public double Perimeter
        {
            get
            {
                return _perimeter;
            }

            set
            {
                _perimeter = value;
            }
        }

        public double Area
        {
            get
            {
                return _area;
            }

            set
            {
                _area = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Triangle: \n\tPoint 1: {0} \n\tPoint 2: {1} \n\tPoint 3: {2} \n\tSide 1 Length: {3} \n\tSide 2 Length: {4} \n\tSide 3 length: {5} \n\tPerimeter: {6} \n\tArea: {7}"
                , P1, P2, P3, A, B, C, Perimeter, Area);
        }
    }
}
