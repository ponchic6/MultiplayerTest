using Zenject;

namespace Factories
{
    public class UIFactory : IUIFactory
    {
        private const string MainUserInterfacePath = "UI/MainUserInterface";
        
        private readonly DiContainer _diContainer;

        public UIFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void CreateMainUserInterface()
        {
            _diContainer.InstantiatePrefabResource(MainUserInterfacePath);
        }
    }
}