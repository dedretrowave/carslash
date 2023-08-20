using Player.Movement.Model;
using Player.Movement.View;
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

        public void Move(Vector3 direction)
        {
            _view.Move(
                direction,
                _model.MoveSpeed
            );
        }
    }
}