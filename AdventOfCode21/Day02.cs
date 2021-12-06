using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day02 : BaseDay
    {
        private readonly KeyValuePair<string,int>[] _Input;

        public Day02()
        {
            _Input = File.ReadAllLines(InputFilePath)
                .Select(line => 
                new KeyValuePair<string, int>(
                line.Split(" ")[0].ToString(),
                Convert.ToInt32(line.Split(" ")[1])))
                .ToArray();
        }

        public override ValueTask<string> Solve_1()
        {
            long horizontal = 0;
            long depth = 0;
            foreach (var entry in _Input)
            {
                if (entry.Key.StartsWith("f"))
                { 
                    horizontal += entry.Value;
                    continue;
                }
                if (entry.Key.StartsWith("d"))
                {
                    depth += entry.Value; 
                    continue;
                }
                if (entry.Key.StartsWith("u"))
                {
                    depth -= entry.Value; 
                    continue;
                }
            }
            return new((horizontal * depth).ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            long aim = 0;
            long horizontal = 0;
            long depth = 0;
            foreach (var entry in _Input)
            {
                if (entry.Key.StartsWith("f"))
                {
                    horizontal += entry.Value;
                    depth += aim * entry.Value;
                    continue;
                }
                if (entry.Key.StartsWith("d"))
                {
                    aim += entry.Value;
                    continue;
                }
                if (entry.Key.StartsWith("u"))
                {
                    aim -= entry.Value;
                    continue;
                }
            }
            return new((horizontal * depth).ToString());
        }
    }
}
