using System;

namespace _151216_MinMaxArrayElem
{
    class Program
    {
        static Random rnd = new Random();

        #region --- === ###   Функции   ### === ---

        /// <summary>
        /// Функция заполнения массива случайными числами
        /// </summary>
        /// <param name="m">Массив</param>
        /// <param name="minVal">Минимальный элемент массива</param>
        /// <param name="maxVal">Максимальный элемент массива</param>
        /// 
        static void InitRandIntMatr(ref int[,] m, int minVal = -100, int maxVal = 100)
        {
            for (int i = 0; i < m.GetLength(0); ++i)
            {
                for (int j = 0; j < m.GetLength(1); ++j)
                {
                    m[i, j] = rnd.Next(minVal, maxVal);
                }
            }
        }

        /// <summary>
        /// Функция поиска минимального и максимального значения
        /// </summary>
        /// <param name="a">Массив</param>
        /// <param name="min">Минимальный элемент</param>
        /// <param name="max">Максимальный элемент</param>
        /// <param name="imin">Адрес строки, где находится минимальный элемент</param>
        /// <param name="jmin">Адрес столбца, где находится минимальный элемент</param>
        /// <param name="imax">Адрес строки, где находится максимальный элемент</param>
        /// <param name="jmax">Адрес столбца, где находится максимальный элемент</param>
        /// 
        static void SearchMinMax(ref int[,] a, out int min, out int max, out int imin, out int jmin, out int imax, out int jmax)
        {
            min = a[0, 0];
            max = a[0, 0];
            imin = 0;
            jmin = 0;
            imax = 0;
            jmax = 0;

            for (int i = 0; i < a.GetLength(0); ++i)
            {
                for (int j = 0; j < a.GetLength(1); ++j)
                {
                    if (a[i, j] <= min)
                    {
                        min = a[i, j];
                        imin = i;
                        jmin = j;
                    }
                    if (a[i, j] >= max)
                    {
                        max = a[i, j];
                        imax = i;
                        jmax = j;
                    }
                }
            }
        }

        /// <summary>
        /// Функция замены строк в массиве
        /// </summary>
        /// <param name="a">Массив</param>
        /// <param name="imin">Адрес строки, где находится минимальный элемент</param>
        /// <param name="imax">Адрес строки, где находится максимальный элемент</param>
        /// 
        static void ChangeLines(ref int[,] a, int imin,  int imax)
        {
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                int temp = a[imin, i];
                a[imin, i] = a[imax, i];
                a[imax, i] = temp;
            }
        }

