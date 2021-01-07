using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            //drawing a game field frame
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point snakeTail = new Point(15, 15, '¤');
            Snake snake = new Snake(snakeTail,5 , Direction.RIGHT);
            snake.Draw();

            FoodGeneration foodGeneration = new FoodGeneration(80, 25, '£');
            Point food = foodGeneration.GenerateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodGeneration.GenerateFood();
                    food.Draw();
                    score++;
                }
                else
                {
                    snake.Move();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }
                Thread.Sleep(300);
                
            }
            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();
        }

        public static void WriteGameOver(string score)
        {
            int xOffset = 25;
            int yOfsset = 8;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(xOffset, yOfsset++);
            WriteText("=====================", xOffset, yOfsset++);
            WriteText("     GAME OVER       ", xOffset+1, yOfsset++);
            yOfsset++;
            WriteText($"You scored {score} points", xOffset+ 2, yOfsset++);
            WriteText("", xOffset+1, yOfsset++);
            WriteText("=====================", xOffset, yOfsset++);
        }

        public static void WriteText(String text, int xOffset, int yOfsett)
        {
            Console.SetCursorPosition(xOffset, yOfsett);
            Console.WriteLine(text);
        }
    }
}
