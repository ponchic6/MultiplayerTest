using System;
using UnityEngine;

namespace Services
{
    public interface IClientService
    {
        public event Action<string> OnRecievedMessage;
        public void SendPosition(Vector3 transformPosition);
        public void ConnectToServer();
    }
}