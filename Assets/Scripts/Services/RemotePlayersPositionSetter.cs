using System;
using Network;
using UnityEngine;

namespace Services
{
    public class RemotePlayersPositionSetter : IRemotePlayersPositionSetter
    {
        private readonly IRemotePlayersStorageService _remotePlayersStorageService;
        private readonly IClientService _clientService;
        private readonly IPlayersFactory _playersFactory;

        private Vector3String _newPositionString;
        private QuaternionString _newRotationString;
        private Vector3 _newPosition;
        private Quaternion _newRotation;
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
                remotePlayerTransform.rotation = _newRotation;
            }

            else
            {
                _remotePlayersStorageService.PlayersDictionary[_id] = _playersFactory.CreateRemotePlayer();
            }
        }

        private void ParseMessage(string message)
        {
            try
            {   
                TransformProperties transformProperties = JsonUtility.FromJson<TransformProperties>(message);
                _newPositionString = transformProperties.Position;
                _newRotationString = transformProperties.Rotation;
                
                _newPosition = new Vector3(float.Parse(_newPositionString.x),
                    float.Parse(_newPositionString.y),
                    float.Parse(_newPositionString.z));
                _newRotation = new Quaternion(float.Parse(_newRotationString.x),
                    float.Parse(_newRotationString.y),
                    float.Parse(_newRotationString.z),
                    float.Parse(_newRotationString.w));
                
                _id = transformProperties.Id;
            }
            
            catch (Exception exception)
            {
                Debug.Log(message);
                throw;
            }
        }
    }
}