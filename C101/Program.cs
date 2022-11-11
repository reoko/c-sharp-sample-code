using System;
using System.Collections.Generic;

namespace Package1
{
    class C101
    {
        public static void Main(string[] args)
        {
            int intAction = 0;

            switch(intAction)
            {
                case 1:
                    angList();
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
    }
}