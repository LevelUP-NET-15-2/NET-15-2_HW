using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160128_Inheritance
{
    class Circle : Point
    {
        private double _radius;
        private double _area;

        public Circle(Point p, double r) : base(p)
        {
            X = p.X;
            Y = p.Y;

            Radius = r;
        }

        public double Radius
        {
            get
            {
                return _radius;
            }

            set
            {
                _radius = value;
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
            return string.Format("Circle: \n\tCenter point: ({0};{1}) \n\tRadius: {1} \n\tArea: {2}", X, Y, Radius, Area);
        }
    }
}
