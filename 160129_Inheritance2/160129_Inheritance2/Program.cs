using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160129_Inheritance2
{
    class Program
    {
        static void Main(string[] args)
        {
            string menu = "Пожалуйста, укажите необходимое действие:" +
                   "\n*******************************************" +
                   "\n1) Работать со студентами" +
                   "\n2) Выход" +
                   "\n*******************************************" +
                   "\n" +
                   "->";

            int choice;

            bool exit = false;

            while (!exit)
            {
                Console.Write(menu);

                bool isInt = Int32.TryParse(Console.ReadLine(), out choice);

                while (!isInt)
                {
                    Console.WriteLine("Вы ввели что-то не то. Пожалуйста повторите ввод.");

                    Console.ReadKey();

                    Console.Clear();

                    Console.Write(menu);

                    isInt = Int32.TryParse(Console.ReadLine(), out choice);
                }

                switch (choice)
                {
                    case 1:
                        int stud_number = DataEnter.EnterStudentsNumber();
                        int asp_number = DataEnter.EnterAspirantsNumber(); ;

                        Console.Clear();

                        Student[] students = DataEnter.EnterStudentsData(stud_number - asp_number);

                        Aspirant[] aspirants = DataEnter.EnterAspirantsData(asp_number);

                        Console.Clear();

                        Console.WriteLine("Итого вы ввели {0} студента(ов) и {1} аспиранта(ов)", stud_number - asp_number, asp_number);

                        if ((stud_number - asp_number) != 0)
                        {
                            foreach (Student s in students)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        if (asp_number != 0)
                        {
                            foreach (Aspirant a in aspirants)
                            {
                                Console.WriteLine(a);
                            }
                        }

                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 2:
                        Console.WriteLine("Вы выбрали выход. До свидания.");
                        Console.ReadKey();

                        exit = true;
                        break;
                }
            }
        }
    }
}
