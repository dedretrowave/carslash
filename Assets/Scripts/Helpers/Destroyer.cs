using UnityEngine;

namespace Helpers
{
    public class Destroyer : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}