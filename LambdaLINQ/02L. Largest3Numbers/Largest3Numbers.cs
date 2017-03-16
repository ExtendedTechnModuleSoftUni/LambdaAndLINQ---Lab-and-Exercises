namespace _02L.Largest3Numbers
{
    using System;
    using System.Linq;

    public class Largest3Numbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).Take(3).ToArray();
            
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
