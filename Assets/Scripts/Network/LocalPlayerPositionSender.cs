using System;
using Services;
using UnityEngine;
using Zenject;

namespace Network
{
    public class LocalPlayerPositionSender : MonoBehaviour
    {
        private IClientService _clientService;
    
        [Inject]
        public void Constructor(IClientService clientService)
        {
            _clientService = clientService;
        }

        private void FixedUpdate()
        {
            _clientService.SendPosition(transform.position);
        }
    }
}
