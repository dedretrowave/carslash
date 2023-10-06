namespace Core.LevelProgression.Progression.Model
{
    public abstract class ProgressInt
    {
        private int _value;
        
        public int Value
        {
            get => _value;
            set
            {
                if (value < 0) return;

                _value = value;
            }
        }
    }
    
    public class CurrentLevelInt : ProgressInt {}
    
    public class ProgressionInt : ProgressInt {}
}