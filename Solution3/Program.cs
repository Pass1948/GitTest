namespace Solution3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IsPrime(8);
        }
        static bool IsPrime(int n)
        {
            int number = 2;
            int resutl = number / n;
            if (resutl == 0)
            {
                Console.WriteLine("정수입니다");
                return true;
            }
            else
            {
                Console.WriteLine("소수입니다");
                return false;
            }
        }

    }
}