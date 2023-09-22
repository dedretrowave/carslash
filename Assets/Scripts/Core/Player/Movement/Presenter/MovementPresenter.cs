using Core.Player.Movement.View;
using Player.Movement.Model;
using UnityEngine;

namespace Player.Movement.Presenter
{
    public class MovementPresenter
    {
        private MovementModel _model;
        
        private MovementView _view;

        public MovementPresenter(MovementView view, MovementSettings settings)
        {
            _model = new(settings);

            _view = view;
        }

        public void IncreaseMoveSpeed(float amount)
        {
            float delimiter = 100f;
            _model.SetMoveSpeed(_model.MoveSpeed + _model.MoveSpeed * amount / delimiter);
        }

        public void Move(Vector3 direction)
        {
            _view.Move(
                direction,
                _model.MoveSpeed
            );
        }
    }
}