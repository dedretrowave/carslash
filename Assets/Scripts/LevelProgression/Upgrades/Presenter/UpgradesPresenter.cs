using System;
using System.Collections.Generic;
using LevelProgression.Upgrades.Components.Base;
using LevelProgression.Upgrades.Model;
using LevelProgression.Upgrades.View;

namespace LevelProgression.Upgrades.Presenter
{
    public class UpgradesPresenter
    {
        private UpgradesModel _model;

        private UpgradesView _view;

        public event Action<Upgrade> Selected; 

        public UpgradesPresenter(UpgradesView view)
        {
            _view = view;

            _model = new();
            
            _view.Selected += OnSelected;
        }
        
        ~UpgradesPresenter() 
        {
            _view.Selected -= OnSelected;
        }

        public void Show()
        {
            List<Upgrade> upgrades = _model.GetRandom();
            
            _view.Show(upgrades);
        }

        private void OnSelected(Upgrade upgrade)
        {
            _view.Remove();
            Selected?.Invoke(upgrade);
        }
    }
}