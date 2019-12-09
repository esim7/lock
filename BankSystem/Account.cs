using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Account
    {
        public delegate void MyAccount(string message);
        public event MyAccount Notification;

        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public int Cash { get; set; }

        public Account()
        {
            Notification += ShowMessage;
        }
        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void AddMoney(object money)
        {
            Cash += (int)money;
            Notification?.Invoke($"На счет {this.Name} номер счета {this.AccountNumber} поступило {(int)money}");
        }
        public void WithDrawMoney(object money)
        {
            Cash -= (int)money;
            Notification?.Invoke($"Со счета {this.Name} номер счета {this.AccountNumber} списано {(int)money}");
        }
    }
}
