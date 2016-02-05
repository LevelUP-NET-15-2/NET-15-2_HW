using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160205_Polymorph1
{
    class Program
    {
        static void Main(string[] args)
        {
            int worknum = 0;
            int managnum = 0;
            int presnum = 0;

            DataEnter.EnterNumberOfEmployers(out worknum, out managnum, out presnum);

            Worker[] workers = DataEnter.EnterWorkersData(worknum);

            for (int i = 0; i < workers.Length; i++)
            {
                workers[i].Print();
            }  
        }
    }
}
