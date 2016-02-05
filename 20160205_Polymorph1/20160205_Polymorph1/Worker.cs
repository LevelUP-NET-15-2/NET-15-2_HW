using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160205_Polymorph1
{
    public class Worker : Employer
    {
        private string _name { get; set; }
        private string _surname { get; set; }
        private DateTime _birthdate { get; set; } 
        private DateTime _employmentdate { get; set; }
        private double _dirtysalary { get; set; }

        private int _age;
        private string _exp;
        private double _salary;

        public Worker(string name, string surname, DateTime birthdate, DateTime employmentdate, double dirtysalary)
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

        public string Exp
        {
            get
            {
                int exp;

                exp = DateTime.Now.Year - _employmentdate.Year;
                _exp = exp.ToString();

                if (_employmentdate > DateTime.Today.AddYears(-exp))
                {
                    exp--;
                }

                if (exp == 0)
                {
                    exp = DateTime.Today.Month - _employmentdate.Month;
                    _exp += exp.ToString() + " месяца(месяцев)";
                }
                else
                {
                    _exp += " года(лет)";
                }

                return _exp;
            }
        }

        public double Salary
        {
            get
            {
                return _salary = _dirtysalary - ((_dirtysalary * 0.18) + (_dirtysalary * 0.015));
            }
        }

        public override void Print()
        {
            Console.WriteLine("Работник: \n\tИмя: {0} \n\tФамилия: {1} \n\tВозраст: {2} \n\tСтаж работы в компании: {3} \n\tЗарплата: {4} грн."
                ,_name, _surname, Age, Exp, Salary);

            Console.ReadKey();
        }
    }
}
