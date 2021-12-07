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
            throw new NotImplementedException();
        }

        public override ValueTask<string> Solve_2()
        {
            throw new NotImplementedException();
        }
    }
}
