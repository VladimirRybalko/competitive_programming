using System;
using System.IO;

namespace Tasks
{
    public class Longprod : CompetitiveTask
    {
        private const string Training = @"Training_3/E_Longprod/";
        public override string InputFile { get; } = Training + @"longprod.in";
        public override string OutputFile { get; } = Training + @"longprod.out";

        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var n = reader.ReadLong();
            var m = reader.ReadLine();
            
            var x = new long[10];

            // fill in initial array (degree of n number (from 0 to 9))
            x[1] = n;
            for (var i = 2; i < 10; i++)
                x[i] += x[i - 1] + n;

            var result = 0m;
            for (var i = 0; i < m.Length; i++)
            {
                var numeric = (int)char.GetNumericValue(m[i]);
                result += (decimal)(x[numeric] * Math.Pow(10, m.Length - i - 1));
            }                

            writer.Write(result);                        
        }
    }
}
