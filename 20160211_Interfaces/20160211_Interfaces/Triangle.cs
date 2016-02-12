using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160211_Interfaces
{
    class Triangle : Figure, IMovable
    {
        private Point _p1;
        private Point _p2;

        private double _sdielen1;
        private double _sidelen2;
        private double _sidelen3;

        public Triangle(Point p0, Point p1, Point p2) : base (p0)
        {
            _p1 = p1;
            _p2 = p2;
        }

        public static double Sidelen(Point p0, Point p1)
        {
            double sidelen = Math.Sqrt(Math.Pow(p1.X - p0.X, 2.0) + Math.Pow(p1.Y - p0.Y, 2.0));

            return sidelen;
        }

        public double Sidelen1
        {
            get { return _sdielen1 = Sidelen(_p0, _p1); }
        }

        public double Sidelen2
        {
            get { return _sidelen2 = Sidelen(_p1, _p2); }
        }

        public double Sidelen3
        {
            get { return _sidelen3 = Sidelen(_p0, _p2); }
        }

        public override double Perimeter()
        {
            return _perimeter = Sidelen1 + Sidelen2 + Sidelen3;
        }

        public override double Area()
        {
            return _area = Math.Sqrt((Perimeter() / 2.0) * ((Perimeter() / 2.0) - _sdielen1) * ((Perimeter() / 2.0) - _sidelen2) * ((Perimeter() / 2.0) - _sidelen3));
        }

        public override string ToString()
        {
            return string.Format("Треугольник: \n\tТочка A: {0} \n\tТочка B: {1} \n\tТочка C: {2} \n\tДлина стороны AB: {3} \n\tДлина стороны BC: {4} \n\tДлина стороны AC: {5} \n\tПериметр: {6} \n\tПлощадь: {7}",
                _p0, _p1, _p2, Sidelen1, Sidelen2, Sidelen3, Perimeter(), Area());
        }

        public void Move(double mx, double my)
        {
            _p0.X = _p0.X + mx;
            _p0.Y = _p0.Y + my;

            _p1.X = _p1.X + mx;
            _p1.Y = _p1.Y + my;

            _p2.X = _p2.X + mx;
            _p2.Y = _p2.Y + my;
        }
    }
}
