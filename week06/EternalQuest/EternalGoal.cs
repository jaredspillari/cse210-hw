namespace EternalQuest.Models
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent() => _points;

        public override bool IsComplete() => false;

        public override string GetStatus() => "[∞]";

        public override string GetGoalType() => "EternalGoal";

        public override string Serialize() =>
            $"{GetGoalType()},{_name},{_description},{_points}";

        public override void Deserialize(string data)
        {
            var parts = data.Split(',');
            if (parts.Length >= 4)
            {
                _name = parts[1];
                _description = parts[2];
                _points = int.Parse(parts[3]);
            }
        }
    }
}
