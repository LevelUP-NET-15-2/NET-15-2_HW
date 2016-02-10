using System;

namespace _20160205_Polymorph1
{
    public class DataEnter
    {
        public static void EnterNumberOfEmployers(out uint worknum, out uint managnum, out uint presnum)
        {
            Console.WriteLine("Введите количество простых работников: ");
            bool isInt = UInt32.TryParse(Console.ReadLine(), out worknum);

            while (!isInt)
            {
                Console.WriteLine("Вы ввели что-то не то.");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Введите количество простых работников: ");
                isInt = UInt32.TryParse(Console.ReadLine(), out worknum);
            }

            Console.WriteLine("Введите количество менеджеров: ");
            bool isInt1 = UInt32.TryParse(Console.ReadLine(), out managnum);

            while (!isInt1)
            {
                Console.WriteLine("Вы ввели что-то не то.");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Введите количество менеджеров: ");
                isInt = UInt32.TryParse(Console.ReadLine(), out managnum);
            }

            Console.WriteLine("Введите количество директоров: ");
            bool isInt2 = UInt32.TryParse(Console.ReadLine(), out presnum);

            while (!isInt2)
            {
                Console.WriteLine("Вы ввели что-то не то.");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Введите количество директоров: ");
                isInt = UInt32.TryParse(Console.ReadLine(), out presnum);
            }
        }

        public static Worker EnterWorkerData()
        {
            Console.Clear();

            Console.WriteLine("Введите имя работника: ");
            string name = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Введите фамилию работника: ");
            string surname = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Введите дату рождения работника: ");
            DateTime birthdate = new DateTime();
            bool isDateTime = DateTime.TryParse(Console.ReadLine(), out birthdate);

            while (!isDateTime)
            {
                Console.Clear();
                Console.WriteLine("Введите дату рождения работника: ");
                isDateTime = DateTime.TryParse(Console.ReadLine(), out birthdate);
            }

            Console.Clear();

            Console.WriteLine("Введите дату приема на работу работника: ");
            DateTime employmentdate = new DateTime();
            bool isDateTime1 = DateTime.TryParse(Console.ReadLine(), out employmentdate);

            while (!isDateTime1)
            {
                Console.Clear();
                Console.WriteLine("Введите дату приема на работу работника: ");
                isDateTime1 = DateTime.TryParse(Console.ReadLine(), out employmentdate);
            }

            Console.Clear();

            Console.WriteLine("Введите 'грязную' зарплату работника: ");
            double dirtysalary = 0;
            bool isDouble = Double.TryParse(Console.ReadLine(), out dirtysalary);

            while (!isDouble)
            {
                Console.Clear();
                Console.WriteLine("Введите 'грязную' зарплату работника: ");
                isDouble = Double.TryParse(Console.ReadLine(), out dirtysalary);
            }

            Console.Clear();

            Worker worker = new Worker(name, surname, birthdate, employmentdate, dirtysalary);
            
            return worker;
        }


        public static Manager EnterManagerData()
        {
            Console.Clear();

            Console.WriteLine("Введите имя менеджера: ");
            string name = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Введите фамилию менеджера: ");
            string surname = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Введите дату рождения менеджера: ");
            DateTime birthdate = new DateTime();
            bool isDateTime = DateTime.TryParse(Console.ReadLine(), out birthdate);

            while (!isDateTime)
            {
                Console.Clear();
                Console.WriteLine("Введите дату рождения менеджера: ");
                isDateTime = DateTime.TryParse(Console.ReadLine(), out birthdate);
            }

            Console.Clear();

            Console.WriteLine("Введите дату приема на работу менеджера: ");
            DateTime employmentdate = new DateTime();
            bool isDateTime1 = DateTime.TryParse(Console.ReadLine(), out employmentdate);

            while (!isDateTime1)
            {
                Console.Clear();
                Console.WriteLine("Введите дату приема на работу менеджера: ");
                isDateTime1 = DateTime.TryParse(Console.ReadLine(), out employmentdate);
            }

            Console.Clear();

            Console.WriteLine("Введите 'грязную' зарплату менеджера: ");
            double dirtysalary = 0;
            bool isDouble = Double.TryParse(Console.ReadLine(), out dirtysalary);

            while (!isDouble)
            {
                Console.Clear();
                Console.WriteLine("Введите 'грязную' зарплату менеджера: ");
                isDouble = Double.TryParse(Console.ReadLine(), out dirtysalary);
            }

            Console.Clear();

            Manager manager = new Manager(name, surname, birthdate, employmentdate, dirtysalary);
                
            return manager;
        }

        public static President EnterPresidentData()
        {
            Console.Clear();

            Console.WriteLine("Введите имя работника: ");
            string name = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Введите фамилию работника: ");
            string surname = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Введите дату рождения работника: ");
            DateTime birthdate = new DateTime();
            bool isDateTime = DateTime.TryParse(Console.ReadLine(), out birthdate);

            while (!isDateTime)
            {
                Console.Clear();
                Console.WriteLine("Введите дату рождения работника: ");
                isDateTime = DateTime.TryParse(Console.ReadLine(), out birthdate);
            }

            Console.Clear();

            Console.WriteLine("Введите дату приема на работу работника: ");
            DateTime employmentdate = new DateTime();
            bool isDateTime1 = DateTime.TryParse(Console.ReadLine(), out employmentdate);

            while (!isDateTime1)
            {
                Console.Clear();
                Console.WriteLine("Введите дату приема на работу работника: ");
                isDateTime1 = DateTime.TryParse(Console.ReadLine(), out employmentdate);
            }

            Console.Clear();

            Console.WriteLine("Введите 'грязную' зарплату работника: ");
            double dirtysalary = 0;
            bool isDouble = Double.TryParse(Console.ReadLine(), out dirtysalary);

            while (!isDouble)
            {
                Console.Clear();
                Console.WriteLine("Введите 'грязную' зарплату работника: ");
                isDouble = Double.TryParse(Console.ReadLine(), out dirtysalary);
            }

            Console.Clear();

            President president = new President(name, surname, birthdate, employmentdate, dirtysalary);

            return president;
        }
    }
}
