using System;

namespace _151211_FuncHW5
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;

            Console.WriteLine("               )\\._.,--....,'``.      ");
            Console.WriteLine(" .b--.        /;   _.. \\   _\\  (`._ ,.");
            Console.WriteLine("`=,-,-'~~~   `----(,_..'--(,_..'`-.;.'");
            Console.WriteLine();
            Console.WriteLine("Aloha! Это таки пятая домашняя работа Бигдана Ростислава!");
            Console.WriteLine("Пришла пора сделать выбор: ");
            Console.WriteLine("1) Если вы таки хотите работать с фигурами введите 1");
            Console.WriteLine("2) Если вы таки хотите работать с расписанием введите 2");

            bool isInt = Int32.TryParse(Console.ReadLine(), out choice);

            if (isInt)
            {
                if (choice == 1)
                {
                    Point a = new Point();
                    Point b = new Point();
                    Point c = new Point();


                    Console.Clear();
                    Console.WriteLine("Вы выбрали работу с фигурами");

                    Console.WriteLine("Приготовьтесь вводить координаты точек треугольника");
                    Console.ReadKey();

                    for (int i = 0; i < 6; i++)
                    {
                        Console.Clear();

                        if (i == 0)
                        {
                            Console.WriteLine("Введите X-координату первой точки: ");
                            double.TryParse(Console.ReadLine(), out a._x);
                        }

                        if (i == 1)
                        {
                            Console.WriteLine("Введите Y-координату первой точки: ");
                            double.TryParse(Console.ReadLine(), out a._y);
                        }

                        if (i == 2)
                        {
                            Console.WriteLine("Введите X-координату второй точки: ");
                            double.TryParse(Console.ReadLine(), out b._x);
                        }

                        if (i == 3)
                        {
                            Console.WriteLine("Введите Y-координату второй точки: ");
                            double.TryParse(Console.ReadLine(), out b._y);
                        }

                        if (i == 4)
                        {
                            Console.WriteLine("Введите X-координату третьей точки: ");
                            double.TryParse(Console.ReadLine(), out c._x);
                        }

                        if (i == 5)
                        {
                            Console.WriteLine("Введите Y-координату третьей точки: ");
                            double.TryParse(Console.ReadLine(), out c._y);
                        }
                    }
                    Console.Clear();

                    Triangle t1 = new Triangle();

                    t1.Points(a, b, c);
                    t1.SideLen1();
                    t1.SideLen2();
                    t1.SideLen3();
                    t1.Perimeter();
                    t1.HalfPerimeter();
                    t1.TriangleArea();
                    t1.CircleCenter();
                    t1.CircleRadius();
                    t1.CircleArea();

                    Triangle_in_Circle t = new Triangle_in_Circle(t1);


                    Console.WriteLine("{0}", t);

                    Console.ReadKey();

                    return;
                }

                if (choice == 2)
                {
                    char[] delimiterChars = { ' ', ',', '.' };

                    Console.WriteLine("В какие дни у вас есть занятия?");
                    string days_source = Console.ReadLine();
                    string days = days_source.ToUpper();

                    string[] dayssp = days.Split(delimiterChars);

                    Schedule sc = new Schedule(dayssp);

                    Console.ReadKey();

                    return;
                }

                Console.WriteLine("Вы ввели что-то не то. \nПожалуйста в следующий раз введите 1 или 2");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Вы ввели что-то не то. \nПожалуйста в следующий раз введите 1 или 2");
                Console.ReadKey();
            }
        }
    }
}
