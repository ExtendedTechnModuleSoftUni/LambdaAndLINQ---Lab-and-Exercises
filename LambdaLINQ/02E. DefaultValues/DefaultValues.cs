namespace _02E.DefaultValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DefaultValues
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var keyValueDict = new Dictionary<string, string>();

            while (inputLine[0] != "end")
            {
                var currentKey = inputLine[0];
                var currentValue = inputLine[1];

                if (!keyValueDict.ContainsKey(currentKey))
                {
                    keyValueDict.Add(currentKey, currentValue);
                }
                else
                {
                    keyValueDict[currentKey] = currentValue;
                }

                inputLine = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            var defaultValue = Console.ReadLine();

            var keyNullValueDict = new Dictionary<string, string>();
            foreach (var user in keyValueDict)
            {
                if (user.Value == "null")
                {
                    keyNullValueDict[user.Key] = defaultValue;
                }
            }

            keyValueDict = keyValueDict
                .Where(v => v.Value != "null")
                .OrderByDescending(x => x.Value.Length)
                .ToDictionary(p => p.Key, p => p.Value);

            PrintResult(keyValueDict, keyNullValueDict);
        }

        private static void PrintResult(Dictionary<string, string> keyValueDict, Dictionary<string, string> keyNullValueDict)
        {
            foreach (var kvp in keyValueDict)
            {
                Console.WriteLine($"{kvp.Key} <-> {kvp.Value}");
            }
            foreach (var kvp in keyNullValueDict)
            {
                Console.WriteLine($"{kvp.Key} <-> {kvp.Value}");
            }
        }
    }
}
