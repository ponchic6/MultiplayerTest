using System;

namespace Services
{
    public interface IFinishGameService
    {
        public event Action OnFinishGame;
    }
}