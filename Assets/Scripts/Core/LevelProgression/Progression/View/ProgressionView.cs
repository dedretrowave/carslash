using System;
using Core.LevelProgression.Progression.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.LevelProgression.Progression.View
{
    public class ProgressionView : ProgressView
    {
        [SerializeField] private Slider _slider;

        public override Type GetType()
        {
            return typeof(ProgressionInt);
        }

        public override void Show(ProgressInt value)
        {
            _slider.value = value.Value;
        }
    }
}