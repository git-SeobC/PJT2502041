namespace PJT2502041
{
    internal class Program
    {
        /// <summary>
        /// 1~52의 숫자가 담긴 배열에서 랜덤 8개의 중복되지 않는 숫자 뽑기
        /// 해당 문제는 트럼프 카드를 생각하고, 배열 자체를 셔플 후 8개 뽑기한다고 생각
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] numbers = new int[52];
            int pickCount = 8;
            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }

            // 0 ~ pickCount-1 index 값을 무작위 인덱스 값이랑 교체
            for (int i = 0; i < pickCount; i++)
            {
                int randomIndex = random.Next(1, 52);
                int tempNum = numbers[i];
                numbers[i] = numbers[randomIndex];
                numbers[randomIndex] = tempNum;
            }

            // 0 ~ pickCount-1 index 값을 출력
            Console.Write("선택된 랜덤 숫자 : ");
            for (int i = 0; i < pickCount; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
