namespace Solution4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumResult = 0;
            Console.WriteLine(SumOfDigits(sumResult));

            static int SumOfDigits(int num)
            {
                num = 0;
                string text = Console.ReadLine();
                char[] arreyNumbers = text.ToCharArray();
                for (int i = 0; i < arreyNumbers.Length; i++)
                    num += int.Parse(arreyNumbers[i].ToString());
                return num;
            }
        }
    }
}