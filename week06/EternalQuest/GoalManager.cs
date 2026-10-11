using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Keep striving on your Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        // EXCEEDING REQUIREMENTS: Sistema de niveles y títulos gamificados basados en los puntos
        int level = (_score / 1000) + 1;
        string title = level switch
        {
            1 => "Novice Pilgrim",
            2 => "Seeker of Truth",
            3 => "Dedicated Disciple",
            4 => "Steadfast Warrior",
            5 => "Master of Eternal Quest",
            _ => "Legendary Hero"
        };

        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"[Level {level}: {title}]");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string pointsStr = Console.ReadLine();

        if (typeChoice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, pointsStr));
        }
        else if (typeChoice == "2")
        {
            _goals.Add(new EternalGoal(name, description, pointsStr));
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, pointsStr, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type selected.");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            int pointsEarned = int.Parse(goal.GetPoints());

            if (goal is ChecklistGoal checklistGoal)
            {
                int beforeCompleted = checklistGoal.GetAmountCompleted();
                checklistGoal.RecordEvent();
                int afterCompleted = checklistGoal.GetAmountCompleted();

                _score += pointsEarned;

                if (afterCompleted == checklistGoal.GetTarget() && beforeCompleted < checklistGoal.GetTarget())
                {
                    int bonus = checklistGoal.GetBonus();
                    _score += bonus;
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points plus a bonus of {bonus} points!");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                }
            }
            else if (goal is SimpleGoal simpleGoal)
            {
                if (!simpleGoal.IsComplete())
                {
                    simpleGoal.RecordEvent();
                    _score += pointsEarned;
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                }
                else
                {
                    Console.WriteLine("You have already completed this goal!");
                }
            }
            else
            {
                goal.RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            }

            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(":");
                string goalType = parts[0];
                string details = parts[1];
                string[] values = details.Split(",");

                if (goalType == "SimpleGoal")
                {
                    string name = values[0];
                    string description = values[1];
                    string points = values[2];
                    bool isComplete = bool.Parse(values[3]);
                    _goals.Add(new SimpleGoal(name, description, points, isComplete));
                }
                else if (goalType == "EternalGoal")
                {
                    string name = values[0];
                    string description = values[1];
                    string points = values[2];
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (goalType == "ChecklistGoal")
                {
                    string name = values[0];
                    string description = values[1];
                    string points = values[2];
                    int bonus = int.Parse(values[3]);
                    int target = int.Parse(values[4]);
                    int amountCompleted = int.Parse(values[5]);
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
