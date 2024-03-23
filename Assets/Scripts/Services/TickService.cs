using System;
using UnityEngine;

namespace Services
{
    public class TickService : MonoBehaviour, ITickService
    {
        public event Action OnTick;
        public event Action OnFixedTick;

        private void Update() => OnTick?.Invoke();

        private void FixedUpdate() => OnFixedTick?.Invoke();
    }
}