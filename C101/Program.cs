using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
//using System.Diagnostics;

namespace C101
{
    class MainC101
    {
        public static void Main(string[] args)
        {
            int intAction = 22;

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
                case 5:
                    angListOfFilesInDir();
                    break;
                case 6:
                    angListOfAllFilesInDirAndSubDir();
                    break;
                case 7:
                    angGetCurrentDir();
                    break;
                case 8:
                    angGetUserHomeDirectory();
                    break;
                case 9:
                    angJoinPath();
                    break;
                case 10:
                    angFileExtensions();
                    break;
                case 11:
                    angPathDirectoryInfoFileInfo();
                    break;
                case 12:
                    angWorkPathDirectoryGetCurrentDirectory();
                    break;
                case 13:
                    angFindAllFileWithExtension();
                    break;
                case 14:
                    angCreateDirectory();
                    break;
                case 15:
                    angCheckIfDirectoryExist();
                    break;
                case 16:
                    angCreateFiles();
                    break;
                case 17:
                    angCreateFilesDirectory();
                    break;
                case 18:
                    angReadFiles();
                    break;
                case 19:
                    angParseDataInJsonFile();
                    break;
                case 20:
                    angWriteDataToTxtFile();
                    break;
                case 21:
                    angAppendDataToTxtFiles();
                    break;
                case 22:
                    angReadAndWriteFile();
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

        public static void angListOfFilesInDir()
        {
            IEnumerable<string> files = Directory.EnumerateFiles("stores");

            foreach(var file in files)
            {
                Console.WriteLine(file);
            }
        }

        public static void angListOfAllFilesInDirAndSubDir()
        {
            IEnumerable<string> allFilesInAllFolders = Directory.EnumerateFiles("stores", "*.*", SearchOption.AllDirectories);

            foreach(var file in allFilesInAllFolders)
            {
                Console.WriteLine(file);
            }
        }

        public static void angGetCurrentDir()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        public static void angGetUserHomeDirectory()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Console.WriteLine(docPath);
        }

        public static void angDirectorySeparatorChar()
        {
            Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");

            // returns:
            // stores\201 on Windows
            //
            // stores/201 on macOS
        }

        public static void angJoinPath()
        {
            Console.WriteLine(Path.Combine("stores","201")); // outputs: stores/201
        }

        public static void angFileExtensions()
        {
            Console.WriteLine(Path.GetExtension("sales.json")); // outputs: .json
        }

        public static void angPathDirectoryInfoFileInfo()
        {
            string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

            FileInfo info = new FileInfo(fileName);

            Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more
        }

        public static IEnumerable<string> FindFiles(string folderName)
        {
            List<string> salesFiles = new List<string>();

            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

            foreach (var file in foundFiles)
            {
                // The file name will contain the full path, so only check the end of it
                if (file.EndsWith("sales.json"))
                {
                    salesFiles.Add(file);
                }
            }

            return salesFiles;
        }

        public static void angWorkPathDirectoryGetCurrentDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var storesDirectory = Path.Combine(currentDirectory, "stores");

            var salesFiles = FindFiles(storesDirectory);

            foreach (var file in salesFiles)
            {
                Console.WriteLine(file);
            }
        }

        public static IEnumerable<string> FindFiles2(string folderName)
        {
            List<string> salesFiles = new List<string>();

            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

            foreach (var file in foundFiles)
            {
                var extension = Path.GetExtension(file);
                if (extension == ".json")
                {
                    salesFiles.Add(file);
                }
            }

            return salesFiles;
        }

        public static void angFindAllFileWithExtension()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var storesDirectory = Path.Combine(currentDirectory, "stores");

            var salesFiles = FindFiles2(storesDirectory);
                
            foreach (var file in salesFiles)
            {
                Console.WriteLine(file);
            }
        }

        public static void angCreateDirectory()
        {
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));

            Console.WriteLine("Create New Folder: " + Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));
        }

        public static void angCheckIfDirectoryExist()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir");

            bool doesDirectoryExist = Directory.Exists(filePath);

            if (doesDirectoryExist)
                Console.WriteLine("TRUE");
            else
                Console.WriteLine("FALSE");
        }
    
        public static void angCreateFiles()
        {
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir","greeting.txt"), "Hello World!");
        }

        public static void angCreateFilesDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirectory);

            var storesDirectory = Path.Combine(currentDirectory, "stores");
            Console.WriteLine(storesDirectory);

            var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
            Console.WriteLine(salesTotalDir);

            Directory.CreateDirectory(salesTotalDir);

            var salesFiles = FindFiles(storesDirectory);

            File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);
        }
    
        public static void angReadFiles()
        {
            var readDataFromFile = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");

            Console.WriteLine(readDataFromFile);
        }

        public static void angParseDataInJsonFile()
        {
            var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
            var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

            Console.WriteLine(salesData.Total);
        }

        public static void angWriteDataToTxtFile()
        {
            var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
            var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

            //Console.WriteLine(salesData.Total);

            var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

            File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", data.Total.ToString());

            // totals.txt
            // 22385.32
        }

        public static void angAppendDataToTxtFiles()
        {
            var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
            var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

            //Console.WriteLine(salesData.Total);

            //var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

            //File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", data.Total.ToString());

            var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

            File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data.Total}{Environment.NewLine}");
        }

        record SalesData (double Total);

        static double CalculateSalesTotal(IEnumerable<string> salesFiles)
        {
            double salesTotal = 0;

            // Loop over each file path in salesFiles
            foreach (var file in salesFiles)
            {
                // Read the contents of the file
                string salesJson = File.ReadAllText(file);

                // Parse the contents as JSON
                SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
                
                // Add the amount found in the Total field to the salesTotal variable

                salesTotal += data?.Total ?? 0;
            }

            return salesTotal;
        }

        public static void angReadAndWriteFile()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var storesDir = Path.Combine(currentDirectory, "stores");

            var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
            Directory.CreateDirectory(salesTotalDir);

            var salesFiles = FindFiles2(storesDir);

            var salesTotal = CalculateSalesTotal(salesFiles);

            //File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);
            File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");
        }
    }

    class SalesTotal
    {
        public double Total { get; set; }
    }

    class GitClass 
    {
        
    }
}