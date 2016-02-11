using System;

namespace _20160205_Polymorph1
{
    public class Manager : Employer
    {
        private double _prod;

        public Manager() {}

        public Manager(string name, string surname, DateTime birthdate, DateTime employmentdate, double dirtysalary, double prod)
            : base(name, surname, birthdate, employmentdate, dirtysalary)
        {
            _prod = prod;
        }

        private double Bonus()
        {
            double bonus = (_prod * _dirtysalary) - _dirtysalary;

            return bonus;
        }

        public override double Salary
        {
            get
            {
                double bonus = Bonus();

                return _salary = ((_dirtysalary + bonus) - ((_dirtysalary * ndfl) + (_dirtysalary * vs)));
            }
        }

        public override void Print()
        {
            Console.WriteLine("Менеджер: \n\tИмя: {0} \n\tФамилия: {1} \n\tВозраст: {2} \n\tСтаж работы в компании: {3} месяца(месяцев) \n\tЗарплата: {4} грн."
                , _name, _surname, Age, Exp, Salary);

            Console.ReadKey();
        }
    }
}
