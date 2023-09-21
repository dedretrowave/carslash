namespace Core.Player.InvincibilityFrame.Model
{
    public class InvincibilityFrameModel
    {
        private InvincibilityFrameSettings _settings;
        private bool _isActive;

        public float DurationInSecs => _settings.DurationInSecs;
        public bool IsActive => _isActive;

        public InvincibilityFrameModel(InvincibilityFrameSettings settings)
        {
            _settings = settings;
            _isActive = false;
        }

        public void Activate()
        {
            _isActive = true;
        }

        public void Deactivate()
        {
            _isActive = false;
        }
    }
}