using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160211_Interfaces
{
    class Circle : Figure, IMovable
    {
        private double _radius;

        public Circle(Point p0, double radius) : base(p0)
        {
            _radius = radius;
        }

        public override double Perimeter()
        {
            return _perimeter = 2 * Math.PI * _radius;
        }

        public override double Area()
        {
            return _area = Math.PI * _radius * _radius;
        }

        public override string ToString()
        {
            return string.Format("Окружность: \n\tЦентральная точка: {0} \n\tРадиус: {1} \n\tДлина окружности: {2} \n\tПлощадь круга: {3}",
                _p0, _radius, Perimeter(), Area());
        }

        public void Move(double mx, double my)
        {
            _p0.X = _p0.X + mx;
            _p0.Y = _p0.Y + my;
        }
    }
}
