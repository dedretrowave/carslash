namespace Player.Skin.Model
{
    public class SkinModel
    {
        private Components.Skin _skin;

        public Components.Skin Skin => _skin;

        public SkinModel(SkinSettings settings)
        {
            //TODO: ADD SAVE
            Set(settings.DefaultSkin);
        }

        public void Set(Components.Skin skin)
        {
            _skin = skin;
        }
    }
}