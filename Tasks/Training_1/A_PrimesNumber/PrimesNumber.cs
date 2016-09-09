using System;
using System.IO;

namespace Tasks
{
    public class PrimesNumber : ITask
    {
        private const string Training = @"Training_1/A_PrimesNumber/";
        public string InputFile { get; } = Training + @"primes.in";
        public string OutputFile { get; } = Training + @"primes.out";

        public void Resolve()
        {
            var input = File.ReadAllLines(InputFile);
            var spliting = input[0].Split(' ');
            var m = int.Parse(spliting[0]);
            var n = int.Parse(spliting[1]);

            using (var writer = new StreamWriter(OutputFile))
            {
                var existPrimes = false;
                for (var i = m; i <= n; i++)
                {
                    if (IsPrime(i))
                    {
                        existPrimes = true;
                        writer.Write(i + " ");                   
                    }                       
                }

                if (!existPrimes)
                    writer.Write("Absent");                
            }
        }

        private static bool IsPrime(int number)
        {
            var i = 2;
            while(i <= Math.Sqrt(number))
            {
                if (number % i == 0)
                    return false;
                i++;
            }

            return true;
        }
    }
}
