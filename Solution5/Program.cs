namespace Solution5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 5, 5, 10 };
            int[] arr2 = { 3, 4, 5, 5, 10 };
            int[] arr3 = { 5, 5, 10, 20 };
            foreach (int i in FindCommonItems(arr1, arr2, arr3))
                Console.WriteLine(i);

            static int[] FindCommonItems(int[] arr1, int[] arr2, int[] arr3)
            {
                List<int> result = new List<int>();
                for (int i = 0; i < arr1.Length; i++)
                    for (int i2 = 0; i2 < arr2.Length; i2++)
                        for (int i3 = 0; i3 < arr3.Length; i3++)
                            if (arr1[i] == arr2[i2] && arr1[i] == arr3[i3])
                                if (!result.Contains(arr1[i]))
                                    result.Add(arr1[i]);
                return result.ToArray();
            }
        }
    }
}