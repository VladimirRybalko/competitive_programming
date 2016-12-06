using System;
using System.IO;

namespace Tasks
{
    public class Route : CompetitiveTask
    {
        private const string Training = @"Training_2/C_Route/";
        public override string InputFile { get; } = Training + @"route.in";
        public override string OutputFile { get; } = Training + @"route.out";

        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var n = reader.ReadInt();
            var matrix = new int[n, n];

            // Input matrix
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = reader.ReadInt();

            // Navigation matrix (i,j) == 'u' if min route comes from up cell,
            //                   (i,j) == 'l' if route comes from left cell
            var navigation = new char[n, n];

            // Route matrix. (Minimum routes summary to each cell)
            // (i,j) - minimum summary to the road to thic cell
            var route = new int[n, n];


            // Result matrix. (i,j) == '#' if minimum route contains this cell
            // by default (i,j) == '-'
            var result = new char[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    result[i, j] = '-';
            
            // Resolving

            // border cases
            route[0, 0] = matrix[0, 0];
            for (var i = 1; i < n; i++)
            {
                route[0, i] = matrix[0, i] + route[0, i - 1];
                navigation[0, i] = 'l';

                route[i, 0] = matrix[i, 0] + route[i - 1, 0];
                navigation[i, 0] = 'u';
            }

            // comon case
            for (var i = 1; i < n; i++)
                for (var j = 1; j < n; j++)
                {
                    var fromUp = matrix[i, j] + route[i - 1, j];
                    var fromLeft = matrix[i, j] + route[i, j - 1];
                    
                    route[i, j] = Math.Min(fromUp, fromLeft);
                    navigation[i, j] = fromUp < fromLeft ? 'u' : 'l';
                }


            // perfom result
            result[0, 0] = '#';
            var row = n - 1;
            var column = n - 1;
            do
            {
                result[row, column] = '#';
                if (navigation[row, column] == 'u')
                    row--;
                else
                    column--;
            }
            while (row >= 0 && column >= 0);


            // write result
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                    writer.Write(result[i, j]);

                writer.WriteLine();
            }
        }
    }
}
