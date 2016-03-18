using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStackQueue
{
    public class MyQueue
    {
        private class MyElem
        {
            public int Data { get; set; }

            public MyElem Next { get; set; }
        }

        private MyElem _first = null;

        public void Enqueue(int x)
        {
            MyElem newElem = new MyElem() { Data = x, Next = null };

            if (_first == null)
            {
                _first = newElem;
            }
            else
            {
                MyElem currElem = _first;

                while (currElem.Next != null)
                {
                    currElem = currElem.Next;
                }

                currElem.Next = newElem;
            }
        }

        public void Dequeue()
        {
            if (_first == null)
            {
                MyException.MyEmptyQueueException();
            }
            else
            {
                _first = _first.Next;
            }
        }

        public int GetElemByPos(int val)
        {
            if (_first == null)
            {
                MyException.MyEmptyQueueException();
            }
            else
            {
                if (_first.Next == null)
                {
                    int data = _first.Data;

                    return data;
                }
                else
                {
                    MyElem currElem = _first;

                    int i = 0;

                    while (currElem.Next != null)
                    {
                        if (i == val)
                        {
                            return currElem.Data;
                        }

                        ++i;
                        currElem = currElem.Next;
                    }
                }
            }

            MyException.MyNoElemQueueException();

            return 0;
        }


        public void Print()
        {
            if (_first == null)
            {
                MyException.MyEmptyQueueException();
            }
            else
            {
                if (_first.Next == null)
                {
                    Console.WriteLine(_first.Data);
                }
                else
                {
                    MyElem currElem = _first;

                    while (currElem != null)
                    {
                        Console.Write(" {0} ", currElem.Data);
                        currElem = currElem.Next;
                    }
                }
            }
        }
    }
}
