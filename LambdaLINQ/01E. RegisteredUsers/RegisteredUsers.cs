namespace _01E.RegisteredUsers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class RegisteredUsers
    {
        static void Main()
        {
            var inputLine = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var firstDict = new Dictionary<string, DateTime>();

            while (inputLine[0] != "end")
            {
                var user = inputLine[0];
                var dateOfReg = inputLine[1];

                if (!firstDict.ContainsKey(user))
                {
                    firstDict[user] = new DateTime();
                }

                firstDict[user] = DateTime.ParseExact(dateOfReg, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                inputLine = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            var resultDict = firstDict
                .Reverse()
                .OrderBy(v => v.Value)
                .Take(5)
                .OrderByDescending(v => v.Value)
                .ToDictionary(p => p.Key, p => p.Value);

            foreach (var user in resultDict)
            {
                Console.WriteLine($"{user.Key}");
            }
        }
    }
}
