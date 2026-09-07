using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 3: Generar un número aleatorio del 1 al 100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        // Core Requirement 2: Bucle que se repite mientras el usuario no adivine el número
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Core Requirement 1: Estructura if/else para indicar si debe adivinar más alto o más bajo
            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}