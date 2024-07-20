using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.PopUp;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.AssetsProvide;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.InputService;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameplayEntryPoint _gameplayeEntryPoint;
        [SerializeField] private ClickBehaviour _click;
        [SerializeField] private TestInput _testInput;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<AssetProvider>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf(); // перенести в AppLifetimeScope);
            builder.Register<DamagePopUpController>(Lifetime.Singleton).AsSelf();

            // registration for injection
            builder.RegisterComponent(_testInput);
            builder.RegisterComponent(_gameplayeEntryPoint);
            builder.RegisterComponent(_click);
        }
    }
}
