using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode21
{
    public class Day03 : BaseDay
    {
        private readonly string[] _Input;

        public Day03()
        {
            _Input = File.ReadAllLines(InputFilePath).ToArray();

        }

        public override ValueTask<string> Solve_1()
        {
            string gamma = "";
            int len = _Input.FirstOrDefault().Length;

            for (int i = 0; i < len; i++)
            {
                int zeros = 0;
                int ones = 0;
                foreach (var entry in _Input)
                {
                    if (entry.ToCharArray()[i] == '1')
                        ones++;
                    else
                        zeros++;
                }
                gamma += zeros > ones ? "0" : "1";
            }
            var epsilon = "";
            foreach (char c in gamma)
            {
                epsilon += c == '1' ? '0' : '1';
            }
            var gammaAsInt = Convert.ToInt32(gamma, 2);
            var epsilonAsInt = Convert.ToInt32(epsilon, 2);
            return new((gammaAsInt * epsilonAsInt).ToString());
        }



        public override ValueTask<string> Solve_2()
        {
            var o2Inputs = new List<string>(this._Input);
            var co2Inputs = new List<string>(this._Input);
            int len = _Input.FirstOrDefault().Length;

            for (int i = 0; i < len; i++)
            {
                int zeros = 0;
                int ones = 0;
                foreach (var entry in o2Inputs)
                {
                    if (entry.ToCharArray()[i] == '1')
                        ones++;
                    else
                        zeros++;
                }
                if (ones >= zeros)
                    o2Inputs = o2Inputs.Where(e => e.ToCharArray()[i] == '1').ToList();
                else
                    o2Inputs = o2Inputs.Where(e => e.ToCharArray()[i] == '0').ToList();

                if (o2Inputs.Count == 1)
                    break;
            }
            var oxygen = Convert.ToInt32(o2Inputs.FirstOrDefault(), 2);

            for (int i = 0; i < len; i++)
            {
                int zeros = 0;
                int ones = 0;
                foreach (var entry in co2Inputs)
                {
                    if (entry.ToCharArray()[i] == '1')
                        ones++;
                    else
                        zeros++;
                }
                if (ones >= zeros)
                    co2Inputs = co2Inputs.Where(e => e.ToCharArray()[i] == '0').ToList();
                else
                    co2Inputs = co2Inputs.Where(e => e.ToCharArray()[i] == '1').ToList();

                if (co2Inputs.Count == 1)
                    break;

            }
            var co2 = Convert.ToInt32(co2Inputs.FirstOrDefault(), 2);
            return new((oxygen * co2).ToString());



        }

    }
}
