using System;
using System.Collections.Generic;

namespace BaseballGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int againGame = 1;
            while (againGame == 1)
            {
                Console.WriteLine("+----------------------------------------------------------+");
                Console.WriteLine("|                       숫자야구 게임                      |");
                Console.WriteLine("+----------------------------------------------------------+");
                Console.WriteLine("| 수비수인 컴퓨터가 네개의 숫자와 각각의 위치를 골랐습니다.|");
                Console.WriteLine("|    각 숫자는 0~9중에 하나며 중복되는 숫자는 없습니다.    |");
                Console.WriteLine("|           모든 숫자와 위치를 맞히면 승리합니다.          |");
                Console.WriteLine("|        숫자와 순서가 둘 다 맞으면 스트라이크입니다.      |");
                Console.WriteLine("|            숫자만 맞고 순서가 틀리면 볼입니다.           |");
                Console.WriteLine("|                 숫자가 틀리면 아웃입니다.                |");
                Console.WriteLine("+----------------------------------------------------------+");

                const int digit = 4;
                Random random = new Random();

                List<int> RandomNumbers = new List<int>(digit);

                int RandomNumber = 0;

                //creat not overlapping random numbers
                while (RandomNumbers.Count < digit)
                {
                    RandomNumber = random.Next(0, 10);
                    if (RandomNumbers.Contains(RandomNumber) == false)
                    {
                        RandomNumbers.Add(RandomNumber);
                    }
                }

                while (true)
                {
                    List<int> guesses = new List<int>(digit);
                    while (guesses.Count < digit)
                    {
                        Console.WriteLine($"> [{guesses.Count + 1}]번째 자리의 숫자를 입력하세요.");

                        int guess;
                        bool bSuccess = int.TryParse(Console.ReadLine(), out guess);

                        if (bSuccess == false)
                        {
                            Console.WriteLine("숫자 외에 다른 값을 입력할 수 없습니다.\n");
                            continue;
                        }

                        if (guess > 9 || guess < 0)
                        {
                            Console.WriteLine("0과 10 사이의 숫자를 입력해 주십시오.\n");
                            continue;
                        }

                        if (guesses.Contains(guess) == true)
                        {
                            Console.WriteLine("중복되는 숫자는 입력하실수 없습니다.\n");
                            continue;
                        }

                        guesses.Add(guess);
                    }

                    Console.WriteLine("\n> 공격수가 고른 숫자");

                    foreach (int guess in guesses)
                    {
                        Console.WriteLine(guess);
                    }

                    int strikeCount = 0;
                    int ballCount = 0;

                    for (int i = 0; i < digit; i++)
                    {
                        if (RandomNumbers[i] == guesses[i])
                        {
                            strikeCount++;
                        }

                        else if (RandomNumbers.Contains(guesses[i]))
                        {
                            ballCount++;
                        }
                    }

                    Console.WriteLine($"strike: {strikeCount}, ball: {ballCount}, out: {digit - strikeCount - ballCount}");

                    if (strikeCount == digit)
                    {
                        Console.WriteLine($"정답: [{RandomNumbers[0]}], [{RandomNumbers[1]}], [{RandomNumbers[2]}], [{RandomNumbers[3]}]");
                        Console.WriteLine("축하드립니다 게임에서 승리하셨습니다!.");
                        Console.WriteLine("게임을 다시 진행하시겠습니까? 1.다시하기");
                        bool bSuccess = int.TryParse(Console.ReadLine(), out againGame);

                        if (bSuccess == false)
                        {
                            break;
                        }

                        else if (againGame == 1)
                        {
                            Console.Clear();
                        }

                        break;
                    }
                }
            }
        }
    }
}