using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class RemotePlayersStorageService : IRemotePlayersStorageService
    {
        private Dictionary<int, Transform> _playersDictionary = new Dictionary<int, Transform>();
        public Dictionary<int, Transform> PlayersDictionary => _playersDictionary;
    }
}