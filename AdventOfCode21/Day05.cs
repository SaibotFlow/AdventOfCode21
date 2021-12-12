using AoCHelper;
using System;
using System.Collections;
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

        public Line[] Lines;

        public class Line
        {
            public int X1;
            public int X2;
            public int Y1;
            public int Y2;

            public bool Check(bool withDiagonales = false)
            {
                if (!withDiagonales)
                    return X1 == X2 || Y1 == Y2;
                else
                    return true;
            }

            public int Max()
            {
                return new[] { X1, X2, Y1, Y2 }.Max();
            }

            public int[,] Mark(int[,] map)
            {

                var points = new List<KeyValuePair<int, int>>();
                /*
                 * MathSign e.g X1,X2
                 * if result > 0 it returns 1  --> X2 is bigger and X1 so increase X1 by 1
                 * if result < 0 it returns -1 --> X2 is lower than X1 so descrease X1 by 1
                 * if result = 0 it returns 0 --> X2 = X1 do nothing
                 */
                var xInkcrement = Math.Sign(X2 - X1);
                var yIncrement = Math.Sign(Y2 - Y1);
                // Dont forget to include the border points. Use the increment.
                for (int x = X1, y = Y1; x != X2+xInkcrement || y !=Y2+yIncrement; x+=xInkcrement, y+=yIncrement)
                {
                    points.Add(new KeyValuePair<int, int>(x, y));
                }
                foreach (var point in points) map[point.Key, point.Value]++;
                return map;
            }

            public override string ToString()
            {
                return "(" + X1 + "," + Y1 + ")(" + X2 + "," + Y2 + ")";
            }

        }

        public Day05()
        {
            Lines = File.ReadAllLines(InputFilePath).Select(item =>
            {
                var splitted = item.Split("->");
                var start = splitted[0].Trim().Split(",");
                var end = splitted[1].Trim().Split(",");
                return new Line()
                {
                    X1 = int.Parse(start[0]),
                    Y1 = int.Parse(start[1]),
                    X2 = int.Parse(end[0]),
                    Y2 = int.Parse(end[1])
                };
            }).ToArray();
        }
        public override ValueTask<string> Solve_1()
        {
            var filteredLines = Lines.Where(l => l.Check(false)).ToArray();
            var bound = filteredLines.Max(l => l.Max());
            int[,] map = new int[bound + 1, bound + 1];
            foreach (var line in filteredLines) line.Mark(map);
            var count = 0;
            foreach (var marker in map)
            {
                if (marker >= 2)
                    count++;
            }
            return new(count.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var filteredLines = Lines.Where(l => l.Check(true)).ToArray();
            var bound = filteredLines.Max(l => l.Max());
            int[,] map = new int[bound + 1, bound + 1];
            foreach (var line in filteredLines) line.Mark(map);
            var count = 0;
            foreach (var marker in map)
            {
                if (marker >= 2)
                    count++;
            }
            return new(count.ToString());
        }
    }
}
