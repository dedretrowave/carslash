using UnityEngine;

namespace Player.Skin.View
{
    public class SkinView : MonoBehaviour
    {
        public void Show(Components.Skin skin)
        {
            Instantiate(skin, transform);
        }
    }
}