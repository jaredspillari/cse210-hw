namespace EternalQuest.Models
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonus = bonus;
        }

        public override int RecordEvent()
        {
            if (_currentCount < _targetCount)
            {
                _currentCount++;
                return _currentCount == _targetCount ? _points + _bonus : _points;
            }
            return 0;
        }

        public override bool IsComplete() => _currentCount >= _targetCount;

        public override string GetStatus() =>
            $"[{(IsComplete() ? "X" : " ")}] Completed {_currentCount}/{_targetCount} times";

        public override string GetGoalType() => "ChecklistGoal";

        public override string Serialize() =>
            $"{GetGoalType()},{_name},{_description},{_points},{_targetCount},{_currentCount},{_bonus}";

        public override void Deserialize(string data)
        {
            var parts = data.Split(',');
            if (parts.Length >= 7)
            {
                _name = parts[1];
                _description = parts[2];
                _points = int.Parse(parts[3]);
                _targetCount = int.Parse(parts[4]);
                _currentCount = int.Parse(parts[5]);
                _bonus = int.Parse(parts[6]);
            }
        }
    }
}
