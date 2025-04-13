namespace Palindrome_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        // my code beats 79% | 82% || runtime || memory
        public bool IsPalindrome(int x)
        {
            int original = x;
            int reversed = 0;

            while (x > 0)
            {
                int digit = x % 10;
                reversed = reversed * 10 + digit;
                x /= 10;
            }

            return original == reversed;

        }

        // exeple 99.9, 94.04
        // sometime get 79 runtime
        public bool IsPalindromeEX(int x)
        {
            int r = 0, c = x;
            while (c > 0)
            {
                r = r * 10 + c % 10;
                c /= 10;
            }
            return r == x;
        }
    }
}
