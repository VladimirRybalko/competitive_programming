using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class Piggy : CompetitiveTask
    {
        private const string Training = @"Training_3/C_Piggy/";
        public override string InputFile { get; } = Training + @"piggy.in";
        public override string OutputFile { get; } = Training + @"piggy.out";

        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var ef = reader.ReadIntArray();
            var e = ef[0];
            var f = ef[1];

            var n = reader.ReadInt();
            var p = new int[n]; // prices
            var w = new int[n]; // weigths
            for (int i = 0; i < n; i++)
            {
                var pw = reader.ReadIntArray();
                p[i] = pw[0];
                w[i] = pw[1];
            }

            var r = f - e;
            var m = new int[r + 1];
            var m1 = new int[r + 1];

            // search prices and weights
            for (var i = 0; i < n; i++)
            {
                var j = w[i];
                var amount = 1;
                while (j <= r)
                {
                    m[j] = Math.Max(m[j], p[i] * amount);
                    amount++;
                    j += w[i];
                }
            }

            // search summands for weights
            var indexes = new List<int>();
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] != 0)
                    indexes.Add(i);
            }            
            var summands = FindSummands(indexes, r);
                        
            // find min and max price
            var max = int.MinValue;
            var min = int.MaxValue;
            for (int i = 0; i < summands.Count; i++)
            {
                var sum = 0;
                foreach (var index in summands[i])
                    sum += m[index];
                               
                if (min > sum)
                    min = sum;
                if (max < sum)
                    max = sum;
            }
            
            if (max == int.MinValue && min == int.MaxValue)
                writer.Write("This is impossible.");
            else
                writer.Write($"{min} {max}");
        }

        private List<List<int>> FindSummands(List<int> indexes, int limit)
        {
            var result = new List<List<int>>();

            for (int i = 0; i < indexes.Count; i++)
            {
                var sub = indexes.ToList();
                sub.RemoveAt(i);
                var set = FindSummands(new List<int> { indexes[i] }, sub, limit);
                if (set.Any())
                    result.Add(set);
            }

            return result;
        }


        private List<int> FindSummands(List<int> values, List<int> tail, int limit)
        {
            if (values.Sum() == limit)
                return values;
               
            for (int i = 0; i < tail.Count; i++)
            {
                var sub = tail.ToList();
                sub.RemoveAt(i);
                var v = values.ToList();
                v.Add(tail[i]);
                var result = FindSummands(v, sub, limit);
                if (result.Any())
                    return result;            
            }

            return new List<int>();
        }
    }
}
