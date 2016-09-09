using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Expression : ITask
    {
        private const string Training = @"Training_1/B_Expression/";

        int[] x;
        char[] signs;
        int n;
        long S;


        public void Resolve()
        {
            x = new[] { 2, 3, 5, 6 };
            n = 4;
            signs = new char[n];
            S = 6;

            var result = Foo(0, x[0], '+');

            Console.WriteLine(result);
            Console.Write(x[0]);
            for (int i = 1; i < n; i++)
            {
                Console.Write(signs[i]);
                Console.Write(x[i]);
            }

            Console.Write("=" + S);
            Console.ReadLine();
        }

        private bool Foo(int i, long sum, char sign)
        {
            signs[i] = sign;

            if (i == n - 1)
                return S == sum;

            i++;
            return Foo(i, sum + x[i], '+') || Foo(i, sum - x[i], '-');
        }

        public string InputFile
        {
            get { throw new NotImplementedException(); }
        }

        public string OutputFile
        {
            get { throw new NotImplementedException(); }
        }
    }
}
