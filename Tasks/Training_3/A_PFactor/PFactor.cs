using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class PFactor : CompetitiveTask
    {
        private const string Training = @"Training_3/A_PFactor/";
        public override string InputFile { get; } = Training + @"pfactor.in";
        public override string OutputFile { get; } = Training + @"pfactor.out";

        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var n = reader.ReadLong();
            var multipliers = new List<long>();

            var i = 2L;
            while (i <= Math.Sqrt(n))
            {
                if (n % i != 0)
                    i++;
                else
                {
                    multipliers.Add(i);
                    n /= i;
                }
            }
            multipliers.Add(n);

            var result = string.Join("*", multipliers.Select(x => x));
            writer.Write(result);
        }
    }
}
