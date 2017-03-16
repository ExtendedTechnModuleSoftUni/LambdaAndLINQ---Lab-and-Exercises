namespace _03ME.LINQuistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LINQuistics
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var collectionsAndMethods = new Dictionary<string, HashSet<string>>();

            while (inputLine != "exit")
            {
                var tokens = inputLine.Split(new char[] { '.', '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var digit = 0;
                var isDigit = int.TryParse(tokens[0], out digit);

                if (tokens.Length > 1)
                {
                    FillCollectionsAndMethods(collectionsAndMethods, tokens);
                }
                else if (!isDigit)
                {
                    GetCollectionNameOnly(collectionsAndMethods, tokens);
                }
                else
                {
                    GetDigitInputOnly(collectionsAndMethods, digit);
                }

                inputLine = Console.ReadLine();
            }

            var lastInputLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var neededMethod = lastInputLine[0];
            var selection = lastInputLine[1];
            var collections = collectionsAndMethods.Where(v => v.Value.Contains(neededMethod)).ToDictionary(k => k.Key, v => v.Value);

            if (selection == "collection")
            {
                PrintCommandCollection(collections);
            }
            else
            {
                PrintCommandAll(collections);
            }
        }

        private static void PrintCommandAll(Dictionary<string, HashSet<string>> collections)
        {
            foreach (var collection in collections
                .OrderByDescending(v => v.Value.Count)
                .ThenByDescending(v => v.Value.Min(a => a.Length)))
            {
                Console.WriteLine(collection.Key);

                foreach (var methods in collection.Value.OrderByDescending(v => v.Length))
                {
                    Console.WriteLine($"* {methods}");
                }
            }
        }

        private static void PrintCommandCollection(Dictionary<string, HashSet<string>> collections)
        {
            foreach (var collection in collections
                .OrderByDescending(v => v.Value.Count)
                .ThenByDescending(v => v.Value.Min(a => a.Length)))
            {
                Console.WriteLine(collection.Key);
            }
        }

        private static void GetDigitInputOnly(Dictionary<string, HashSet<string>> collectionsAndMethods, int digit)
        {
            var mostMethods = collectionsAndMethods.OrderByDescending(x => x.Value.Count).Take(1).ToDictionary(p => p.Key, p => p.Value);

            foreach (var method in mostMethods)
            {
                foreach (var item in method.Value.OrderBy(x => x.Length).Take(digit))
                {
                    Console.WriteLine($"* {item}");
                }
            }
        }

        private static void GetCollectionNameOnly(Dictionary<string, HashSet<string>> collectionsAndMethods, string[] tokens)
        {
            var collectionName = tokens[0];

            if (collectionsAndMethods.ContainsKey(collectionName))
            {
                var sortedCollectionsAndMethods = collectionsAndMethods[collectionName];

                foreach (var method in sortedCollectionsAndMethods
                    .OrderByDescending(method => method.Length)
                    .ThenByDescending(method => method.Distinct().Count()))
                {
                    Console.WriteLine($"* {method}");
                }
            }
        }

        private static void FillCollectionsAndMethods(Dictionary<string, HashSet<string>> collectionsAndMethods, string[] tokens)
        {
            var currentCollection = tokens[0];

            if (!collectionsAndMethods.ContainsKey(currentCollection))
            {
                collectionsAndMethods.Add(currentCollection, new HashSet<string>());
            }

            for (int i = 1; i < tokens.Length; i++)
            {
                var currentMethod = tokens[i];
                collectionsAndMethods[currentCollection].Add(currentMethod);
            }
        }
    }
}
