using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160305_UserListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList lst = new MyList();

            lst.AddToEnd(10);
            lst.AddToEnd(20);
            lst.AddToEnd(30);


            Console.WriteLine(lst.IsExist(30));
            Console.WriteLine(lst.IsExist(60));


            try
            {
                Console.WriteLine(lst.GetFirst());
                Console.WriteLine(lst.GetFirst());
                Console.WriteLine(lst.GetFirst());
                Console.WriteLine(lst.GetFirst());
                Console.WriteLine(lst.GetFirst());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            MyList lst1 = new MyList();

            lst1.AddToEnd(110);
            lst1.AddToEnd(120);
            lst1.AddToEnd(130);

            Console.WriteLine(lst1.GetElemByPos(2));

            Console.WriteLine(lst1[1]);

            Console.WriteLine(lst1.Length());

            Console.WriteLine(lst1.GetAmountOfElems(220));

            lst1.DelElem(1);

            Console.WriteLine(lst1.Length());
        }
    }
}
