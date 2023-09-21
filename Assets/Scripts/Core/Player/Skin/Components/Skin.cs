using UnityEngine;

namespace Core.Player.Skin.Components
{
    public class Skin : MonoBehaviour
    {
        [SerializeField] private Mesh _mesh;
        [SerializeField] private MeshFilter _filter;

        private void Awake()
        {
            _filter.mesh = _mesh;
        }
    }
}