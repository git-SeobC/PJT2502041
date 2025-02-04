using System.ComponentModel.Design;

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
            string[] numbers = new string[52];
            //int pickCount = 8;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i >= 0 && i < 13)
                {
                    if (i % 13 == 0) numbers[i] = "♥A";
                    else if (i % 13 == 10) numbers[i] = "♥J";
                    else if (i % 13 == 11) numbers[i] = "♥Q";
                    else if (i % 13 == 12) numbers[i] = "♥K";
                    else numbers[i] = "♥" + (i % 13 + 1).ToString();
                }
                else if (i >= 13 && i < 26)
                {
                    if (i % 13 == 0) numbers[i] = "◆A";
                    else if (i % 13 == 10) numbers[i] = "◆J";
                    else if (i % 13 == 11) numbers[i] = "◆Q";
                    else if (i % 13 == 12) numbers[i] = "◆K";
                    else numbers[i] = "◆" + (i % 13 + 1).ToString();
                }
                else if (i >= 26 && i < 39)
                {
                    if (i % 13 == 0) numbers[i] = "♣A";
                    else if (i % 13 == 10) numbers[i] = "♣J";
                    else if (i % 13 == 11) numbers[i] = "♣Q";
                    else if (i % 13 == 12) numbers[i] = "♣K";
                    else numbers[i] = "♣" + (i % 13 + 1).ToString();
                }
                else
                {
                    if (i % 13 == 0) numbers[i] = "♠A";
                    else if (i % 13 == 10) numbers[i] = "♠J";
                    else if (i % 13 == 11) numbers[i] = "♠Q";
                    else if (i % 13 == 12) numbers[i] = "♠K";
                    else numbers[i] = "♠" + (i % 13 + 1).ToString();
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
                if (i % 13 == 12)
                {
                    Console.WriteLine();
                }
            }

            //Random random = new Random();

            // 0 ~ pickCount-1 index 값을 무작위 인덱스 값이랑 교체
            //for (int i = 0; i < pickCount; i++)
            //{
            //    int randomIndex = random.Next(0, numbers.Length);
            //    int tempNum = numbers[i];
            //    numbers[i] = numbers[randomIndex];
            //    numbers[randomIndex] = tempNum;
            //}
            // => random.Shuffle(numbers);

            // 0 ~ pickCount-1 index 값을 출력
            //Console.Write("선택된 랜덤 숫자 : ");
        }

        // 나머지 값 구하는 것을 통해 0(+1) ~ 7(+1) 사이의 값을 구할 수 있음
        // Console.WriteLine(random.Next() % 8 + 1);
    }
}
