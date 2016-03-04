using System;
using System.Threading;

namespace Tetris
{
	class Program
	{
		/// <summary>
		/// Tetris Game
		/// </summary>
		private static Tetris _t;
		/// <summary>
		/// Mover Thread
		/// </summary>
		private static Thread _mover;
		/// <summary>
		/// Lock of Drawing Function
		/// </summary>
		private static bool _drawLock;
		/// <summary>
		/// Counts poins/Lines
		/// </summary>
		private static int _points;

		/// <summary>
		/// Counter for the Worker thread
		/// </summary>
		static int threadCounter = 0;

		#region "Drawing" CONSTANTS
			//Shadowing
			private const string BLOCK = "█";

			private const string ACTIVE = "█";

			private const string BAKER = "█";

			private const string EMPTY = " ";

			private const string SHADOW = "▒";
		#endregion

		/// <summary>
		/// Steps for the stepper thread
		/// </summary>
		private const int _step = 10;

		/// <summary>
		/// Show next block [y/n]?
		/// </summary>
		private static bool _showNext;

		/// <summary>
		/// Field for the "Next" Block
		/// </summary>
		private static readonly int[,] _clearBlock = new int[,]
		{
			{0,0,0,0},
			{0,0,0,0},
			{0,0,0,0},
			{0,0,0,0}
		};

		/// <summary>
		/// Main Application loop
		/// </summary>
		/// <param name="args">Stupid Args</param>
		/// <returns>0</returns>
		static int Main(string[] args)
		{
			//preparing Console
			Console.Clear();
			Console.Beep(600, 500);
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.CursorVisible = false;

			//Intro
			Console.Write(@"
Controls:
[→]   Move Block Right
[←]   Move Block Left
[↑]   Smash Bloock down
[↓]   Push block down 1 Unit
[S]   Turn Clockwise
[A]   Turn Clockwise 3 Times ;-)
[G]   Turn ghost Block on and off (Default on)
[N]   Turn Next Block on and off
[ESC] Exit Game

Press a Key to start
");
			Console.ReadKey(true);
			Console.Clear();

			//Default Values and Game initialization
			_showNext = true;

			_points = 0;
			_drawLock = false;
			_t = new Tetris(10,20);
			_t.LinesDone += new Tetris.GameHandler(t_LinesDone);

			//Start Game and run "Mover" Thread
			_t.start();
			_mover = new Thread(new ThreadStart(stepper));
			_mover.IsBackground = true;
			_mover.Start();

			//Keyboard handler
			while(_t.running)
			{
				Thread.Sleep(10);
				if(Console.KeyAvailable)
				{
					lock(_t)
					{
						switch(Console.ReadKey(true).Key)
						{
							case ConsoleKey.LeftArrow:
								_t.keyPress(Tetris.Key.Left);
								break;

							case ConsoleKey.RightArrow:
								_t.keyPress(Tetris.Key.Right);
								break;

							case ConsoleKey.UpArrow:
								_t.keyPress(Tetris.Key.Up);
								threadCounter = 0;
								break;

							case ConsoleKey.DownArrow:
								_t.keyPress(Tetris.Key.Down);
								threadCounter = 0;
								break;

							case ConsoleKey.A:
								_t.keyPress(Tetris.Key.rLeft);
								break;

							case ConsoleKey.S:
								_t.keyPress(Tetris.Key.rRight);
								break;

							case ConsoleKey.N:
								_showNext = !_showNext;
								break;

							case ConsoleKey.G:
								_t.shadowBlock= !_t.shadowBlock;
								break;

							case ConsoleKey.Escape:
								_t.gameOver();
								break;

							default:
								break;
						}
						drawField();
					}
				}
			}
			//Wait for thread to end and then End the Game and close
			Thread.Sleep(1000);
			Console.Clear();

			writeCol(string.Format("You made {0} lines. Press Esc to exit",_points),ConsoleColor.Red);

			while(Console.ReadKey(true).Key != ConsoleKey.Escape);
			Console.ResetColor();
			Console.CursorVisible = true;

			return 0;
		}

