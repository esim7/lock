using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            object syncObject = new object();
            
        BlockingCollection<Account> accounts = new BlockingCollection<Account>()
        {
            new Account
            {
                Name = "Пупкин А. В.",
                AccountNumber = "KZ74155898RB0000345",
                Cash = 10000
            },
            new Account
            {
                Name = "Сидоров О. С.",
                AccountNumber = "KZ71114528RB0000345",
                Cash = 10000
            },
            new Account
            {
                Name = "Федоров Ф. В.",
                AccountNumber = "KZ78876966RB0000345",
                Cash = 10000
            },
            new Account
            {
                Name = "Бугарин У. В.",
                AccountNumber = "KZ78985532RB0000345",
                Cash = 10000
            },
            new Account
            {
            Name = "Петров А. Л.",
            AccountNumber = "KZ77855654RB0000345",
            Cash = 10000
            },
        };
        for(int i = 0; i < 100; i++)
        {
            lock (accounts)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < accounts.Count; j++)
                    {
                        ThreadPool.QueueUserWorkItem(accounts.ElementAt(j).AddMoney, 100);
                    }
                }
                else
                {
                    for (int j = 0; j < accounts.Count; j++)
                    {
                        ThreadPool.QueueUserWorkItem(accounts.ElementAt(j).WithDrawMoney, 100);
                    }
                }
                Thread.Sleep(5);
            }
        }

        foreach(var account in accounts)
        {
             Console.WriteLine(account.Name + " - " + account.Cash);
        }
        Console.ReadLine();
        }
    }
}
