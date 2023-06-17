using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain != "no")
        {
            Random randomNumber = new Random();
            int magicNumber = randomNumber.Next(1, 101);

            Console.WriteLine("Welcome to the Guess My Number game!");

            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");

                    Console.WriteLine($"It took you {guessCount} guesses to find the magic number.");

                    Console.Write("Do you want to play again? (yes/no): ");
                    playAgain = Console.ReadLine().ToLower();

                    
                    Console.WriteLine();
                }
            }

        }

        
        
    }
}