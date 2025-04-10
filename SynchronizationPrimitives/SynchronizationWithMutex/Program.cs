﻿using System.Threading;

namespace SynchronizationWithMutex
{
    class Program
    {
        static int x = 0;
        static Mutex mutexObj = new Mutex();
        static void Main(string[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = $"Thread {i}";
                myThread.Start();
            }

        }
        public static void Count()
        {
            mutexObj.WaitOne();
            x = 1;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            mutexObj.ReleaseMutex();
        }
    }
}
