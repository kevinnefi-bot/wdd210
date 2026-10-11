// =========================================================================================
// EXCEEDING REQUIREMENTS / CREATIVITY REPORT:
// 1. Leveling & Title System: Implemented a dynamic progression system where the user earns 
//    levels and motivational titles (e.g., Novice Pilgrim, Seeker of Truth, Steadfast Warrior) 
//    automatically every 1,000 points accrued, displayed directly on the main menu.
// 2. Polymorphic Design: Leveraged abstract base class methods and overridden behaviors 
//    in SimpleGoal, EternalGoal, and ChecklistGoal for clean and extensible architecture.
// 3. Robust Serialization: Used custom string representations (: and , delimiters) to save and 
//    restore complex object states cleanly.
// =========================================================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
