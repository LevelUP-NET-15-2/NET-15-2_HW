using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps3
{
    public class Program
    {
        public enum Hand { Rock = 1, Paper, Scissors };
        static int playerScore = 0;
        static int computerScore = 0;

        public static void Main()
        {
            Hand playerHand;
            Hand computerHand;

            int checkHand;

            int gameLoop = 1;


            Console.WriteLine("Let play Rock-Paper-Scissors game");

            // игровой цикл
            do
            {
                Console.WriteLine("Make your choice");
                Console.WriteLine("input 1 for Rock, 2 for Paper, 3 for Scissors");



                checkHand = CheckInput(1, 3);

                playerHand = (Hand)(Convert.ToInt32(checkHand));

                Console.Clear();
                Console.WriteLine("Good. Your hand is {0}...", playerHand);
                Console.WriteLine("and...");


                computerHand = GetComputerHand();

                Console.WriteLine("Computer hand is {0}", computerHand);
                Console.WriteLine();
                GetResult(playerHand, computerHand);
                Console.WriteLine("The total score is {0}:{1}", playerScore, computerScore);
                Console.WriteLine("Whis to play again? Input 1 for YES, 0 for NO");

                gameLoop = CheckInput(0, 1);
                Console.Clear();
            }
            while (gameLoop != 0);



        }

        // метод проверки числового ввода
        private static int CheckInput(int s, int f)
        {
            bool result = false;
            int input = 0;

            do
            {

                result = Int32.TryParse(Console.ReadLine(), out input);
                if (!result | input > f | input < s)
                {
                    Console.WriteLine("Invalid input. Try Again");
                }
            }
            while (!result | input > f | input < s);

            return input;
        }

        // метод определяющий и выводящий результат

        public static void GetResult(Hand p, Hand c)
        {
            if (p == c)
            {
                Console.WriteLine("A TIE this time");
            }
            else if (p == Hand.Paper && c == Hand.Rock)
            {
                Console.WriteLine("Lucky you! You WIN !");
                playerScore += 1;
            }
            else if (p == Hand.Rock && c == Hand.Scissors)
            {
                Console.WriteLine("Lucky you! You WIN !");
                playerScore += 1;
            }
            else if (p == Hand.Scissors && c == Hand.Paper)
            {
                Console.WriteLine("Lucky you! You WIN !");
                playerScore += 1;
            }
            else
            {
                Console.WriteLine("What a pitty. You LOSE");
                computerScore += 1;
            }

        }
        public static Hand GetComputerHand()
        {
            var rand = new Random();
            Hand computerHand;

            computerHand = (Hand)rand.Next(1, 4);
            return computerHand;
        }
    }
}
