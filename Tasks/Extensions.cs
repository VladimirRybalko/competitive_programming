using System.IO;
using System.Linq;
using System.Text;

namespace Tasks
{
    public static class Extensions
    {
        /// <summary>
        /// Convert string value to the equivalient int representation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        /// <summary>
        /// Read int array from current file line
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static int[] ReadIntArray(this StreamReader reader)
        {
            return reader.ReadLine().Split(' ').Select(x => x.ToInt()).ToArray();
        }

        /// <summary>
        /// Read the next int value
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static int ReadInt(this StreamReader reader)
        {
            var sb = new StringBuilder();
            int c;
            do
            {
                c = reader.Read();
                sb.Append(c);
            } while (c != ' ');

            return sb.ToString().ToInt();
        }
    }
}
