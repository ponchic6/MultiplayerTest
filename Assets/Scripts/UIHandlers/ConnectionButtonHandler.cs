using Services;
using UnityEngine;
using Zenject;

namespace UIHandlers
{
    public class ConnectionButtonHandler : MonoBehaviour
    {
        private IPlayersFactory _playersFactory;
        private IClientService _clientService;

        [Inject]
        public void Constructor(IPlayersFactory playersFactory, IClientService clientService)
        {
            _clientService = clientService;
            _playersFactory = playersFactory;
        }
        
        public void ConnectToServer()
        {
            _clientService.ConnectToServer();
            _playersFactory.CreateLocalPlayers();
        }
    }
}