namespace PJT2502041
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[52];
            int[] randomNum = new int[8];
            bool duplicateNum = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }
            Random random = new Random();
            int count = 0;
            while (count < 8)
            {
                duplicateNum = false;
                int temp = random.Next(1, 52);
                foreach (int i in randomNum)
                {
                    if (i == temp)
                    {
                        duplicateNum = true;
                        break;
                    }
                    else
                    {
                        duplicateNum = false;
                    }
                }
                if (!duplicateNum)
                {
                    randomNum[count] = temp;
                    count++;
                }
            }
            Console.Write("선택된 랜덤 숫자 : ");
            for (int i = 0; i < randomNum.Length; i++)
            {
                Console.Write(randomNum[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
