using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class Power : CompetitiveTask
    {
        private const string Training = @"Training_1/E_Power/";

        public override string InputFile { get; } = Training + @"power.in";
        public override string OutputFile { get; } = Training + @"power.out";
                                
        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var a = reader.ReadInt();
            var n = reader.ReadInt();
            var digits = new List<int>();
            digits.Add(a);
                        
            for (var i = 1; i < n; i++)
            {
                var carry = 0;
                for (int j = 0; j < digits.Count; j++)
                {
                    carry += digits[j] * a;
                    digits[j] = carry % 10;
                    carry /= 10;
                }

                if (carry > 0)
                    digits.Add(carry);               
            }


            for (var i = digits.Count - 1; i >= 0; i--)
                writer.Write(digits[i]);                       
        }    
    }
}
