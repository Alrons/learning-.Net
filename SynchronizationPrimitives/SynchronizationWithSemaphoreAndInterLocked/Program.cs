namespace SynchronizationWithSemaphoreAndInterLocked
{
    class Program
    {
        static int count = 0;
        static Semaphore semaphore = new Semaphore(6,6);
        static void Main(string[] args)
        {
            for (int i = 1; i < 10; i++)
            {
                Thread myThread = new Thread(Work);
                myThread.Name = $"Thread {i}";
                myThread.Start();
            }

        }
        public static void Work()
        {
            semaphore.WaitOne();

            Interlocked.Increment(ref count);

            Console.WriteLine($"{Thread.CurrentThread.Name} starting... Now working {count}");

            Thread.Sleep(new Random().Next(500, 1000));

            Console.WriteLine($"{Thread.CurrentThread.Name} starting... Now working {count}");

            Interlocked.Decrement(ref count);

            semaphore.Release();

        }
    }
}
