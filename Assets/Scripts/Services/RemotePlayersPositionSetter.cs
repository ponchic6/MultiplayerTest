using UnityEngine;

namespace Services
{
    public class RemotePlayersPositionSetter : IRemotePlayersPositionSetter
    {
        private readonly IRemotePlayersStorageService _remotePlayersStorageService;
        private readonly IClientService _clientService;
        private readonly IPlayersFactory _playersFactory;

        private Vector3 _newPosition;
        private int _id;

        public RemotePlayersPositionSetter(IRemotePlayersStorageService remotePlayersStorageService,
            IClientService clientService, IPlayersFactory playersFactory)
        {
            _remotePlayersStorageService = remotePlayersStorageService;
            _playersFactory = playersFactory;
            
            _clientService = clientService;
            _clientService.OnRecievedMessage += UpdateRemotePlayersPositions;
        }

        private void UpdateRemotePlayersPositions(string message)
        {
            ParseMessage(message);

            if (_remotePlayersStorageService.PlayersDictionary.TryGetValue(_id, out Transform remotePlayerTransform))
            {
                remotePlayerTransform.position = _newPosition;
            }

            else
            {
                _remotePlayersStorageService.PlayersDictionary[_id] = _playersFactory.CreateRemotePlayer();
            }
        }

        private void ParseMessage(string message)
        {
            string[] _recievedMessage = message.Split(", ");
            _newPosition = new Vector3(float.Parse(_recievedMessage[0]),
                float.Parse(_recievedMessage[1]), float.Parse(_recievedMessage[2]));
            _id = int.Parse(_recievedMessage[3]);
        }
    }
}