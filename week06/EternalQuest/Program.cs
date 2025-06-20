using System;
using System.Collections.Generic;
using EternalQuest.Models;
using EternalQuest.Data;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;
    static GoalRepository repository = new GoalRepository("goals.txt");

    static void Main(string[] args)
    {
        // Additional features:
        // - Level system based on points (level up every 1000 points)
        // - Motivational random messages
        // - Save and load goals and score from a file

        totalScore = repository.LoadGoals(goals);

        Console.WriteLine("Welcome to Eternal Quest!");
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. View goals");
            Console.WriteLine("3. Record event");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save progress");
            Console.WriteLine("6. Load progress");
            Console.WriteLine("7. Exit");

            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ShowGoals();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    ShowScore();
                    break;
                case "5":
                    SaveProgress();
                    break;
                case "6":
                    LoadProgress();
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Select the goal type: ");
        var type = Console.ReadLine();

        Console.Write("Goal name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points awarded per event: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points, defaulting to 0.");
            points = 0;
        }

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("Simple Goal created.");
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("Eternal Goal created.");
                break;
            case "3":
                Console.Write("Number of times to complete: ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid number, defaulting to 1.");
                    target = 1;
                }
                Console.Write("Bonus points upon completion: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus, defaulting to 0.");
                    bonus = 0;
                }
                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("Checklist Goal created.");
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (goals.Count == 0)
        {
            Console.WriteLine("You have no goals created.");
            return;
        }
        for (int i = 0; i < goals.Count; i++)
        {
            var g = goals[i];
            Console.WriteLine($"{i + 1}. {g.GetStatus()} {g.Name} - {g.Description}");
        }
    }

    static void RecordEvent()
    {
        ShowGoals();
        if (goals.Count == 0) return;

        Console.Write("Select the goal you completed: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        var goal = goals[choice - 1];
        int earnedPoints = goal.RecordEvent();

        if (earnedPoints > 0)
        {
            totalScore += earnedPoints;
            Console.WriteLine($"You earned {earnedPoints} points!");
        }
        else
        {
            Console.WriteLine("This goal is already complete or no points awarded.");
        }
    }

    static void ShowScore()
    {
        Console.WriteLine($"\nTotal Score: {totalScore}");
        int level = totalScore / 1000;
        Console.WriteLine($"Current Level: {level}");
        var messages = new string[]
        {
            "Keep going, eternal warrior!",
            "You're making great progress!",
            "Every step counts on your eternal quest.",
            "Don't give up, you're so close.",
            "You're a true spiritual champion!"
        };
        Random rand = new Random();
        Console.WriteLine(messages[rand.Next(messages.Length)]);
    }

    static void SaveProgress()
    {
        repository.SaveGoals(goals, totalScore);
        Console.WriteLine("Progress saved.");
    }

    static void LoadProgress()
    {
        totalScore = repository.LoadGoals(goals);
        Console.WriteLine("Progress loaded.");
    }
}
