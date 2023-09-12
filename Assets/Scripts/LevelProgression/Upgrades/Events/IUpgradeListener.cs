namespace LevelProgression.Upgrades.Events
{
    public interface IUpgradeListener
    {
        public void ApplyUpgrade(object buff);
    }
}