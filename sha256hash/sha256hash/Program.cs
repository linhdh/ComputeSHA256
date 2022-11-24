using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace sha256hash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Missing [filename] parameter");
                Console.WriteLine("Usage: sha256hash [filename]");
                return;
            }

            var filename = args[0];
            
            if (!File.Exists(filename))
            {
                Console.WriteLine("File {0} does not exist.", filename);
                return;
            }
            var watch = Stopwatch.StartNew();

            using (SHA256 iSHA256 = SHA256.Create())
            using (FileStream fileStream = File.OpenRead(filename))
            {
                byte[] hashValue = iSHA256.ComputeHash(fileStream);
                Console.WriteLine($"Filename: {filename}");
                Console.Write($"SHA256: ");
                for (int i = 0; i < hashValue.Length; i++)
                {
                    Console.Write($"{hashValue[i]:X2}");
                    if ((i % 4) == 3) Console.Write(" ");
                }
                Console.WriteLine();
            }
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.Elapsed}");
        }
    }
}