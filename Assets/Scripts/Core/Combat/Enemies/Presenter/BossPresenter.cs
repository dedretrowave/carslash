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

        public override void OnAttack(Transform player)
        {
            Vector3 pushPosition = player.position + View.transform.forward * 10f;
            player.DOMove(pushPosition, 1f);
            TakeDamage(10f);
        }
    }
}