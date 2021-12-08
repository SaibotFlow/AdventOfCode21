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
        private readonly List<int[,]> _Boards = new List<int[,]>();
        private readonly int[] _WinningNumbers;

        internal class BingoBoard
        {
            public int[,] Board;
            public SortedList<int, int> RowMarks;
            public SortedList<int, int> ColumnMarks;
            public int WinRank;
            public int LastWinNumber;
            public bool HasWon = false;


            private static int RankCounter = 1;

            public BingoBoard(int[,] Board)
            {
                this.Board = Board;
                RowMarks = new SortedList<int, int>() { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 } };
                ColumnMarks = new SortedList<int, int>() { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 } };

            }
            public bool MarkHit(int rowIndex, int columnIndex, int winNumber)
            {
                this.Board[rowIndex, columnIndex] = -1;
                this.RowMarks[rowIndex]++;
                this.ColumnMarks[columnIndex]++;
                if (!this.HasWon && (RowMarks.Values.Contains(5) || ColumnMarks.Values.Contains(5)))
                {
                    this.LastWinNumber = winNumber;
                    this.WinRank = RankCounter++;
                    this.HasWon = true;
                    return true;
                }
               
                return false;
            }
            public int Sum()
            {
                return this.Board.Cast<int>().Where(x => x > -1).ToArray().Sum();
            }
        }


        public Day04()
        {
            var all = File.ReadAllLines(InputFilePath).ToArray();
            _WinningNumbers = all.First().Split(",").Select(x => Convert.ToInt32(x)).ToArray();
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
                _Boards.Add(newBoard);
            }
        }
        public override ValueTask<string> Solve_1()
        {

            var bingoBoards = _Boards.Select(x => new BingoBoard((int[,])x.Clone())).ToList();
            foreach (var number in _WinningNumbers)
            {
                foreach (var bingoBoard in bingoBoards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (bingoBoard.Board[i, j] == number)
                            {
                                if (bingoBoard.MarkHit(i, j,number))
                                    return new((bingoBoard.Sum() * number).ToString());
                            }
                        }
                    }
                }
            }
            return new("");
        }



        public override ValueTask<string> Solve_2()
        {
            var bingoBoards = _Boards.Select(x => new BingoBoard((int[,])x.Clone())).ToList();
            foreach (var number in _WinningNumbers)
            {
                foreach (var bingoBoard in bingoBoards)
                {
                    if (bingoBoard.HasWon)
                        continue;
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (bingoBoard.Board[i, j] == number)
                                bingoBoard.MarkHit(i, j, number);
                        }
                    }
                }
            }
            bingoBoards = bingoBoards.OrderBy(e => e.WinRank).ToList();
            return new((bingoBoards.Last().Sum() * bingoBoards.Last().LastWinNumber).ToString());
        }

    }
}
