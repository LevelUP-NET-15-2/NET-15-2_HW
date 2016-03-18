using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStackQueue
{
    public class MyStack
    {
        private class MyElem
        {
            public int Data { get; set; }

            public MyElem Next { get; set; }
        }

        private MyElem _first = null;

        public void Push(int x)
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

        public void Pop()
        {
            if (_first == null)
            {
                MyException.MyEmptyStackException();
            }
            else
            {
                if (_first.Next == null)
                {
                    _first = null;
                }
                else
                {
                    MyElem currElem = _first;

                    while (currElem.Next.Next != null)
                    {
                        currElem = currElem.Next;
                    }

                    currElem.Next = null;
                }
            }
        }

        public int Peek()
        {
            if (_first == null)
            {
                MyException.MyEmptyStackException();
            }
            else
            {
                if (_first.Next == null)
                {
                    int retVal = _first.Data;

                    return retVal;
                }
                else
                {
                    MyElem currElem = _first;

                    while (currElem.Next.Next != null)
                    {
                        currElem = currElem.Next;
                    }

                    int retVal1 = currElem.Next.Data;

                    return retVal1;
                }
            }

            return 0;
        }

        public int GetElemByPos(int val)
        {
            if (_first == null)
            {
                MyException.MyEmptyStackException();
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

            MyException.MyNoElemStackException();

            return 0;
        }


        public void Print()
        {
            if (_first == null)
            {
                MyException.MyEmptyStackException();
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
