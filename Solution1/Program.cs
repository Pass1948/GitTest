namespace Solution1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a \"pineapple is yummy apple\"");
            string text = Console.ReadLine();
            text.Contains("apple");

            if (text.Contains("apple") == true)
            {
                int b = text.IndexOf("apple");
                Console.WriteLine(b);
            }

        }
    }
}