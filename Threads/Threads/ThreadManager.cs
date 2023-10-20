using System;
using System.Threading;

namespace Threads
{
    public class ThreadManager
    {
        private readonly Thread _thread;

        public ThreadManager(string text, ConsoleColor consoleColor, int timeout, CancellationToken ct)
        {
            _thread = new Thread(() =>
            {
                while (!ct.IsCancellationRequested)
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = consoleColor;

                    try
                    {
                        Console.WriteLine(text);
                    }
                    finally
                    {
                        Console.ForegroundColor = color;
                        Thread.Sleep(timeout);
                    }
                }
            });
        }

        public void Start()
        {
            _thread.Start();
        }
    }
}