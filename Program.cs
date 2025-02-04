using System.ComponentModel.Design;
using System.Numerics;

namespace PJT2502041
{
    /// <summary>
    /// 1~52의 숫자가 담긴 배열에서 랜덤 8개의 중복되지 않는 숫자 뽑기
    /// 해당 문제는 트럼프 카드를 생각하고, 배열 자체를 셔플 후 8개 뽑기한다고 생각
    /// </summary>
    /// <param name="args"></param>
    internal class Program
    {
        static Dictionary<string, int> MakeCard()
        {
            Dictionary<string, int> cardDic = new Dictionary<string, int>();
            string[] card = new string[52];
            for (int i = 0; i < card.Length; i++)
            {
                if (i >= 0 && i < 13)
                {
                    if (i % 13 == 0)
                    {
                        card[i] = "♥A";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 10)
                    {
                        card[i] = "♥J";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 11)
                    {
                        card[i] = "♥Q";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 12)
                    {
                        card[i] = "♥K";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else
                    {
                        card[i] = "♥" + (i % 13 + 1).ToString();
                        cardDic[card[i]] = i % 13 + 1;
                    }
                }
                else if (i >= 13 && i < 26)
                {
                    if (i % 13 == 0)
                    {
                        card[i] = "◆A";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 10)
                    {
                        card[i] = "◆J";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 11)
                    {
                        card[i] = "◆Q";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 12)
                    {
                        card[i] = "◆K";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else
                    {
                        card[i] = "◆" + (i % 13 + 1).ToString();
                        cardDic[card[i]] = i % 13 + 1;
                    }
                }
                else if (i >= 26 && i < 39)
                {
                    if (i % 13 == 0)
                    {
                        card[i] = "♣A";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 10)
                    {
                        card[i] = "♣J";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 11)
                    {
                        card[i] = "♣Q";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 12)
                    {
                        card[i] = "♣K";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else
                    {
                        card[i] = "♣" + (i % 13 + 1).ToString();
                        cardDic[card[i]] = i % 13 + 1;
                    }
                }
                else
                {
                    if (i % 13 == 0)
                    {
                        card[i] = "♠A";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 10)
                    {
                        card[i] = "♠J";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 11)
                    {
                        card[i] = "♠Q";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else if (i % 13 == 12)
                    {
                        card[i] = "♠K";
                        cardDic[card[i]] = i % 13 + 1;
                    }
                    else
                    {
                        card[i] = "♠" + (i % 13 + 1).ToString();
                        cardDic[card[i]] = i % 13 + 1;
                    }
                }
            }
            return cardDic;
        }

        static void DeckShuffle(ref KeyValuePair<string, int>[] paramCard)
        {
            Random random = new Random();
            for (int i = 0; i < 52; i++)
            {
                int randomIndex = random.Next(0, paramCard.Length);
                var tempCard = paramCard[i];
                paramCard[i] = paramCard[randomIndex];
                paramCard[randomIndex] = tempCard;
            }
        }

        static void PrintArray(IEnumerable<KeyValuePair<string, int>> array)
        {
            int count = 0;
            foreach (var tag in array)
            {
                Console.Write(tag);
                count++;
                if (count % 13 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // 카드 생성
            Dictionary<string, int> deck = MakeCard();
            PrintArray(deck);
            // 카드 셔플
            KeyValuePair<string, int>[] shuffledCard = deck.ToArray();
            DeckShuffle(ref shuffledCard);

            // 초기화
            int computerScore = 0;
            int playerScore = 0;
            bool computerTurn = true;
            bool playerTurn = true;
            int turnCount = 0;
            int computerAces = 0;
            int playerAces = 0;
            List<KeyValuePair<string, int>> playerCard = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> computerCard = new List<KeyValuePair<string, int>>();

            while (computerTurn || playerTurn)
            {
                if (turnCount > 51) break; // 준비된 카드 모두 사용시 자동 게임 종료
                // Computer Turn
                if (computerTurn)
                {
                    var currentCard = shuffledCard[turnCount]; // 뽑힌 카드
                    computerCard.Add(currentCard); // Computer가 뽑은 카드 추가
                    if (currentCard.Value == 1) // Ace 점수 계산 조건 추가 1 or 10
                    {
                        computerScore += 11;
                        computerAces++;
                    }
                    else
                    {
                        computerScore += currentCard.Value;
                    }

                    // Ace 점수 동적 조정
                    while (computerScore > 21 && computerAces > 0)
                    {
                        computerScore -= 10; // Ace를 1로 변경
                        computerAces--;
                    }


                    if (computerScore > 21)
                    {
                        computerTurn = false;
                        computerScore = 0; // Out
                        Console.WriteLine("Computer Out");
                    }
                    else
                    {
                        computerTurn = computerScore < 17;

                        if (computerTurn && computerScore > 12)
                        {
                            computerTurn = new Random().Next(100) > 30; // 30% 확률
                        }
                    }
                    turnCount++; // 다음 카드
                }

                // Player Turn
                if (playerTurn)
                {
                    var currentCard = shuffledCard[turnCount]; // 뽑힌 카드
                    playerCard.Add(currentCard);
                    if (currentCard.Value == 1) // Ace 일단 11 up
                    {
                        playerScore += 11;
                        playerAces++;
                    }
                    else
                    {
                        playerScore += currentCard.Value;
                    }


                    // Player 소유 카드
                    Console.Write("Player Card : ");
                    foreach (var card in playerCard)
                    {
                        Console.Write($"[{card.Key} / {card.Value}]");
                    }
                    Console.WriteLine();
                    Console.WriteLine("If you want one more card, press \"SPACE\"");


                    if (playerAces > 0) // Ace 를 어떤 숫자로 선택할지 골라야하는 부분 추가 해야함
                    {
                        Console.WriteLine("1 => 1");
                        Console.WriteLine("2 => 11");
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        Console.WriteLine();
                        if (keyInfo.Key == ConsoleKey.NumPad2)
                        {
                            playerScore -= 10;
                        }
                    }


                    Console.WriteLine($"Player Total Score : {playerScore}");


                    if (playerScore > 21 && playerAces > 0) // 블랙잭 넘으면 끝
                    {
                        playerTurn = false;
                        Console.WriteLine("It's Over 21");
                        playerScore = 0;
                    }
                    else
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        Console.WriteLine();
                        if (keyInfo.Key == ConsoleKey.Spacebar)
                        {
                            playerTurn = true;
                        }
                        else
                        {
                            playerTurn = false;
                        }
                    }
                    turnCount++;
                }
            }

            Console.WriteLine();
            Console.Write($"Winner is : ");
            if (computerScore <= playerScore)
            {
                if (playerScore == 21)
                {
                    Console.WriteLine("BLACK JACK!");
                }
                Console.WriteLine($"Player! \n ComputerScore : {computerScore} \n PlayerScore : {playerScore}");
            }
            else
            {
                Console.WriteLine($"Computer! \n ComputerScore : {computerScore} \n PlayerScore : {playerScore}");
            }

            Console.Write("Computer Card : ");
            foreach (var card in computerCard)
            {
                Console.Write($"[{card.Key} / {card.Value}]");
            }
            Console.WriteLine();

            #region 주석 영역
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

            // 나머지 값 구하는 것을 통해 0(+1) ~ 7(+1) 사이의 값을 구할 수 있음
            // Console.WriteLine(random.Next() % 8 + 1);
            #endregion
        }

    }
}
