using UnityEngine;

namespace Player.Skin.View
{
    public class SkinView : MonoBehaviour
    {
        [SerializeField] private Transform _childContainer;
        
        public void Show(Core.Player.Skin.Components.Skin skin)
        {
            Transform child = null;
            
            if (_childContainer.childCount != 0)
            {
                child = _childContainer.GetChild(0);
            }

            if (child != null)
            {
                Destroy(child.gameObject);
            }
            
            Instantiate(skin, _childContainer);
        }
    }
}