using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode21
{
    public class Day07 : BaseDay
    {
        int[] Crabs;
        public Day07()
        {
            Crabs = File.ReadAllText(InputFilePath).Split(",").Select(x=>int.Parse(x)).ToArray();
        }
        public override ValueTask<string> Solve_1()
        {
            var min = Crabs.Min();
            var max = Crabs.Max();
            var costPerPosition = new Dictionary<int, int>();
            for (int i = min; i < max; i++)
            {
                int fuel = 0;
                foreach (int crab in Crabs)
                {
                    fuel += Math.Abs(crab - i);
                }
                costPerPosition.Add(i, fuel);
            }
            var ordered = costPerPosition.OrderBy(p => p.Value).ToDictionary(x => x.Key, x => x.Value);
            return new (ordered.FirstOrDefault().Value.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var min = Crabs.Min();
            var max = Crabs.Max();
            var costPerPosition = new Dictionary<int, int>();
            for (int i = min; i < max; i++)
            {
                int fuel = 0;
                foreach (int crab in Crabs)
                {
                    var range = Math.Abs(crab - i);
                    //Gauß Sum = n(n+1)/2;
                    fuel += (range * (range + 1)) / 2;

                }
                costPerPosition.Add(i, fuel);
            }
            var ordered = costPerPosition.OrderBy(p => p.Value).ToDictionary(x => x.Key, x => x.Value);
            return new(ordered.FirstOrDefault().Value.ToString());
        }


    }
}
