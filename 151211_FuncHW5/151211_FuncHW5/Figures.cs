using System;

namespace _151211_FuncHW5
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
    /// The structure that defines the Triangle
    /// </summary>
    public struct Triangle
    {
        public Point _p1;
        public Point _p2;
        public Point _p3;
        public Point _centerp;
        public double _sidelen1;
        public double _sidelen2;
        public double _sidelen3;
        public double _per;
        public double _halfper;
        public double _triarea;
        public double _radius;
        public double _circarea;

        public void Points(Point p1, Point p2, Point p3)
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
        }

        public void SideLen1()
        {
            _sidelen1 = Math.Sqrt(Math.Pow(_p2._x - _p1._x, 2.0) + Math.Pow(_p2._y - _p1._y, 2.0));
        }

        public void SideLen2()
        {
            _sidelen2 = Math.Sqrt(Math.Pow(_p3._x - _p2._x, 2.0) + Math.Pow(_p3._y - _p2._y, 2.0));
        }

        public void SideLen3()
        {
            _sidelen3 = Math.Sqrt(Math.Pow(_p3._x - _p1._x, 2.0) + Math.Pow(_p3._y - _p1._y, 2.0));
        }

        public void Perimeter()
        {
            _per = _sidelen1 + _sidelen2 + _sidelen3;
        }

        public void HalfPerimeter()
        {
            _halfper = _per * 0.5;
        }

        public void TriangleArea()
        {
            _triarea = Math.Sqrt(_halfper * (_halfper - _sidelen1) * (_halfper - _sidelen2) * (_halfper - _sidelen3));
        }

        public void CircleCenter()
        {
            _centerp._x = -((((_p1._y - _p2._y) * (Math.Pow(_p3._x, 2.0) + Math.Pow(_p3._y, 2.0))) + ((_p2._y - _p3._y)
            * (Math.Pow(_p1._x, 2.0) + Math.Pow(_p1._y, 2.0))) + ((_p3._y - _p1._y) * (Math.Pow(_p2._x, 2.0) + Math.Pow(_p2._y, 2.0))))
            / (2.0 * (((_p1._x - _p2._x) * (_p3._y - _p1._y)) - ((_p1._y - _p2._y) * (_p3._x - _p1._x)))));

            _centerp._y = -((((_p1._x - _p2._x) * (Math.Pow(_p3._x, 2) + Math.Pow(_p3._y, 2.0))) + ((_p2._x - _p3._x)
            * (Math.Pow(_p1._x, 2.0) + Math.Pow(_p1._y, 2.0))) + ((_p3._x - _p1._x) * (Math.Pow(_p2._x, 2) + Math.Pow(_p2._y, 2.0)))) 
            / (2.0 * (((_p1._x - _p2._x) * (_p3._y - _p1._y)) - ((_p1._y - _p2._y) * (_p3._x - _p1._x)))));
        }

        public void CircleRadius()
        {
            _radius = (_sidelen1 * _sidelen2 * _sidelen3) / (4.0 * Math.Sqrt(_halfper * (_halfper - _sidelen1) * (_halfper - _sidelen2) * (_halfper - _sidelen3)));
        }

        public void CircleArea()
        {
            _circarea = Math.PI* Math.Pow(_radius, 2.0);
        }

        public override string ToString()
        {
            return string.Format("Triangle: \n\tPoint 1: {0} \n\tPoint 2: {1} \n\tPoint 3: {2} \n\tSide 1 Length: {3} \n\tSide 2 Length: {4} \n\tSide 3 length: {5} \n\tPerimeter: {6} \n\tHalf perimeter: {7} \n\tArea: {8}"
                ,_p1, _p2, _p3, _sidelen1, _sidelen2, _sidelen3, _per, _halfper, _triarea);
        }
    }

    /// <summary>
    /// The structure that defines the Triangle in Circle
    /// </summary>
    public struct Triangle_in_Circle
    {
        public Triangle tri;

        public Triangle_in_Circle(Triangle t)
        {
            tri = t;
        }

        public override string ToString()
        {
            return string.Format("{0} \nin \nCircle: \n\tCenter point: {1} \n\tRadius: {2} \n\tArea: {3}", tri, tri._centerp, tri._radius, tri._circarea);
        }
    }
}
