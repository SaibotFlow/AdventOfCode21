using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode21
{
    public class Day08 : BaseDay
    {
        /*
              0:      1:      2:      3:      4:
             aaaa    ....    aaaa    aaaa    ....
            b    c  .    c  .    c  .    c  b    c
            b    c  .    c  .    c  .    c  b    c
             ....    ....    dddd    dddd    dddd
            e    f  .    f  e    .  .    f  .    f
            e    f  .    f  e    .  .    f  .    f
             gggg    ....    gggg    gggg    ....

              5:      6:      7:      8:      9:
             aaaa    aaaa    aaaa    aaaa    aaaa
            b    .  b    .  .    c  b    c  b    c
            b    .  b    .  .    c  b    c  b    c
             dddd    dddd    ....    dddd    dddd
            .    f  e    f  .    f  e    f  .    f
            .    f  e    f  .    f  e    f  .    f
             gggg    gggg    ....    gggg    gggg

         */

        List<Tuple<string[], string[]>> Data = new List<Tuple<string[], string[]>>();

        public Day08()
        {
            var lines = File.ReadAllLines(InputFilePath);
            foreach (var line in lines)
            {
                var splitedByPipe = line.Split("|");
                Data.Add(new Tuple<string[], string[]>(splitedByPipe[0].Split(" ").Where(x => !String.IsNullOrEmpty(x)).ToArray(), splitedByPipe[1].Split(" ").Where(x => !String.IsNullOrEmpty(x)).ToArray()));
            }
        }

        public override ValueTask<string> Solve_1()
        {
            int ones = 0;
            int fours = 0;
            int sevens = 0;
            int eights = 0;
            foreach (var data in Data)
            {
                
                foreach (var item in data.Item2)
                {
                    string distinct = new String(item.Distinct().ToArray());
                    if (distinct.Length == item.Length)
                    {
                        if (distinct.Length == 2)
                            ones++;
                        if (distinct.Length == 4)
                            fours++;
                        if (distinct.Length == 3)
                            sevens++;
                        if (distinct.Length == 7)
                            eights++;
                    }
                }
            }
            var result = ones + fours + sevens + eights;
            return new((ones+fours+sevens+eights).ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            throw new NotImplementedException();
        }
    }
}
