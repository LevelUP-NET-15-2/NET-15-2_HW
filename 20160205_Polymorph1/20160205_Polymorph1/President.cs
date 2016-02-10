using System;

namespace _20160205_Polymorph1
{
    public class President : Employer
    {
        public President() { }

        public President(string name, string surname, DateTime birthdate, DateTime employmentdate, double dirtysalary)
            : base(name, surname, birthdate, employmentdate, dirtysalary){ }

        public override double Salary
        {
            get
            {
                return _salary = (_dirtysalary - ((_dirtysalary * ndfl) + (_dirtysalary * vs))) + ((_exp / 1000) * _dirtysalary);
            }
        }

        public override void Print()
        {
            Console.WriteLine("Президент: \n\tИмя: {0} \n\tФамилия: {1} \n\tВозраст: {2} \n\tСтаж работы в компании: {3} месяца(месяцев) \n\tЗарплата: {4} грн."
                , _name, _surname, Age, Exp, Salary);

            Console.ReadKey();
        }
    }
}
