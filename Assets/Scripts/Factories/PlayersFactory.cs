using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayersFactory : IPlayersFactory 
{
    private const string LocalPlayerPath = "Player";
    private const string RemotePlayerPath = "RemotePlayer";
    
    private readonly DiContainer _diContainer;

    private Transform _localPlayer;

    public Transform LocalPlayerTransform => _localPlayer;

    public PlayersFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public void CreateLocalPlayers()
    {
        _localPlayer = _diContainer.InstantiatePrefabResource(LocalPlayerPath).transform;
    }

    public Transform CreateRemotePlayer()
    {
        return _diContainer.InstantiatePrefabResource(RemotePlayerPath).transform;
    }
}