using Combat;
using LevelProgression;
using Player;
using UnityEngine;

namespace Scenes
{
    public class LevelScene : MonoBehaviour
    {
        [SerializeField] private CombatInstaller _combat;
        [SerializeField] private LevelProgressionInstaller _levelProgression;
        [SerializeField] private PlayerInstaller _player;

        private void Start()
        {
            _player.Construct();
            _combat.Construct();
            _levelProgression.Construct();

            _levelProgression.UpgradeReceived += _combat.OnUpgrade;
            _levelProgression.UpgradeReceived += _player.OnUpgrade;
            _levelProgression.LevelEnded += _combat.ClearEnemies;
            _levelProgression.NewLevelStarted += _combat.OnNewLevelStarted;

            _combat.OutOfHealth += _player.Disable;
            _combat.OutOfHealth += _levelProgression.OnLose;
        }

        private void OnDisable()
        {
            _player.Disable();
            _combat.Disable();
            _levelProgression.Disable();

            _levelProgression.UpgradeReceived -= _combat.OnUpgrade;
            _levelProgression.UpgradeReceived -= _player.OnUpgrade;
            _levelProgression.LevelEnded -= _combat.ClearEnemies;
            _levelProgression.NewLevelStarted -= _combat.OnNewLevelStarted;
        }
    }
}