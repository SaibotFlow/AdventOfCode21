using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode21
{
    public class Day04 : BaseDay
    {
        private readonly List<int[,]> Boards = new List<int[,]>();
        private readonly int[] WinningNumbers;


        public Day04()
        {
            var all = File.ReadAllLines(InputFilePath).ToArray();
            WinningNumbers = all.First().Split(",").Select(x => Convert.ToInt32(x)).ToArray();
            all = all.Skip(2).ToArray();
            all = all.Where(line => line != String.Empty).ToArray();
            if (all.Length % 5 != 0)
                throw new InvalidDataException("InputData is corrupt");
            for (int i = 0; i < all.Length; i+=5)
            {
                var newBoard = new int[5, 5];
                for (int j = 0; j < 5; j++)
                {
                    int[] lineNumbers = all[i+j].Split(" ").Where(x => x != String.Empty).Select(x => Convert.ToInt32(x)).ToArray();
                    for (int k = 0; k < 5; k++)
                    {
                        newBoard[j, k] = lineNumbers[k];
                    }
                }
                Boards.Add(newBoard);
            }
        }
        public override ValueTask<string> Solve_1()
        {

            var bingoBoards = this.Boards.Select(x => new BingoBoard(x)).ToList();
            foreach (var number in WinningNumbers)
            {
                foreach (var bingoBoard in bingoBoards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (bingoBoard.Board[i, j] == number)
                            {
                                if (bingoBoard.MarkHit(i, j))
                                {
                                    return new((bingoBoard.Sum() * number).ToString());
                                }
                            }
                        }
                    }
                }
            }
            return new("");
        }

        internal class BingoBoard
        {
            public int[,] Board;
            public SortedList<int, int> RowMarks;
            public SortedList<int, int> ColumnMarks;

            public BingoBoard(int[,] Board)
            {
                this.Board = Board;
                RowMarks = new SortedList<int, int>() { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 } };
                ColumnMarks = new SortedList<int, int>() { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 } };
            }
            public bool MarkHit(int rowIndex, int columnIndex)
            {
                this.Board[rowIndex, columnIndex] = -1;
                this.RowMarks[rowIndex]++;
                this.ColumnMarks[columnIndex]++;
                if (RowMarks.Values.Contains(5) || ColumnMarks.Values.Contains(5))
                    return true;
                return false;
            }
            public int Sum()
            {
                return this.Board.Cast<int>().Where(x => x > -1).ToArray().Sum();
            }
        }

        public override ValueTask<string> Solve_2()
        {
            //throw new NotImplementedException();
            return new("");
        }




    }
}
