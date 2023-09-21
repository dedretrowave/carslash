namespace Player.Skin.Model
{
    public class SkinModel
    {
        private Core.Player.Skin.Components.Skin _skin;

        public Core.Player.Skin.Components.Skin Skin => _skin;

        public SkinModel(SkinSettings settings)
        {
            //TODO: ADD SAVE
            Set(settings.DefaultSkin);
        }

        public void Set(Core.Player.Skin.Components.Skin skin)
        {
            _skin = skin;
        }
    }
}