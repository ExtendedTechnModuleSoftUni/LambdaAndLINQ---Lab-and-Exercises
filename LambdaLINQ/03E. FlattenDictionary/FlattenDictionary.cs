namespace _03E.FlattenDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FlattenDictionary
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split().ToArray();
            var mainDict = new Dictionary<string, Dictionary<string, string>>();
            var concatDict = new Dictionary<string, List<string>>();

            while (inputLine[0] != "end")
            {
                if (inputLine[0] != "flatten")
                {
                    var key = inputLine[0];
                    var innerKey = inputLine[1];
                    var innerValue = inputLine[2];

                    if (!mainDict.ContainsKey(key))
                    {
                        mainDict[key] = new Dictionary<string, string>();
                    }
                    if (!mainDict[key].ContainsKey(innerKey))
                    {
                        mainDict[key].Add(innerKey, innerValue);
                    }
                    else
                    {
                        mainDict[key][innerKey] = innerValue;
                    }
                }
                else
                {
                    var flattenKey = inputLine[1];

                    foreach (var innerKey in mainDict[flattenKey])
                    {
                        var innerValue = innerKey.Key + innerKey.Value;

                        if (!concatDict.ContainsKey(flattenKey))
                        {
                            concatDict[flattenKey] = new List<string>();
                        }

                        concatDict[flattenKey].Add(innerValue);
                    }

                    mainDict = mainDict.Where(x => x.Key != flattenKey).ToDictionary(p => p.Key, p => p.Value);
                    mainDict[flattenKey] = new Dictionary<string, string>();
                }

                inputLine = Console.ReadLine().Split().ToArray();
            }

            var lineCounter = 1;

            foreach (var outterKey in mainDict.OrderByDescending(x => x.Key.Length))
            {
                Console.WriteLine($"{outterKey.Key}");

                foreach (var innerKey in outterKey.Value.OrderBy(x => x.Key.Length))
                {
                    Console.WriteLine($"{lineCounter}. {innerKey.Key} - {innerKey.Value}");
                    lineCounter++;
                }
                if (concatDict.ContainsKey(outterKey.Key))
                {
                    foreach (var flattenKey in concatDict[outterKey.Key])
                    {
                        Console.WriteLine($"{lineCounter}. {flattenKey}");
                        lineCounter++;
                    }
                }

                lineCounter = 1;
            }
        }
    }
}