using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160211_Interfaces
{
    abstract class Figure
    {
        protected Point _p0;

        protected double _perimeter;

        protected double _area;

        public Figure(Point p0)
        {
            _p0 = p0;
        }

        public abstract double Perimeter();

        public abstract double Area();
    }
}
