using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160205_Polymorph1
{
    public class DataEnter
    {
        public static void EnterNumberOfEmployers(out int worknum, out int managnum, out int presnum)
        {
            Console.WriteLine("Введите количество простых работников: ");
            bool isInt = Int32.TryParse(Console.ReadLine(), out worknum);

            while (!isInt)
            {
                Console.WriteLine("Вы ввели что-то не то.");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Введите количество простых работников: ");
                isInt = Int32.TryParse(Console.ReadLine(), out worknum);
            }

            Console.WriteLine("Введите количество менеджеров: ");
            bool isInt1 = Int32.TryParse(Console.ReadLine(), out managnum);

            while (!isInt1)
            {
                Console.WriteLine("Вы ввели что-то не то.");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Введите количество менеджеров: ");
                isInt = Int32.TryParse(Console.ReadLine(), out managnum);
            }

            Console.WriteLine("Введите количество директоров: ");
            bool isInt2 = Int32.TryParse(Console.ReadLine(), out presnum);

            while (!isInt2)
            {
                Console.WriteLine("Вы ввели что-то не то.");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Введите количество директоров: ");
                isInt = Int32.TryParse(Console.ReadLine(), out presnum);
            }

            worknum = Math.Abs(worknum);
            managnum = Math.Abs(managnum);
            presnum = Math.Abs(presnum);
        }

        public static Worker[] EnterWorkersData(int worknum)
        {
            Worker[] workers = new Worker[worknum];

            if (worknum > 0)
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    Console.Clear();

                    Console.WriteLine("Введите имя {0} работника: ", i + 1);
                    string name = Console.ReadLine();

                    Console.Clear();

                    Console.WriteLine("Введите фамилию {0} работника: ", i + 1);
                    string surname = Console.ReadLine();

                    Console.Clear();

                    Console.WriteLine("Введите дату рождения {0} работника: ", i + 1);
                    DateTime birthdate = new DateTime();
                    bool isDateTime = DateTime.TryParse(Console.ReadLine(), out birthdate);

                    while (!isDateTime)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите дату рождения {0} работника: ", i + 1);
                        isDateTime = DateTime.TryParse(Console.ReadLine(), out birthdate);
                    }

                    Console.Clear();

                    Console.WriteLine("Введите дату приема на работу {0} работника: ", i + 1);
                    DateTime employmentdate = new DateTime();
                    bool isDateTime1 = DateTime.TryParse(Console.ReadLine(), out employmentdate);

                    while (!isDateTime1)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите дату приема на работу {0} работника: ", i + 1);
                        isDateTime1 = DateTime.TryParse(Console.ReadLine(), out employmentdate);
                    }

                    Console.Clear();

                    Console.WriteLine("Введите 'грязную' зарплату {0} работника: ", i + 1);
                    double dirtysalary = 0;
                    bool isDouble = Double.TryParse(Console.ReadLine(), out dirtysalary);

                    while (!isDouble)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите 'грязную' зарплату {0} работника: ", i + 1);
                        isDouble = Double.TryParse(Console.ReadLine(), out dirtysalary);
                    }

                    Console.Clear();

                    workers[i] = new Worker(name, surname, birthdate, employmentdate, dirtysalary);
                }
            }
            return workers;
        }
    }
}
