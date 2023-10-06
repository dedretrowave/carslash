using System;
using Core.LevelProgression.Progression.Model;
using UnityEngine;

namespace Core.LevelProgression.Progression.View
{
    public abstract class ProgressView : MonoBehaviour
    {
        public abstract Type GetType();

        public abstract void Show(ProgressInt value);
    }
}