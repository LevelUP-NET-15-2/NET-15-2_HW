using System;

namespace _151211_FuncHW5
{
    class Figures
    {
        /// <summary>
        /// The structure that defines the Point
        /// </summary>
        public struct Point
        {
            public double _x;
            public double _y;

            public override string ToString()
            {
                return string.Format("({0},{1})", _x, _y);
            }
        }

        /// <summary>
        /// The structure that defines the Circle
        /// </summary>
        public struct Circle
        {
            public Point _p;
            public double _r;
            public double _a;

            public override string ToString()
            {
                return string.Format("Circle: \n\tCenter: {0} \n\tRadius: {1} \n\tArea: {2}", _p, _r, _a);
            }
        }

        /// <summary>
        /// The structure that defines the Triangle
        /// </summary>
        public struct Triangle
        {
            public Point _p1;
            public Point _p2;
            public Point _p3;
            public double _ab;
            public double _bc;
            public double _ac;
            public double _per;
            public double _halfper;
            public double _area;

            public override string ToString()
            {
                return string.Format("Triangle: \n\tPoint 1: {0} \n\tPoint 2: {1} \n\tPoint 3: {2} \n\tAB: {3} \n\tBC: {4} \n\tAC: {5} \n\tPerimeter: {6} \n\tHalf perimeter: {7} \n\tArea: {8}"
                    ,_p1, _p2, _p3, _ab, _bc, _ac, _per, _halfper, _area);
            }
        }

        /// <summary>
        /// The structure that defines the Triangle in Circle
        /// </summary>
        public struct Triangle_in_Circle
        {
            public Circle circ;
            public Triangle tri;

            public Triangle_in_Circle(Circle c, Triangle t)
            {
                circ = c;
                tri = t;
            }

            public override string ToString()
            {
                return string.Format("{0} \nin \n{1}", tri, circ);
            }
        }

        public Figures(Point a, Point b, Point c, out Triangle_in_Circle tic)
        {
            Circle c1 = new Circle();
            Triangle t1 = new Triangle();
            

            t1._p1._x = a._x;
            t1._p1._y = a._y;

            t1._p2._x = b._x;
            t1._p2._y = b._y;

            t1._p3._x = c._x;
            t1._p3._y = c._y;

            t1._bc = Math.Sqrt(Math.Pow(t1._p3._x - t1._p2._x, 2) + Math.Pow(t1._p3._y - t1._p2._y, 2));
            t1._ab = Math.Sqrt(Math.Pow(t1._p2._x - t1._p1._x, 2) + Math.Pow(t1._p2._y - t1._p1._y, 2));
            t1._ac = Math.Sqrt(Math.Pow(t1._p3._x - t1._p1._x, 2) + Math.Pow(t1._p3._y - t1._p1._y, 2));

            t1._per = t1._ab + t1._bc + t1._ac;
            t1._halfper = 0.5 * t1._per;
            t1._area = Math.Sqrt(t1._halfper * (t1._halfper - t1._ab) * (t1._halfper - t1._bc) * (t1._halfper - t1._ac));

            c1._r = (t1._ab * t1._bc * t1._ac) / (4.0 * Math.Sqrt(t1._halfper * (t1._halfper - t1._ab) * (t1._halfper - t1._bc) * (t1._halfper - t1._ac)));
            c1._a = Math.PI * Math.Pow(c1._r, 2.0);

            c1._p._x = -((((t1._p1._y - t1._p2._y) * (Math.Pow(t1._p3._x, 2.0) + Math.Pow(t1._p3._y, 2.0))) + ((t1._p2._y - t1._p3._y)
                * (Math.Pow(t1._p1._x, 2.0) + Math.Pow(t1._p1._y, 2.0))) + ((t1._p3._y - t1._p1._y) * (Math.Pow(t1._p2._x, 2.0) + Math.Pow(t1._p2._y, 2.0))))
                / (2.0 * (((t1._p1._x - t1._p2._x) * (t1._p3._y - t1._p1._y)) - ((t1._p1._y - t1._p2._y) * (t1._p3._x - t1._p1._x)))));

            c1._p._y = -((((t1._p1._x - t1._p2._x) * (Math.Pow(t1._p3._x, 2) + Math.Pow(t1._p3._y, 2.0))) + ((t1._p2._x - t1._p3._x) 
                * (Math.Pow(t1._p1._x, 2.0) + Math.Pow(t1._p1._y, 2.0))) + ((t1._p3._x - t1._p1._x) * (Math.Pow(t1._p2._x, 2) + Math.Pow(t1._p2._y, 2.0)))) 
                / (2.0 * (((t1._p1._x - t1._p2._x) * (t1._p3._y - t1._p1._y)) - ((t1._p1._y - t1._p2._y) * (t1._p3._x - t1._p1._x)))));

            Triangle_in_Circle tic1 = new Triangle_in_Circle(c1, t1);
            tic = tic1;
        }
    }
}
