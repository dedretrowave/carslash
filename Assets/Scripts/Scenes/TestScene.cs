using System;
using Core.Player;
using Player.Movement.Presenter;
using UnityEngine;

namespace Scenes
{
    public class TestScene : MonoBehaviour
    {
        [SerializeField] private PlayerMainSceneInstaller _playerInstaller;

        private void Start()
        {
            _playerInstaller.Construct();
        }

        private void OnDisable()
        {
            _playerInstaller.Disable();
        }
    }
}