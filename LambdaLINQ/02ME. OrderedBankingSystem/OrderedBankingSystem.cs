namespace _02ME.OrderedBankingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderedBankingSystem
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var banksAndAccounts = new Dictionary<string, Dictionary<string, decimal>>();

            while (inputLine != "end")
            {
                string[] tookens = inputLine.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                GetBanksAndAccountsDetails(banksAndAccounts, tookens);

                inputLine = Console.ReadLine();
            }

            PrintResult(banksAndAccounts);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, decimal>> banksAndAccounts)
        {
            foreach (var bank in banksAndAccounts
                .OrderByDescending(b => b.Value.Sum(a => a.Value))
                .ThenByDescending(b => b.Value.Max(a => a.Value)))
            {
                foreach (var account in bank.Value.OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"{account.Key} -> {account.Value} ({bank.Key})");
                }
            }
        }

        private static void GetBanksAndAccountsDetails(Dictionary<string, Dictionary<string, decimal>> banksAndAccounts, string[] tookens)
        {
            var currentBank = tookens[0];
            var currentAccount = tookens[1];
            var currentBalance = decimal.Parse(tookens[2]);

            if (!banksAndAccounts.ContainsKey(currentBank))
            {
                banksAndAccounts.Add(currentBank, new Dictionary<string, decimal>());
            }
            if (!banksAndAccounts[currentBank].ContainsKey(currentAccount))
            {
                banksAndAccounts[currentBank].Add(currentAccount, 0);
            }

            banksAndAccounts[currentBank][currentAccount] += currentBalance;
        }
    }
}
