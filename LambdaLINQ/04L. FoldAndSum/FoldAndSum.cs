namespace _04L.FoldAndSum
{
    using System;
    using System.Linq;

    class FoldAndSum
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var k = numbers.Length / 4;

            var leftPartNumbers = numbers.Take(k).Reverse().ToArray();
            var rightPartNumbers = numbers.Reverse().Take(k).ToArray();

            var upperRowNumbers = leftPartNumbers.Concat(rightPartNumbers).ToArray();
            var downPartNUmbers = numbers.Skip(k).Take(2 * k).ToArray();

            var result = new int[2 * k];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = upperRowNumbers[i] + downPartNUmbers[i];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
