﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
	/// <summary>
	/// Tetris Block Handler
	/// </summary>
	public class Block
	{
		/// <summary>
		/// List of Tetris Blocks
		/// </summary>
		private List<int[,]> _blocks;
		/// <summary>
		/// Random Block generator
		/// </summary>
		private Random _r;

		/// <summary>
		/// Provides some basic Tetris Block Functions
		/// </summary>
		public Block()
		{
			_r = new Random(DateTime.Now.Millisecond);

			_blocks = new List<int[,]>();

			//####
			_blocks.Add(new int[1, 4] { { 1, 1, 1, 1 } });

			//##
			//##
			_blocks.Add(new int[2, 2] { { 2, 2 }, { 2, 2 } });

			//  #
			//###
			_blocks.Add(new int[2, 3] { { 0, 0, 3}, { 3, 3, 3 } });

			//#
			//###
			_blocks.Add(new int[2, 3] { { 4, 0, 0 }, { 4, 4, 4 } });

			// ##
			//##
			_blocks.Add(new int[2, 3] { { 0, 5, 5 }, { 5, 5, 0 } });

			//##
			// ##
			_blocks.Add(new int[2, 3] { { 6, 6, 0 }, { 0, 6, 6 } });
		}

		/// <summary>
		/// Returns a specific Block
		/// </summary>
		/// <param name="ID">ID of Block (0-5)</param>
		/// <returns>the Bock (or null if invalid Value)</returns>
		public int[,] getBlock(int ID)
		{
			if(_blocks.Count > ID && ID >= 0)
			{
				return _blocks[ID];
			}
			return null;
		}

		/// <summary>
		/// Returns a random Block
		/// </summary>
		/// <returns>Random Block</returns>
		public int[,] getRandomBlock()
		{
			return _blocks[_r.Next(_blocks.Count)];
		}

		/// <summary>
		/// Rotates a Block clockwise
		/// </summary>
		/// <param name="block">Block to rotate</param>
		/// <returns>rotated Block</returns>
		public static int[,] rotateR(int[,] block)
		{
			int w = block.GetUpperBound(0)+1;
			int h = block.GetUpperBound(1)+1;
			int[,] rotated = new int[h,w];
			for(int i = 0;i < w;i++)
			{
				for(int j = 0;j < h;j++)
				{
					rotated[j, w-i-1] = block[i, j];
				}
			}

			return rotated;
		}

		/// <summary>
		/// Rotates a Block clockwise 3 Times
		/// (thats no joke, go see the Function)
		/// </summary>
		/// <param name="block">Block to rotate</param>
		/// <returns>rotated Block</returns>
		public static int[,] rotateL(int[,] block)
		{
			return rotateR(rotateR(rotateR(block)));
		}
	}
}
