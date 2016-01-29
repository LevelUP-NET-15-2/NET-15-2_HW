using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160129_Inheritance2
{
    class DataEnter
    {
        public static int EnterStudentsNumber()
        {
            int stud_number = 0;

            Console.WriteLine("Введите количество учащихся, которых вы хотите добавить");
            bool isInt = Int32.TryParse(Console.ReadLine(), out stud_number);

            while (!isInt)
            {
                Console.WriteLine("Вы ввели что-то не то. Пожалуйста повторите ввод.");

                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Введите количество учащихся, которых вы хотите добавить");

                isInt = Int32.TryParse(Console.ReadLine(), out stud_number);
            }

            return stud_number;
        }

        public static int EnterAspirantsNumber()
        {
            int asp_number = 0;

            Console.WriteLine("Из них аспирантов:");
            bool isInt = Int32.TryParse(Console.ReadLine(), out asp_number);

            while (!isInt)
            {
                Console.WriteLine("Вы ввели что-то не то. Пожалуйста повторите ввод.");

                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Из них аспирантов:");

                isInt = Int32.TryParse(Console.ReadLine(), out asp_number);
            }

            return asp_number;
        }

        public static Student[] EnterStudentsData(int number)
        {
            Student[] students = new Student[number];

            for (int i = 0; i < students.Length; i++)
            {
                string name;
                string surname;
                string group;
                int age;
                int course;
                double averrating;

                Console.WriteLine("Введите данные {0} студента", i + 1);

                Console.WriteLine("Введите имя.");
                Console.Write("->");
                name = Console.ReadLine();

                Console.WriteLine("Введите фамилию.");
                Console.Write("->");
                surname = Console.ReadLine();

                Console.WriteLine("Введите группу.");
                Console.Write("->");
                group = Console.ReadLine();

                Console.WriteLine("Введите возраст.");
                Console.Write("->");
                age = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите курс.");
                Console.Write("->");
                course = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите среднюю оценку.");
                Console.Write("->");
                averrating = double.Parse(Console.ReadLine());

                students[i] = new Student(name, surname, group, age, course, averrating);

                Console.Clear();
            }

            return students;
        }

        public static Aspirant[] EnterAspirantsData(int number)
        {
            Aspirant[] aspirants = new Aspirant[number];

            for (int i = 0; i < aspirants.Length; i++)
            {
                string name;
                string surname;
                string group;
                int age;
                int course;
                double averrating;
                bool isDisEd = true;
                bool isBudget = false;

                Console.WriteLine("Введите данные {0} аспиранта", i + 1);

                Console.WriteLine("Введите имя.");
                Console.Write("->");
                name = Console.ReadLine();

                Console.WriteLine("Введите фамилию.");
                Console.Write("->");
                surname = Console.ReadLine();

                Console.WriteLine("Введите группу.");
                Console.Write("->");
                group = Console.ReadLine();

                Console.WriteLine("Введите возраст.");
                Console.Write("->");
                age = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите курс.");
                Console.Write("->");
                course = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите среднюю оценку.");
                Console.Write("->");
                averrating = double.Parse(Console.ReadLine());

                Console.WriteLine("Является ли заочником?");
                Console.WriteLine("Введите 1, если является.");
                Console.WriteLine("Введите 2, если не является.");
                Console.Write("->");
                int isdis = int.Parse(Console.ReadLine());

                switch (isdis)
                {
                    case 1:
                        isDisEd = true;
                        break;
                    case 2:
                        isDisEd = false;
                        break;
                }

                if (!isDisEd)
                {
                    Console.WriteLine("Является ли бюджетником?");
                    Console.WriteLine("Введите 1, если является.");
                    Console.WriteLine("Введите 2, если не является.");
                    Console.Write("->");
                    int isbudget = int.Parse(Console.ReadLine());

                    switch (isbudget)
                    {
                        case 1:
                            isBudget = true;
                            break;
                        case 2:
                            isBudget = false;
                            break;
                    }
                }

                aspirants[i] = new Aspirant(name, surname, group, age, course, averrating, isDisEd, isBudget);

                Console.Clear();
            }

            return aspirants;
        }
    }
}
