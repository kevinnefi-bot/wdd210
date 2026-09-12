// =========================================================================================
// EXCEEDING REQUIREMENTS / CREATIVITY REPORT:
// 1. Enhanced Custom Delimiter: Used a multi-character delimiter ('~|~') for saving and 
//    loading files to safely handle commas and quotes in responses.
// 2. Extended Prompts List: Added extra thought-provoking prompts beyond the initial 5.
// 3. Robust File Validation: Handled non-existent file checks safely in LoadFromFile() to prevent crashes.
// =========================================================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string dateText = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(dateText, prompt, response);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry recorded.\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.\n");
                    break;
            }
        }
    }
}

public class Journal
{
    public List<Entry> _entries { get; set; }

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.\n");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetFormattedEntry());
            }
        }
        Console.WriteLine($"Journal successfully saved to '{file}'.\n");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"Error: The file '{file}' does not exist.\n");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            if (parts.Length == 3)
            {
                string date = parts[0];
                string prompt = parts[1];
                string entryText = parts[2];

                Entry entry = new Entry(date, prompt, entryText);
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal successfully loaded from '{file}'.\n");
    }
}