using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160129_Inheritance2
{
    class Student
    {
        private string _name;
        private string _surname;
        private string _group;

        private int _age;
        private int _course;

        private double _averrating;

        public Student()
        {
        }

        public Student(string name, string surname, string group, int age, int course, double averrating)
        {
            Name = name;
            Surname = surname;
            Group = group;
            Age = age;
            Course = course;
            AverRating = averrating;
        }

        public Student(Student s)
            : this(s.Name, s.Surname, s.Group, s.Age, s.Course, s.AverRating)
        {
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }

        public string Group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

        public int Course
        {
            get
            {
                return _course;
            }
            set
            {
                _course = value;
            }
        }

        public double AverRating
        {
            get
            {
                return _averrating;
            }
            set
            {
                _averrating = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Студент: \n\tИмя: {0} \n\tФамилия: {1} \n\tВозраст: {2} \n\tКурс: {3} \n\tГруппа: {4} \n\tСредний балл: {5} "
                , Name, Surname, Age, Course, Group, AverRating);
        }
    }
}
