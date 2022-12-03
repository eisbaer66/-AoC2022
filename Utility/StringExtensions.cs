namespace Utility
{
    public static class StringExtensions
    {
        public static IEnumerable<string> ToLines(this string input, bool removeEmpty = false)
        {
            var options = removeEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
            return input.Split(new[] { "\r\n", "\r", "\n" }, options);
        }
    }
}