using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public interface IRemotePlayersStorageService
    {
        Dictionary<int, Transform> PlayersDictionary { get; }
    }
}