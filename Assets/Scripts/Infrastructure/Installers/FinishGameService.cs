using System;
using Services;
using UnityEngine;

namespace Infrastructure.Installers
{
    public class FinishGameService : MonoBehaviour, IFinishGameService
    {
        public event Action OnFinishGame;

        private void OnDestroy()
        {
            OnFinishGame?.Invoke();
        }
    }
}