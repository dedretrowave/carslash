using System;
using Core.Player;
using Core.Shops;
using Player;
using UnityEngine;

namespace Scenes
{
    public class MainScene : MonoBehaviour
    {
        [SerializeField] private PlayerMainSceneInstaller _player;
        [SerializeField] private ShopsInstaller _skins;

        private void Start()
        {
            _player.Construct();
            _skins.Construct();
        }

        private void OnDisable()
        {
            _player.Disable();
            _skins.Disable();
        }
    }
}