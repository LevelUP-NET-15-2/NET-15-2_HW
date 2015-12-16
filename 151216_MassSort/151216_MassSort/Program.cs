using System;

namespace _151216_MassSort
{
    class Program
    {
        static Random rnd = new Random();

        static void CreateRandIntArr(ref int[] a, int dim = 0, int minVal = -100, int maxVal = 100)
        {
            if (dim == 0)
            {
                a = new int[rnd.Next(10, 100)];
                for (int i = 0; i < a.Length; ++i)
                {
                    a[i] = rnd.Next(minVal, maxVal);
                }
            }

            else
            {
                a = new int[dim];
                for (int i = 0; i < a.Length; ++i)
                {
                    a[i] = rnd.Next(minVal, maxVal);
                }
            }
        }

        public static void Array_Sort(ref int[] Arr)
        {
            int tmp;
            bool exchanged = false;
            do
            {
                exchanged = false;
                for (int i = 0; i < Arr.Length - 1; i++)
                {

                    if (Arr[i] >= 0 && Arr[i + 1] < 0)
                    {
                        tmp = Arr[i];
                        Arr[i] = Arr[i + 1];
                        Arr[i + 1] = tmp;
                        exchanged = true;
                    }
                }
            } while (exchanged);
        }

        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("Здаров! \nЭто первая часть шестого домашнего задания, выполненного Бигданом Ростиславом.");
            Console.WriteLine("Пришла пора выбрать, ввести элементы массива с клавиатуры, или рандом?");
            Console.WriteLine("Введите 1 дя ручного режима, 2 - для рандома.");
            bool isInt = Int32.TryParse(Console.ReadLine(), out choice);

            if (isInt)
            {
                if (choice == 1)
                {
                    char[] delimiterChars = { ' ', ',', '.' };

                    Console.Clear();

                    Console.WriteLine("Введите размерность массива:");
                    int dimension = Int32.Parse(Console.ReadLine());
                    
                    int[] arr = new int[dimension];

                    for (int i = 0; i < arr.Length; ++i)
                    {
                        Console.WriteLine("Введите {0} число", i+1);
                        arr[i] = Int32.Parse(Console.ReadLine());
                    }

                    Console.Clear();

                    Console.WriteLine("Изначальный массив: ");
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        Console.Write(" {0} ", arr[i]);
                    }

                    Array_Sort(ref arr);

                    Console.WriteLine("\nОтсортированный массив: ");
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        Console.Write(" {0} ",arr[i]);
                    }
                    Console.ReadKey();
                }

                if (choice == 2)
                {
                    Console.WriteLine("Введите размерность массива. \nЕсли ввести 0 то размерность сгенерируется случайно.");
                    int dimension = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Введите минмильное значение элемента в массиве. \nЕсли ввести 0 то значение сгенерируется случайно.");
                    int minVal = Int32.Parse(Console.ReadLine());
                    if (minVal == 0)
                    {
                        minVal = -100;
                    }

                    Console.WriteLine("Введите максимальное значение элемента в массиве. \nЕсли ввести 0 то значение сгенерируется случайно.");
                    int maxVal = Int32.Parse(Console.ReadLine());
                    if (maxVal == 0)
                    {
                        maxVal = 100;
                    }

                    int[] arr = new int[10];

                    CreateRandIntArr(ref arr, dimension, minVal, maxVal);

                    Console.WriteLine("Сгенерированный массив: ");
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        Console.Write(" {0} ", arr[i]);
                    }

                    Array_Sort(ref arr);

                    Console.WriteLine("\nОтсортированный массив: ");
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        Console.Write(" {0} ", arr[i]);
                    }

                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Вы ввели что-то не то. Пожалуйста вводите только 1 или 2");
                Console.ReadKey();
                return;
            }
        }
    }
}
