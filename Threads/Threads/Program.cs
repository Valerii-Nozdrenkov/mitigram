using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            Console.WriteLine("Press any key to terminate the application...\n");

            var manager1 = new ThreadManager("Thread1", ConsoleColor.Cyan, 100, cts.Token);
            var manager2 = new ThreadManager("Thread2", ConsoleColor.Gray, 200, cts.Token);

            manager1.Start();
            manager2.Start();

            if (Console.ReadKey(true).Key > 0)
            {
                cts.Cancel();
            }

            cts.Dispose();
            Thread.Sleep(1000);
        }
    }
}
