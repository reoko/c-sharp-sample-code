using System;
using System.Collections.Generic;

namespace C101
{
    class MainC101
    {
        public static void Main(string[] args)
        {
            int intAction = 2;

            switch(intAction)
            {
                case 1:
                    angList();
                    break;
                case 2:
                    angOOP();
                    break;
                default:
                    angWelcome();
                    break;
            }
        }

        public static void angWelcome()
        {
            Console.WriteLine("Welcome to C# 101!");
        }

        public static void angList()
        {
            var names = new List<string> { "name3", "name2", "name1" };

            names.Add("name4");
            names.Add("name5");

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static void angOOP()
        {
            var account = new BankAccount("Kendra", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");

            account.MakeWithdrawal(120, DateTime.Now, "Hammock");

            account.MakeWithdrawal(80, DateTime.Now, "Xbox");

            //Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}