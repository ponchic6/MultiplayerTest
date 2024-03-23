using Factories;
using Services;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterTickService();
            RegisterFinishGameService();
            RegisterRemotePlayersStorageService();
            RegisterPlayersFactory();
            RegisterClientService();
            RegisterRemotePositionSetter();
            RegisterUIFactory();
        }

        private void RegisterFinishGameService()
        {
            GameObject finishGameServiceGO = new GameObject("FinishGameService");
            IFinishGameService finishGameService = finishGameServiceGO.AddComponent<FinishGameService>();
            Container.Bind<IFinishGameService>().FromInstance(finishGameService).AsSingle();
        }

        private void RegisterRemotePositionSetter()
        {
            IRemotePlayersPositionSetter remotePlayersPositionSetter =
                Container.Instantiate<RemotePlayersPositionSetter>();
            Container.Bind<IRemotePlayersPositionSetter>().FromInstance(remotePlayersPositionSetter).AsSingle();
        }

        private void RegisterRemotePlayersStorageService()
        {
            IRemotePlayersStorageService remotePlayersStorageService = Container.Instantiate<RemotePlayersStorageService>();
            Container.Bind<IRemotePlayersStorageService>().FromInstance(remotePlayersStorageService).AsSingle();
        }

        private void RegisterClientService()
        {
            IClientService clientService = Container.Instantiate<ClientService>();
            Container.Bind<IClientService>().FromInstance(clientService).AsSingle();
        }

        private void RegisterPlayersFactory()
        {
            IPlayersFactory playersFactory = Container.Instantiate<PlayersFactory>();
            Container.Bind<IPlayersFactory>().FromInstance(playersFactory).AsSingle();
        }

        private void RegisterTickService()
        {
            GameObject tickObject = new GameObject("TickService");
            DontDestroyOnLoad(tickObject);
            ITickService tickService = tickObject.AddComponent<TickService>();
            Container.Bind<ITickService>().FromInstance(tickService).AsSingle();
        }

        private void RegisterUIFactory()
        {
            IUIFactory uiFactory = Container.Instantiate<UIFactory>();
            Container.Bind<IUIFactory>().FromInstance(uiFactory).AsSingle();
        }
    }
}