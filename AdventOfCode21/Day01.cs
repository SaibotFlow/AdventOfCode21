using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day01 : BaseDay
    {
        private readonly int[] _Input;

        public Day01()
        {
            _Input = File.ReadAllLines(InputFilePath).Select(Int32.Parse).ToArray();
        }
       


        public override ValueTask<string> Solve_1()
        {
            var count = 0;
            for (int i = 0; i < _Input.Length; i++)
            {
                if (i == 0)
                    continue;
                if (_Input[i] > _Input[i - 1])
                    count++;
            }
            return new (count.ToString());

        }

        public override ValueTask<string> Solve_2()
        {
            int count = 0;
            var windows = new List<int>();
            for (int i = 0; i < _Input.Length; i++)
            {
                if (i + 2 >= _Input.Length)
                    break;
                windows.Add(_Input[i] + _Input[i + 1] + _Input[i + 2]);
            }
            for (int i = 0; i < windows.Count; i++)
            {
                if (i == 0)
                    continue;
                if (windows[i] > windows[i - 1])
                    count++;
            }
            return new (count.ToString());
        }
    }
}
