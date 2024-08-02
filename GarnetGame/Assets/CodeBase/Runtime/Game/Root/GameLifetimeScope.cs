using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.CaveRunner;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.Player;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.PopUp;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.AssetsProvide;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.GlobalConfigs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameplayEntryPoint _gameplayeEntryPoint;
        [SerializeField] private ClickBehaviour _click;
        [SerializeField] private GlobalCaveSettings _globalCaveSettings;
        [SerializeField] private CaveBootstrap _caveRunner;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<AssetProvider>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf(); // перенести в AppLifetimeScope);
            builder.Register<DamagePopUpController>(Lifetime.Singleton).AsSelf();
            builder.RegisterInstance(_globalCaveSettings).AsSelf();

            // registration for injection
            builder.RegisterComponent(_caveRunner);
            builder.RegisterComponent(_gameplayeEntryPoint);
            builder.RegisterComponent(_click);
        }
    }
}
