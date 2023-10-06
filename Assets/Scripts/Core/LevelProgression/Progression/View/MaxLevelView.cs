using System;
using Core.LevelProgression.Progression.Model;
using TMPro;
using UnityEngine;

namespace Core.LevelProgression.Progression.View
{
    public class MaxLevelView : ProgressView
    {
        [SerializeField] private TextMeshProUGUI _waveCount;

        public override Type GetType()
        {
            return typeof(CurrentLevelInt);
        }

        public override void Show(ProgressInt value)
        {
            _waveCount.text = value.Value.ToString();
        }
    }
}