// Exceeding Requirements Description:
// 1. Improved word selection: The algorithm in Scripture.cs only picks from words 
//    that are NOT currently hidden, avoiding redundant selections and ensuring steady progress.
// 2. Added a Scripture Library: Program selects a scripture at random from a predefined 
//    list/library instead of using only a hardcoded single scripture.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Biblioteca de escrituras para seleccionar una al azar (Exceeding Requirements)
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            )
        };

        // Seleccionar una escritura al azar de la biblioteca
        Random random = new Random();
        Scripture currentScripture = library[random.Next(library.Count)];

        // Bucle principal del programa
        while (true)
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");

            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            if (currentScripture.IsCompletelyHidden())
            {
                break;
            }

            // Ocultar 3 palabras por cada interacción
            currentScripture.HideRandomWords(3);
        }

        // Muestra final con todas las palabras ocultas
        Console.Clear();
        Console.WriteLine(currentScripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Program ended. All words are hidden.");
    }
}