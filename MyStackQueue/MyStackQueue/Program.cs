using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStackQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack s = new MyStack();

            s.Push(2);
            s.Push(8);
            s.Push(14);

            s.Print();

            s.Pop();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(s.Peek());
            Console.WriteLine();

            MyQueue q = new MyQueue();

            q.Enqueue(15);
            q.Enqueue(2);
            q.Enqueue(34);

            q.Print();
            Console.WriteLine();

            q.Dequeue();

            Console.WriteLine();
            q.Print();

            Console.ReadKey();
        }
    }
}
