using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160211_Interfaces
{
    class Square : Figure, IMovable
    {
        Point _p1;

        private double _diagonal;

        private double _sidelen;

        public Square(Point p0, Point p1) 
            : base (p0)
        {
            _p1 = p1;
        }
        
        public double Diagonal
        {
            get
            {
                return _diagonal = Math.Sqrt(Math.Pow(_p1.X - _p0.X, 2) + Math.Pow(_p1.Y - _p0.Y, 2));
            }
        }

        public double Sidelen
        {
            get
            {
                return _sidelen = Diagonal / Math.Sqrt(2);
            }
        }

        public override double Perimeter()
        {
            return _perimeter = Sidelen * 4;
        }


        public override double Area()
        {
            return _area = Sidelen * Sidelen;
        }

        public void Move(double mx, double my)
        {
            _p0.X = _p0.X + mx;
            _p0.Y = _p0.Y + my;

            _p1.X = _p1.X + mx;
            _p1.Y = _p1.Y + my;
        }

        public override string ToString()
        {
            return string.Format("Квадрат: \n\tТочка A: {0} \n\tТочка B: {1} \n\tДлина стороны: {2} \n\tПериметр: {3} \n\tПлощадь: {4}",
                _p0, _p1, Sidelen, Perimeter(), Area());
        }
    }
}
