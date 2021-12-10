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
        private  int _Days = 0;
        private Dictionary<long, long> _Data;

        public Day06()
        {
            _Data = new Dictionary<long, long>();
            var reproduceDays = File.ReadAllText(InputFilePath).Split(',').ToArray();
            for (int i = 0; i < reproduceDays.Length; i++) _Data.Add((long)i, Convert.ToInt64(reproduceDays[i]));
        }

        // Slow as hell. #codingshit
        /*
        public override ValueTask<string> Solve_1()
        {
            _Days = 80;
            for (int i = 0; i < _Days; i++)
            {
                bool addFish = false;
                long amountOfFishes = 0;
                foreach (var fish in _Data)
                {
                    if (_Data[fish.Key] < 0)
                        _Data[fish.Key] = 0;

                    if (_Data[fish.Key] == 0)
                    {
                        _Data[fish.Key] = 6;
                        addFish = true;
                        amountOfFishes++;
                    }
                    else
                        _Data[fish.Key]--;
                }

                if (addFish)
                {
                    for (long k = 0; k < amountOfFishes; k++)
                    {
                        _Data.Add(_Data.Keys.Last() + 1, 8);
                    }
                }
            }
            return new(_Data.Keys.Count.ToString());
        }
        */
        HashSet<KeyValuePair<long, long>> data = new HashSet<KeyValuePair<long, long>>();
        public override ValueTask<string> Solve_1()
        {
            _Days = 80;
            foreach (var item in _Data)
            {
                data.Add(item);
            }
            for (int i = 0; i < _Days; i++)
            {

                if (data.Any(i => i.Value == 0))
                {
                    var x = data.Where(s => s.Value == 0).ToArray();
                    for (int j = 0; j < x.Length; j++)
                    {
                        x[j] = new KeyValuePair<long, long>(x[j].Key, 6);
                        data.Select(s => new KeyValuePair<long, long>(s.Key, s.Value - 1));
                        data.Add(new KeyValuePair<long, long>(data.Last().Key, 8));
                    }
                }
                else
                {
                    data.Select(s => new KeyValuePair<long, long>(s.Key, s.Value - 1));
                }
                

            }
            return new();
        }

        public override ValueTask<string> Solve_2()
        {
            _Days = 256;
            return new();
        }
    }
}
