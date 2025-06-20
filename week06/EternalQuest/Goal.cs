namespace EternalQuest.Models
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        public abstract int RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetStatus();
        public abstract string GetGoalType();
        public abstract string Serialize();
        public abstract void Deserialize(string data);
        public string Name => _name;
        public string Description => _description;
        public int Points => _points;
    }
}

