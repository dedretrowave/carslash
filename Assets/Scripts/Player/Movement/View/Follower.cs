using System;
using DG.Tweening;
using UnityEngine;

namespace Player.Movement.View
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private MovementView _destinationPoint;
        [SerializeField] private float _tweenMoveSpeed;
        [SerializeField] private float _tweenTurnSpeed;

        private void FixedUpdate()
        {
            transform.DOMove(_destinationPoint.Position, _tweenMoveSpeed);
            transform.DOLookAt(_destinationPoint.Position, _tweenTurnSpeed);
        }
    }
}