        /// <summary>
        /// Функция замены столбцов в массиве
        /// </summary>
        /// <param name="a">Массив</param>
        /// <param name="jmin">Адрес столбца, где находится минимальный элемент</param>
        /// <param name="jmax">Адрес столбца, где находится максимальный элемент</param>
        /// 
        static void ChangeColumns(ref int[,] a, int jmin, int jmax)
        {
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                int temp = a[i, jmin];
                a[i, jmin] = a[i, jmax];
                a[i, jmax] = temp;
            }
        }

        #endregion


        #region --- === ###   Основная часть   ### === ---

        static void Main(string[] args)
        {
            int lines = 0;
            int columns = 0;
            int choice1 = 0;
            int choice2 = 0;
            int min = 0;
            int max = 0;
            int mini = 0;
            int minj = 0;
            int maxi = 0;
            int maxj = 0;


            #region --- === ###   Инициализация массива   ### === ---

            Console.WriteLine("Здаров, сегодня не будет никаких котиков, только суровая консоль!");
            Console.WriteLine("Для начала введите количество строк массива: ");
            bool isInt1 = Int32.TryParse(Console.ReadLine(), out lines);

            if (isInt1 == false)
            {
                Console.WriteLine("Вы ввели что-то не то.");
                return;
            }

            Console.WriteLine("Теперь введите количество столбцов: ");
            bool isInt2 = Int32.TryParse(Console.ReadLine(), out columns);

            if (isInt2 == false)
            {
                Console.WriteLine("Вы ввели что-то не то.");
                return;
            }

            int[,] array = new int[lines, columns];

            #endregion

            #region --- === ###   Заполнение массива значениями   ### === ---

            Console.WriteLine("Теперь выберите, как будет заполнены массив: вручную или случайно?");
            Console.WriteLine("Для ввода вручную введите 1 \nДля рандома введите 2");

            bool isInt3 = Int32.TryParse(Console.ReadLine(), out choice1);

            if (isInt3 == false)
            {
                Console.WriteLine("Вы ввели что-то не то.");
                return;
            }

            if (choice1 == 1)
            {
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                    {
                        array[i, j] = Int32.Parse(Console.ReadLine());
                    }
                }

                Console.WriteLine("Полученная матрица: ");
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                    {
                        Console.Write(" {0} ", array[i, j]);
                    }
                    Console.WriteLine();
                }

                SearchMinMax(ref array, out min, out max, out mini, out minj, out maxi, out maxj);

                Console.WriteLine("Минимальный элемент: {0} [{1}, {2}]", min, mini + 1, minj + 1);
                Console.WriteLine("Максимальный элемент: {0} [{1}, {2}]", max, maxi + 1, maxj + 1);
            }

            if (choice1 == 2)
            {
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

                InitRandIntMatr(ref array, minVal, maxVal);

                Console.WriteLine("Полученная матрица: ");
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                    {
                        Console.Write(" {0} ", array[i, j]);
                    }
                    Console.WriteLine();
                }

                SearchMinMax(ref array, out min, out max, out mini, out minj, out maxi, out maxj);

                Console.WriteLine("Минимальный элемент: {0} [{1}, {2}]", min, mini + 1, minj + 1);
                Console.WriteLine("Максимальный элемент: {0} [{1}, {2}]", max, maxi + 1, maxj + 1);
            }
            else
            {
                Console.WriteLine("Вы ввели что-то не то.");
                return;
            }

            #endregion

            #region --- === ###   Замена строк или столбцов   ### === ---

            Console.WriteLine("Теперь выберите что будем менять местами: ");
            Console.WriteLine("Введите 1 для строк.");
            Console.WriteLine("Введите 2 для столбцов.");

            bool isInt4 = Int32.TryParse(Console.ReadLine(), out choice2);

            if (isInt4 == false)
            {
                Console.WriteLine("Вы ввели что-то не то.");
                return;
            }

            if (choice2 == 1)
            {
                ChangeLines(ref array, mini, maxi);

                Console.WriteLine("Полученная матрица: ");
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                    {
                        Console.Write(" {0} ", array[i, j]);
                    }
                    Console.WriteLine();
                }

                SearchMinMax(ref array, out min, out max, out mini, out minj, out maxi, out maxj);

                Console.WriteLine("Минимальный элемент: {0} [{1}, {2}]", min, mini + 1, minj + 1);
                Console.WriteLine("Максимальный элемент: {0} [{1}, {2}]", max, maxi + 1, maxj + 1);
            }

            if (choice2 == 2)
            {
                ChangeColumns(ref array, minj, maxj);

                Console.WriteLine("Полученная матрица: ");
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                    {
                        Console.Write(" {0} ", array[i, j]);
                    }
                    Console.WriteLine();
                }

                SearchMinMax(ref array, out min, out max, out mini, out minj, out maxi, out maxj);

                Console.WriteLine("Минимальный элемент: {0} [{1}, {2}]", min, mini + 1, minj + 1);
                Console.WriteLine("Максимальный элемент: {0} [{1}, {2}]", max, maxi + 1, maxj + 1);
            }
            //else
            //{
            //    Console.WriteLine("Вы ввели что-то не то.");
            //    return;
            //}

            Console.ReadKey();

            #endregion
        }

        #endregion
    }
}
