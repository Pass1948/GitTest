namespace Solution2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a text in Korean");
            string text = Console.ReadLine();
            char gap = ' ';
            int countWord = text.Count(countWord => (countWord == gap));
            countWord++;
            Console.WriteLine(countWord);

        }
    }
}