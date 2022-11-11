using System;
using System.Collections.Generic;
using System.IO;
//using System.Diagnostics;

namespace C101
{
    class MainC101
    {
        public static void Main(string[] args)
        {
            int intAction = 4;

            switch(intAction)
            {
                case 1:
                    angList();
                    break;
                case 2:
                    angOOP();
                    break;
                case 3:
                    angLoggingAndTracing();
                    break;
                case 4:
                    angListAllDirectories();
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

        public static void angLoggingAndTracing()
        {
            int result = Fibonacci(5);
            Console.WriteLine(result);
        }

        static int Fibonacci(int n)
        {
            //Debug.WriteLine($"Entering {nameof(Fibonacci)} method");
            //Debug.WriteLine($"We are looking for the {n}th number");

            int n1 = 0;
            int n2 = 1;
            int sum;
            for (int i = 2; i < n; i++)
            {
                sum = n1 + n2;
                n1 = n2;
                n2 = sum;
                //Debug.WriteLineIf(sum == 1, $"sum is 1, n1 is {n1}, n2 is {n2}");
            }

            return n == 0 ? n1 : n2;
        }

        public static void angListAllDirectories()
        {
            
            IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("stores");

            foreach(var dir in listOfDirectories)
            {
                Console.WriteLine(dir);
            }
        }
    }
}