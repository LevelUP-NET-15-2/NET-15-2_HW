using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
	/// <summary>
	/// A Tetris Game Handler
	/// </summary>
	public class Tetris
	{
        /// <summary>
        /// Universal delegate for some actions
        /// </summary>
        /// <param name="Lines">Number of Lines the Player did</param
        public delegate void GameHandler(int Lines = 0);

		/// <summary>
		/// Game is over Buddy!
		/// </summary>
		public event GameHandler GameOver;
		/// <summary>
		/// Block fixed.
		/// </summary>
		public event GameHandler BlockFixed;
		/// <summary>
		/// YOU made lines?
		/// </summary>
		public event GameHandler LinesDone;

		/// <summary>
		/// Available Tetris Keys
		/// </summary>
		public enum Key
		{
			Left,
			Right,
			Up,
			Down,
			rRight,
			rLeft
		}

		/// <summary>
		/// The Playfield
		/// </summary>
		private int[,] _container;
		/// <summary>
		/// X Coord of Block
		/// </summary>
		private int _posX;
		/// <summary>
		/// Y Coord of Block
		/// </summary>
		private int _posY;
		/// <summary>
		/// Current moving Block
		/// </summary>
		private int[,] _currBlock=null;
		/// <summary>
		/// next Block
		/// </summary>
		private int[,] _nextBlock = null;
		/// <summary>
		/// Block generator and Manager
		/// </summary>
		private Block _bGen=new Block();
		/// <summary>
		/// True as long as the Game is running
		/// (well if you play this is not so long in "true" state)
		/// </summary>
		private bool _inGame;
		/// <summary>
		/// Draw shadow Block [y/n]?
		/// </summary>
		private bool _shadow;

		/// <summary>
		/// initializes a new Tetris Game
		/// </summary>
		/// <param name="Width">Width of Container (without Border) >=10</param>
		/// <param name="Height">Height of Container (without Border) >=20</param>
		public Tetris(int Width, int Height)
		{
			_shadow = true;
			_container = new int[Height, Width];
		}

		/// <summary>
		/// Starts a Game or gets the next Block
		/// </summary>
		public void start()
		{
			_inGame = true;
			_posY = 0;
			_posX= _container.GetUpperBound(1)/2;
			_currBlock = _nextBlock != null ? _nextBlock : _bGen.getRandomBlock();
			_nextBlock = _bGen.getRandomBlock();
			if(!canPosAt(_currBlock, _posX, _posY))
			{
				gameOver();
			}
		}

		/// <summary>
		/// Game is over
		/// </summary>
		public void gameOver()
		{
			_inGame = false;
			if(GameOver != null)
			{
				GameOver();
			}
		}

		/// <summary>
		/// Advances the Game by one step
		/// </summary>
		public void step()
		{
			if(_inGame)
			{
				if(canPosAt(_currBlock, _posX, _posY + 1))
				{
					_posY++;
				}
				else
				{
					_container=fixBlock(_currBlock,_container, _posX, _posY);

					start();
				}

				int Lines=checkLines();

				if(LinesDone != null)
				{
					LinesDone(Lines);
				}
			}
		}

		/// <summary>
		/// Handle pressed Tetris Key
		/// </summary>
		/// <param name="k">Tetris Key</param>
		public void keyPress(Key k)
		{
			if(_inGame)
			{
				int[,] temp;
				switch(k)
				{
					case Key.Down:
						step();
						break;
					case Key.Left:
						if(_posX>0 && canPosAt(_currBlock, _posX - 1, _posY))
						{
							_posX--;
						}
						break;
					case Key.Right:
						if(_posX<_container.GetUpperBound(0)-_currBlock.GetUpperBound(0) && canPosAt(_currBlock, _posX +1, _posY))
						{
							_posX++;
						}
						break;
					case Key.rLeft:
						temp = Block.rotateL(_currBlock);
						if(canPosAt(temp, _posX, _posY))
						{
							_currBlock = Block.rotateL(_currBlock);
						}
						break;
					case Key.rRight:
						temp = Block.rotateR(_currBlock);
						if(canPosAt(temp, _posX, _posY))
						{
							_currBlock = Block.rotateR(_currBlock);
						}
						break;
					case Key.Up:
						while(canPosAt(_currBlock, _posX, _posY+1))
						{
							step();
						}
						step();
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Checks if a Block can be positioned at a specific Location
		/// </summary>
		/// <param name="Block">Block to check</param>
		/// <param name="x">X Pos (0 based)</param>
		/// <param name="y">Y Pos (0 based)</param>
		/// <returns>true, if positionable</returns>
		private bool canPosAt(int[,] Block, int x, int y)
		{
			int[,] copy = (int[,])_container.Clone();

			if(x+Block.GetUpperBound(1) <= copy.GetUpperBound(1) && y+Block.GetUpperBound(0) <= copy.GetUpperBound(0))
			{
				for(int i = 0;i <= Block.GetUpperBound(1);i++)
				{
					for(int j = 0;j <= Block.GetUpperBound(0);j++)
					{
						//I=X Coord
						//J=Y Coord
						if(Block[j, i] != 0)
						{
							if(copy[y + j, x + i] != 0)
							{
								return false;
							}
						}
					}
				}
				return true;
			}
			return false;
		}

		/// <summary>
		/// Fixes a Block in the Field and returns the new field
		/// </summary>
		/// <param name="Block">Block to fix</param>
		/// <param name="field">Field to use</param>
		/// <param name="x">X Pos to fix (0 based)</param>
		/// <param name="y">Y Pos to fix (0 based)</param>
		/// <returns>New Field with fixed Block</returns>
		private int[,] fixBlock(int[,] Block,int[,] field, int x, int y)
		{
			if(x + Block.GetUpperBound(1) <= field.GetUpperBound(1) && y + Block.GetUpperBound(0) <= field.GetUpperBound(0))
			{
				for(int i = 0;i <= Block.GetUpperBound(1);i++)
				{
					for(int j = 0;j <= Block.GetUpperBound(0);j++)
					{
						//I=Y Coord
						//J=X Coord
						if(Block[j, i] != 0)
						{
							field[y + j, x + i] = Block[j, i];
						}
					}
				}
			}
			if(BlockFixed != null)
			{
				BlockFixed();
			}
			return field;
		}

		/// <summary>
		/// Checks for complete Lines and returns the Number of Lines found (and removed)
		/// </summary>
		/// <returns></returns>
		private int checkLines()
		{
			for(int i = 0;i < _container.GetUpperBound(0) + 1;i++)
			{
				bool isFullLine = true;
				for(int j = 0;j < _container.GetUpperBound(1) + 1;j++)
				{
					isFullLine = isFullLine && _container[i, j] != 0;
				}
				if(isFullLine)
				{
					removeLine(i--);
					return checkLines() + 1;
				}
			}
			return 0;
		}

		/// <summary>
		/// Removes a Line at the specific Index
		/// </summary>
		/// <param name="index">Y Pos (0 Based)</param>
		private void removeLine(int index)
		{
			//move lines one down
			for(int i = index;i > 0;i--)
			{
				for(int j = 0;j <= _container.GetUpperBound(1);j++)
				{
					_container[i, j] = _container[i-1, j];
				}
			}
			//empty top line
			for(int j = 0;j <= _container.GetUpperBound(1);j++)
			{
				_container[0, j] = 0;
			}
		}

		/// <summary>
		/// The Actual Game Field (readonly)
		/// </summary>
		public int[,] Level
		{
			get
			{
				int[,] Block = (int[,])_currBlock.Clone();
				int[,] temp = (int[,])_container.Clone();
				int add=0;


				for(int i = 0;i <= Block.GetUpperBound(0);i++)
				{
					for(int j = 0;j <= Block.GetUpperBound(1);j++)
					{
						if(Block[i, j] != 0)
						{
							Block[i, j] = 7;
						}
					}
				}
				temp=fixBlock(Block,temp,_posX,_posY);

				if(_shadow)
				{
					for(int i = 0;i <= Block.GetUpperBound(0);i++)
					{
						for(int j = 0;j <= Block.GetUpperBound(1);j++)
						{
							if(Block[i, j] != 0)
							{
								Block[i, j] = 8;
							}
						}
					}

					while(canPosAt(Block, _posX, _posY + add))
					{
						add++;
					}

					if(_posY + add - 1 > 0)
					{
						return (int[,])fixBlock(Block, temp, _posX, _posY + add - 1).Clone();
					}
				}
				return temp;
			}
		}

		/// <summary>
		/// Game running State (readonly)
		/// </summary>
		public bool running
		{
			get
			{
				return _inGame;
			}
		}

		/// <summary>
		/// The Next Block to be played (readonly)
		/// </summary>
		public int[,] Next
		{
			get
			{
				return _nextBlock;
			}
		}

		/// <summary>
		/// Should the Level Property display a block,
		/// where the actual Block would land [y/n]?
		/// </summary>
		public bool shadowBlock
		{
			get
			{
				return _shadow;
			}
			set
			{
				_shadow = value;
			}
		}
	}
}
