namespace _20160205_Polymorph1
{
    class Program
    {
        static void Main(string[] args)
        {
            uint worknum = 0;
            uint managnum = 0;
            uint presnum = 0;

            DataEnter.EnterNumberOfEmployers(out worknum, out managnum, out presnum);

            Employer[] employers = new Employer[worknum + managnum + presnum];

            for (int i = 0; i < worknum; i++)
            {
                employers[i] = DataEnter.EnterWorkerData();
            }

            for (int i = (int)worknum; i < (int)managnum + (int)worknum; i++)
            {
                employers[i] = DataEnter.EnterManagerData();
            }

            for (int i = (int)worknum + (int)managnum; i < presnum + worknum + managnum; i++)
            {
                employers[i] = DataEnter.EnterPresidentData();
            }

            for (int i = 0; i < employers.Length; i++)
            {
                employers[i].Print();
            }  
        }
    }
}
