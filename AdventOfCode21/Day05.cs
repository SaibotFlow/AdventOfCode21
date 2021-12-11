using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode21
{
    public class Day05 : BaseDay
    {
        public List<KeyValuePair<int, int>> _StartPoints = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> _EndPoints = new List<KeyValuePair<int, int>>();


        public Day05()
        {
            File.ReadAllLines(InputFilePath).ToList().ForEach(line =>
            {
                var splitted = line.Split("->");
                var start = splitted[0].Trim().Split(",");
                var end = splitted[1].Trim().Split(",");
                _StartPoints.Add(new KeyValuePair<int,int>(Convert.ToInt32(start[0]),Convert.ToInt32(start[1])));
                _EndPoints.Add(new KeyValuePair<int, int>(Convert.ToInt32(end[0]), Convert.ToInt32(end[1])));

            });
        }
        public override ValueTask<string> Solve_1()
        {
            var filteredStarts = _StartPoints.Where((item, index) => item.Key == _EndPoints[index].Key || item.Value == _EndPoints[index].Value).ToList();
            var filteredEnds = _EndPoints.Where((item, index) => item.Key == _StartPoints[index].Key || item.Value == _StartPoints[index].Value).ToList();
            int maxStarts = filteredStarts.Max(s => s.Key > s.Value ? s.Key : s.Value);
            int maxEnds = filteredEnds.Max(s => s.Key > s.Value ? s.Key : s.Value);
            int bound = maxStarts > maxEnds ? maxStarts : maxEnds;
            int[,] table = new int[bound+1, bound+1];
            for (int i = 0; i < filteredStarts.Count; i++)
            {
                var start = filteredStarts[i];
                var end = filteredEnds[i];
                bool isKeyEquals = start.Key == end.Key ? true: false;
                var loopStart =0;
                var loopEnd = 0;
                if (!isKeyEquals)
                {
                    loopStart = start.Key < end.Key ? start.Key : end.Key;
                    loopEnd = start.Key < end.Key ? end.Key : start.Key;
                }
                else
                {
                    loopStart = start.Value < end.Value ? start.Value : end.Value;
                    loopEnd = start.Value < end.Value ? end.Value : start.Value;
                }
                string blub = "";
                for (int j = loopStart; j <= loopEnd; j++)
                {
                    _= isKeyEquals ? table[start.Key,j]++ : table[j, start.Value]++;
                    _ = isKeyEquals ? blub += start.Key + "," + j + Environment.NewLine : blub += j + "," + start.Value + Environment.NewLine;
                }
            }
            var count = 0;
            foreach (var marker in table)
            {
                if (marker > 1)
                    count++;
            }
            return new(count.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            return new("");
        }
    }
}
