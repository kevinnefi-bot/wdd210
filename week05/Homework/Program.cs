// Exceeding Requirements:
// 1. Added a session counter to track how many total activities the user performs in a single run.
// 2. Added logic in ListingActivity and ReflectionActivity to ensure smooth user experience with non-blocking inputs.

using System;

class Program
{
    static void Main(string[] args)
    {
        int activityCount = 0;
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine($"\nActivities completed in this session: {activityCount}");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                activityCount++;
            }
            else if (choice == "2")
            {
                ReflectionActivity reflection = new ReflectionActivity();
                reflection.Run();
                activityCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                activityCount++;
            }
            else if (choice == "4")
            {
                Console.WriteLine("\nGoodbye!");
            }
            else
            {
                Console.WriteLine("\nInvalid option. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }
}