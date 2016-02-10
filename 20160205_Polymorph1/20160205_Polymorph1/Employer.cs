using System;

namespace _20160205_Polymorph1
{
    public abstract class Employer
    {
        protected string _name;
        protected string _surname;
        protected DateTime _birthdate;
        protected DateTime _employmentdate;
        protected double _dirtysalary;

        protected int _age;
        protected int _exp;
        protected double _salary;

        protected const double ndfl = 0.18;   //НДФЛ - налог на доходы физических лиц
        protected const double vs = 0.015;    //ВС - военный сбор

        public Employer()
        {

        }

        public Employer(string name, string surname, DateTime birthdate, DateTime employmentdate, double dirtysalary)
        {
            _name = name;
            _surname = surname;
            _birthdate = birthdate;
            _employmentdate = employmentdate;
            _dirtysalary = dirtysalary;
        }

        public int Age
        {
            get
            {
                _age = DateTime.Today.Year - _birthdate.Year;

                if (_birthdate > DateTime.Today.AddYears(-_age))
                {
                    _age--;
                }

                return _age;
            }
        }

        public int Exp
        {
            get
            {
                _exp = (DateTime.Now - _employmentdate).Days / 30;

                return _exp;
            }
        }

        public virtual double Salary
        {
            get
            {
                return _salary = _dirtysalary - ((_dirtysalary * ndfl) + (_dirtysalary * vs));
            }
        }

        public abstract void Print();
    }
}
