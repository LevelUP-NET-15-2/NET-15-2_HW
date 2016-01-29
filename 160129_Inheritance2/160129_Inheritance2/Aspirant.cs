using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160129_Inheritance2
{
    class Aspirant : Student
    {
        private bool _isDisEd;
        private bool _isBudget;

        public Aspirant()
        {
        }

        public Aspirant(string name, string surname, string group, int age, int course, double averrating, bool isDisEd, bool isBudget)
            : base(name, surname, group, age, course, averrating)
        {
            Name = name;
            Surname = surname;
            Group = group;
            Age = age;
            Course = course;
            AverRating = averrating;

            IsDisEd = isDisEd;
            IsBudget = isBudget;
        }

        public Aspirant(Student s, bool isDisEd, bool isBudget) :base(s)
        {
            Name = s.Name;
            Surname = s.Surname;
            Group = s.Group;
            Age = s.Age;
            Course = s.Course;
            AverRating = s.AverRating;

            IsDisEd = isDisEd;
            IsBudget = isBudget;
        }

        public bool IsDisEd
        {
            get
            {
                return _isDisEd;
            }
            set
            {
                _isDisEd = value;
            }
        }

        public bool IsBudget
        {
            get
            {
                return _isBudget;
            }
            set
            {
                _isBudget = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Аспирант: \n\tИмя: {0} \n\tФамилия: {1} \n\tВозраст: {2} \n\tКурс: {3} \n\tГруппа: {4} \n\tСредний балл: {5} \n\tЗаочник: {6} \n\tБюджетник: {7} "
                , Name, Surname, Age, Course, Group, AverRating, IsDisEd, IsBudget);
        }
    }
}
