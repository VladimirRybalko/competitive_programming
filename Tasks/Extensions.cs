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
    }
}