		/// <summary>
		/// Counts Lines
		/// </summary>
		/// <param name="Lines">Number of Lines made</param>
		static void t_LinesDone(int Lines)
		{
			_points += Lines;
		}

		/// <summary>
		/// Mover Thread, makes the Game to step forward
		/// </summary>
		static void stepper()
		{
			while(_t.running)
			{
				threadCounter=0;
				_t.step();
				drawField();
				//Increase Speed when Lines are made
				while(threadCounter < 1000 - (_points * 5) && _t.running)
				{
					Thread.Sleep(_step);
					threadCounter += _step;
				}
			}
		}

		/// <summary>
		/// Draw Handler for the Field
		/// </summary>
		private static void drawField()
		{
			//locks the Field
			while(_drawLock);
			_drawLock = true;

			//Current Position
			int posX = Console.CursorLeft;
			int posY = Console.CursorTop;

			//Draw points
			Console.CursorLeft = 13;
			Console.CursorTop = 2;
			Console.WriteLine("Lines: {0}",_points);

			//Draw Field
			Console.SetCursorPosition(posX, posY);
			writeArr(_t.Level, true);

			//Draw next Block
			Console.CursorLeft = 13;
			Console.CursorTop = 3;
			writeArr(_clearBlock,true);
			if(_showNext)
			{
				Console.CursorLeft = 14;
				Console.CursorTop = 4;
				writeArr(_t.Next, false);
			}

			//Back to the Future, err... Beginning
			Console.SetCursorPosition(posX, posY);
			_drawLock = false;
		}

		/// <summary>
		/// Writes a 2D Array to the Console
		/// </summary>
		/// <param name="qq">Array</param>
		/// <param name="writeBorder">Write Border around Array?</param>
		static void writeArr(int[,] qq,bool writeBorder)
		{
			int x = Console.CursorLeft;
			for(int i = 0;i <= qq.GetUpperBound(0);i++)
			{
				if(writeBorder)
				{
					Console.Write(BAKER);
				}
				for(int j = 0;j <= qq.GetUpperBound(1);j++)
				{
					//Change color according to the Number
					switch(qq[i, j])
					{
						case 1:
							writeCol(BLOCK, ConsoleColor.White);
							break;

						case 2:
							writeCol(BLOCK, ConsoleColor.Magenta);
							break;

						case 3:
							writeCol(BLOCK, ConsoleColor.Blue);
							break;

						case 4:
							writeCol(BLOCK, ConsoleColor.Green);
							break;

						case 5:
							writeCol(BLOCK, ConsoleColor.Yellow);
							break;

						case 6:
							writeCol(BLOCK, ConsoleColor.Red);
							break;

						case 7:
							Console.BackgroundColor = ConsoleColor.Red;
							writeCol(ACTIVE, ConsoleColor.Cyan);
							Console.BackgroundColor = ConsoleColor.Black;
							break;

						case 8:
							Console.BackgroundColor = ConsoleColor.Gray;
							writeCol(SHADOW, ConsoleColor.Gray);
							Console.BackgroundColor = ConsoleColor.Black;
							break;

						default:
							Console.Write(EMPTY);
							break;
					}
				}
				if(writeBorder)
				{
					Console.WriteLine(BAKER);
				}

				else
				{
					Console.WriteLine();
				}
				Console.CursorLeft = x;
			}
			for(int q = 0;q <= qq.GetUpperBound(1)+2;q++)
			{
				if(writeBorder)
				{
					Console.Write(BAKER);
				}
			}
		}

		/// <summary>
		/// Writes a String in the Specified foreground color,
		/// then switches the Color back
		/// </summary>
		/// <param name="a">String</param>
		/// <param name="b">Color</param>
		static void writeCol(string a, ConsoleColor b)
		{
			ConsoleColor c = Console.ForegroundColor;
			Console.ForegroundColor = b;
			Console.Write(a);
			Console.ForegroundColor = c;
		}
	}
}
