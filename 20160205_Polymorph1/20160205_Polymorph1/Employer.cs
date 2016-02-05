using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160205_Polymorph1
{
    public abstract class Employer
    {
        public virtual void Print()
        {
            Console.WriteLine("Вывод информации базового класса.");
            Console.ReadKey();
        }
    }
}
