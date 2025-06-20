namespace EternalQuest.Models
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete = false;

        public SimpleGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            return 0;
        }

        public override bool IsComplete() => _isComplete;

        public override string GetStatus() => _isComplete ? "[X]" : "[ ]";

        public override string GetGoalType() => "SimpleGoal";

        public override string Serialize() =>
            $"{GetGoalType()},{_name},{_description},{_points},{_isComplete}";

        public override void Deserialize(string data)
        {
            var parts = data.Split(',');
            if (parts.Length >= 5)
            {
                _name = parts[1];
                _description = parts[2];
                _points = int.Parse(parts[3]);
                _isComplete = bool.Parse(parts[4]);
            }
        }
    }
}

