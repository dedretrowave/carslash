using Combat;
using DI;
using LevelProgression;
using Player;
using Save;
using UnityEngine;

namespace Scenes
{
    public class LevelScene : MonoBehaviour
    {
        [SerializeField] private CombatInstaller _combat;
        [SerializeField] private LevelProgressionInstaller _levelProgression;
        [SerializeField] private PlayerInstaller _player;
        [SerializeField] private SaveMediator _saveMediator;

        private void Start()
        {
            _levelProgression.Construct();
            _player.Construct();
            _combat.Construct();

            _levelProgression.LevelEnded += _combat.ClearEnemies;
            _levelProgression.NewLevelStarted += _combat.OnNewLevelStarted;

            _combat.OutOfHealth += _player.Disable;
            _combat.OutOfHealth += _levelProgression.OnLose;
        }

        private void OnDisable()
        {
            _levelProgression.Disable();
            _player.Disable();
            _combat.Disable();

            _levelProgression.LevelEnded -= _combat.ClearEnemies;
            _levelProgression.NewLevelStarted -= _combat.OnNewLevelStarted;
            
            _combat.OutOfHealth -= _player.Disable;
            _combat.OutOfHealth -= _levelProgression.OnLose;
        }
    }
}