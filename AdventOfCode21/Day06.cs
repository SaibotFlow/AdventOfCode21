using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode21
{
    public class Day06 : BaseDay
    {
        private static int MaxAge = 8;

        //Fishes can have a 0-Day state. 8 days + 0 inclusive = 9
        private long[] InitialFishState = new long[MaxAge+1];

        public Day06()
        {
            //Parse all fishes and count them by their day-state
            File.ReadAllText(InputFilePath).Split(',').ToList().ForEach(item =>
            {
                InitialFishState[long.Parse(item)]++;
            });
           
        }

        public override ValueTask<string> Solve_1()
        {
            var currentCylce = InitialFishState;
            for (int i = 0; i < 80; i++)
            {
                currentCylce = Cycle(currentCylce);
            }
            return new(currentCylce.Sum().ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var currentCylce = InitialFishState;
            for (int i = 0; i < 256; i++)
            {
                currentCylce = Cycle(currentCylce);
            }
            return new(currentCylce.Sum().ToString());
        }


        public long[] Cycle(long[] fishState)
        {
            var shifted = new long[MaxAge+1];
            shifted[0] = fishState[1];
            shifted[1] = fishState[2];
            shifted[2] = fishState[3];
            shifted[3] = fishState[4];
            shifted[4] = fishState[5];
            shifted[5] = fishState[6];
            //Add 0-Fishes to the 6-day-state plus the fishes from the 7-day state
            shifted[6] = fishState[7] + fishState[0];
            shifted[7] = fishState[8];
            // Add new fish
            shifted[8] = fishState[0];
            return shifted;
        }
    }
}
