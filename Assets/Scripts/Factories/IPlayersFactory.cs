using UnityEngine;

public interface IPlayersFactory
{
    public Transform LocalPlayerTransform { get; }
    public void CreateLocalPlayers();
    public Transform CreateRemotePlayer();
}