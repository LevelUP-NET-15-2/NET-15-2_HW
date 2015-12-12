using System;

namespace _151211_FuncHW5
{
    class Schedule
    {
        [Flags]
        public enum WeekFlag : int
        {
            Empty = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64
        }

        public Schedule(string[] dayssp)
        {
            WeekFlag wf = new WeekFlag();
            string[] days_split = dayssp;

            for (int i = 0; i < days_split.Length; i++)
            {
                switch (days_split[i])
                {
                    case "ПОНЕДЕЛЬНИК":
                        wf |= WeekFlag.Monday;
                        break;

                    case "ВТОРНИК":
                        wf |= WeekFlag.Tuesday;
                        break;

                    case "СРЕДА":
                        wf |= WeekFlag.Wednesday;
                        break;

                    case "ЧЕТВЕРГ":
                        wf |= WeekFlag.Thursday;
                        break;

                    case "ПЯТНИЦА":
                        wf |= WeekFlag.Friday;
                        break;

                    case "СУББОТА":
                        wf |= WeekFlag.Saturday;
                        break;

                    case "ВОСКРЕСЕНЬЕ":
                        wf |= WeekFlag.Sunday;
                        break;

                    default:
                        break;
                }
            }

            if ((wf.HasFlag(WeekFlag.Monday)))
            {
                Console.WriteLine("У вас есть занятия в понедельник");
            }
            if ((wf.HasFlag(WeekFlag.Tuesday)))
            {
                Console.WriteLine("У вас есть занятия во вторник");
            }
            if ((wf.HasFlag(WeekFlag.Wednesday)))
            {
                Console.WriteLine("У вас есть занятия в среду");
            }
            if ((wf.HasFlag(WeekFlag.Thursday)))
            {
                Console.WriteLine("У вас есть занятия в четверг");
            }
            if ((wf.HasFlag(WeekFlag.Friday)))
            {
                Console.WriteLine("У вас есть занятия в пятницу");
            }
            if ((wf.HasFlag(WeekFlag.Saturday)))
            {
                Console.WriteLine("У вас есть занятия в субботу");
            }
            if ((wf.HasFlag(WeekFlag.Sunday)))
            {
                Console.WriteLine("У вас есть занятия в воскресенье");
            }
        }
    }
}
