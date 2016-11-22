using System;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class Longsum : CompetitiveTask
    {
        private const string Training = @"Training_2/C_Longsum/";
        public override string InputFile { get; } = Training + @"longsum.in";
        public override string OutputFile { get; } = Training + @"longsum.out";

        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var m = reader.ReadLine();
            var n = reader.ReadLine();

            var max = Math.Max(n.Length, m.Length); 
            m = m.PadLeft(max, '0');
            n = n.PadLeft(max, '0');
            
            var digits = new int[max];

            var carry = 0;
            for (var i = max - 1; i >= 0; i--)
            {
                var sum = (int)char.GetNumericValue(n[i]) + (int)char.GetNumericValue(m[i]) + carry;
                digits[i] = sum % 10;
                carry = sum / 10;
            }

            if (carry > 0)
                writer.Write(carry);

            foreach (var digit in digits.SkipWhile(x => x == 0))
                writer.Write(digit);
                
        }
    }
}
