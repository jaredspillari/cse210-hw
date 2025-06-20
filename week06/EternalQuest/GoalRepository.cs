using System;
using System.Collections.Generic;
using System.IO;
using EternalQuest.Models;

namespace EternalQuest.Data
{
    public class GoalRepository
    {
        private readonly string _filePath;

        public GoalRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveGoals(List<Goal> goals, int score)
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(score);
                foreach (var goal in goals)
                {
                    writer.WriteLine(goal.Serialize());
                }
            }
        }

        public int LoadGoals(List<Goal> goals)
        {
            goals.Clear();
            int score = 0;

            if (!File.Exists(_filePath))
                return 0;

            using (StreamReader reader = new StreamReader(_filePath))
            {
                if (!int.TryParse(reader.ReadLine(), out score))
                    score = 0;

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 0) continue;

                    Goal goal = parts[0] switch
                    {
                        "SimpleGoal" => new SimpleGoal("", "", 0),
                        "EternalGoal" => new EternalGoal("", "", 0),
                        "ChecklistGoal" => new ChecklistGoal("", "", 0, 0, 0),
                        _ => null
                    };

                    if (goal != null)
                    {
                        goal.Deserialize(line);
                        goals.Add(goal);
                    }
                }
            }
            return score;
        }
    }
}

