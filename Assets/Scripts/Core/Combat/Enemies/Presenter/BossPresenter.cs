using Core.Combat.Enemies.Components;
using Core.Combat.Enemies.View;
using DG.Tweening;
using UnityEngine;

namespace Core.Combat.Enemies.Presenter
{
    public class BossPresenter : EnemyPresenter
    {
        public BossPresenter(EnemyView view, Transform player, EnemySettings settings) : base(view, player, settings)
        { }

        public new void OnAttack(Transform player)
        {
            player.DOMove(-player.forward, 1f);
            TakeDamage(10f);
        }
    }
}