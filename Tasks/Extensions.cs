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
            return reader.ReadNumericString().ToInt();
        }

        public static long ReadLong(this StreamReader reader)
        {
            return reader.ReadNumericString().ToLong();
        }

        private static string ReadNumericString(this StreamReader reader)
        {
            var sb = new StringBuilder();
            char c;
            do
            {
                c = (char)reader.Read();
                sb.Append(c);
            } while (c != ' ' && c != '\r' && c != '\n' && c != '\uffff');

            if (c == '\r') // read \n symbol
                reader.Read();

            return sb.ToString().TrimEnd('\uffff');
        }

        /// <summary>
        /// Convert string value to the equivalient long representation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToLong(this string value)
        {
            return long.Parse(value);
        }

        /// <summary>
        /// Read long array from current file line
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static long[] ReadLongArray(this StreamReader reader)
        {
            return reader.ReadLine().Split(' ').Select(x => x.ToLong()).ToArray();
        }
    }
}
