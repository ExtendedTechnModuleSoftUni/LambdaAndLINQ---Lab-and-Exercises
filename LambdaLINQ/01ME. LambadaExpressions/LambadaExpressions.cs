namespace _01ME.LambadaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LambadaExpressions
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine()
                .Split(new char[] { '=', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var dict = new Dictionary<string, string>();

            while (inputLine[0] != "lambada")
            {
                if (inputLine[0] != "dance")
                {
                    AddingItemsInDict(inputLine, dict);
                }
                else
                {
                    GetDanceCommand(dict);
                }

                inputLine = Console.ReadLine()
                .Split(new char[] { '=', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            PrintResult(dict);
        }

        private static void PrintResult(Dictionary<string, string> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }

        private static void AddingItemsInDict(string[] inputLine, Dictionary<string, string> dict)
        {
            var key = inputLine[0];
            var value = inputLine[1];

            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
            else
            {
                dict[key] = value;
            }
        }

        private static void GetDanceCommand(Dictionary<string, string> dict)
        {
            for (int i = 0; i < dict.Count; i++)
            {
                var key = dict.Keys.Skip(i).Take(1).ToList();
                var value = dict.Values.Skip(i).Take(1).ToList();
                dict[key[0]] = key[0] + "." + value[0];

                key.Clear();
                value.Clear();
            }
        }
    }
}
