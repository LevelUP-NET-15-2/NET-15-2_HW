using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStackQueue
{
    public class MyException : Exception
    {
        public static void MyEmptyStackException()
        {
            Console.WriteLine("Стек пуст!");
        }

        public static void MyNoElemStackException()
        {
            Console.WriteLine("Стек не содержит элемента с указанным индексом!");
        }

        public static void MyEmptyQueueException()
        {
            Console.WriteLine("Очередь пуста!");
        }

        public static void MyNoElemQueueException()
        {
            Console.WriteLine("Очередь не содержит элемента с указанным индексом!");
        }
    }
}
