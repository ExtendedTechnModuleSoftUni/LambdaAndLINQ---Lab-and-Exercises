namespace _03L.ShortWordsSorted
{
    using System;
    using System.Linq;

    public class ShortWordsSorted
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .ToLower()
                .Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            var result = words.Where(w => w.Length < 5).OrderBy(w => w).Distinct().ToArray();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
