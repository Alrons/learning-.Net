namespace SynchronizationWithSpinLock
{
    class Program
    {
        private static SpinLock spinLock = new SpinLock();
        private static int counter = 0;

        static void Main()
        {
            Thread[] threads = new Thread[10];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(IncrementCounter);
                threads[i].Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }

            Console.WriteLine($"Final counter value: {counter}");
        }

        static void IncrementCounter()
        {
            for (int i = 0; i < 1000; i++)
            {
                bool lockTaken = false;
                try
                {
                    spinLock.Enter(ref lockTaken);
                    counter++;
                }
                finally
                {
                    if (lockTaken)
                        spinLock.Exit();
                }
            }
        }
    }
}
