namespace SynchronizationWithAutoResetEvent
{
    class Program
    {
        static int x = 0;
        static AutoResetEvent waitHandler = new AutoResetEvent(true);
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
            waitHandler.WaitOne();
            x = 1;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            waitHandler.Set();
        }
    }
}
