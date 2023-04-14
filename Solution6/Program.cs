namespace Solution6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("0~999사이에 숫자를 입력해주세요 : ");
            Random random = new Random();
            int randomNumber = random.Next(999);
            int chance = 10;
            while (chance > 0)
            {
                string text = Console.ReadLine();
                int numder = int.Parse(text);
                if (numder == randomNumber)
                {
                    Console.WriteLine("승리하셨습니다");
                    break;
                }
                if (numder != randomNumber)
                {
                    chance--;
                    Console.WriteLine("기회가 {0}번 남았습니다", chance);
                    if (numder > randomNumber)
                    {
                        Console.WriteLine("{0}이 더 큽니다  ", numder);
                        Console.WriteLine("다시 입력해주세요(0~999) : ");
                    }
                    else if (numder < randomNumber)
                    {
                        Console.WriteLine("{0}이 더 작습니다  ", numder);
                        Console.WriteLine("다시 입력해주세요(0~999) : ");
                    }
                }
                if (chance == 0)
                {
                    Console.WriteLine("다시 도전하시겠습니까? (1.예//2.아니요)");
                    string text1 = Console.ReadLine();
                    switch (text1)
                    {
                        case "1":
                            chance = 10;
                            break;
                        case "2":
                            Console.WriteLine("게임을 종료합니다");
                            return;
                    }
                }
            }
        }
    }
}