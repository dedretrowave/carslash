using System;
using Core.Shops;
using Player;
using UnityEngine;

namespace Scenes
{
    public class MainScene : MonoBehaviour
    {
        [SerializeField] private PlayerInstaller _player;
        [SerializeField] private SkinsInstaller _skins;

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