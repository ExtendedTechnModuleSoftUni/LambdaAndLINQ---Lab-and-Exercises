namespace _04E.CottageScraper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CottageScraper
    {
        static void Main()
        {
            var inputLine = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var dict = new Dictionary<string, List<long>>();

            while (inputLine[0] != "chop" && inputLine[1] != "chop")
            {
                inputLine = FillEntriesInDict(inputLine, dict);
            }

            List<long> allTreesHeights, neededTreeType, unNeededTreeTypes;
            ManageTreeHeights(dict, out allTreesHeights, out neededTreeType, out unNeededTreeTypes);

            MakeCalculations(allTreesHeights, neededTreeType, unNeededTreeTypes);
        }

        private static void MakeCalculations(List<long> allTreesHeights, List<long> neededTreeType, List<long> unNeededTreeTypes)
        {
            var allTreeSum = allTreesHeights.Sum();
            double pricePerMetter = Math.Round(allTreeSum / (double)allTreesHeights.Count, 2);
            var usedLogsSum = neededTreeType.Sum();
            double usedLogsPrice = Math.Round(usedLogsSum * pricePerMetter, 2);
            var unUsedTreesSum = unNeededTreeTypes.Sum();
            double unUsedLogsPrice = Math.Round((unUsedTreesSum * pricePerMetter) * 0.25, 2);
            double subTotal = Math.Round((usedLogsPrice + unUsedLogsPrice), 2);

            Console.WriteLine("Price per meter: ${0:f2}", pricePerMetter);
            Console.WriteLine("Used logs price: ${0:f2}", usedLogsPrice);
            Console.WriteLine("Unused logs price: ${0:f2}", unUsedLogsPrice);
            Console.WriteLine("CottageScraper subtotal: ${0:f2}", subTotal);
        }

        private static void ManageTreeHeights(Dictionary<string, List<long>> dict, out List<long> allTreesHeights, out List<long> neededTreeType, out List<long> unNeededTreeTypes)
        {
            var treeType = Console.ReadLine();
            var height = int.Parse(Console.ReadLine());

            allTreesHeights = new List<long>();
            foreach (var key in dict)
            {
                allTreesHeights.AddRange(key.Value);
            }

            neededTreeType = new List<long>();
            unNeededTreeTypes = new List<long>();
            foreach (var item in dict)
            {
                if (item.Key == treeType)
                {
                    foreach (var treeHeight in item.Value)
                    {
                        if (treeHeight >= height)
                        {
                            neededTreeType.Add(treeHeight);
                        }
                        else
                        {
                            unNeededTreeTypes.Add(treeHeight);
                        }
                    }
                }
                else
                {
                    foreach (var treeHeight in item.Value)
                    {
                        unNeededTreeTypes.Add(treeHeight);
                    }
                }
            }
        }

        private static string[] FillEntriesInDict(string[] inputLine, Dictionary<string, List<long>> dict)
        {
            var material = inputLine[0];
            var quantity = long.Parse(inputLine[1]);

            if (!dict.ContainsKey(material))
            {
                dict[material] = new List<long>();
            }

            dict[material].Add(quantity);

            inputLine = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            return inputLine;
        }
    }
}
