using GarnnetProject.Assets.CodeBase.Runtime.App.Core.InventorySystem;
using GarnnetProject.Assets.CodeBase.Runtime.App.Core.InventorySystem.Setup;
using GarnnetProject.Assets.CodeBase.Runtime.App.Core.PlayerConfigration;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.InputService;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.SceneLoad;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GarnnetProject.Assets.CodeBase.Runtime.Root
{
    public class GlobalLifetimeScope : LifetimeScope
    {
        [SerializeField] private PlayerDefaultConfig _playerDefaultConfig;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Inventory>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            var input = new InputHandler();
            input.Actions.Enable();
            builder.RegisterInstance(input).AsImplementedInterfaces().AsSelf();

            var uiRoot = Object.Instantiate(Resources.Load<UIRootView>("UIRoot"));
            builder.RegisterInstance(uiRoot).AsSelf();
            DontDestroyOnLoad(uiRoot.gameObject);

            InventorySetup inventorySetup = FindFirstObjectByType<InventorySetup>();
            builder.RegisterComponent(inventorySetup);

            PlayerConfigState playerConfig = _playerDefaultConfig.State; // change to values from DataProvider (save system)
            builder.RegisterInstance(playerConfig);
            
            DontDestroyOnLoad(this);
        }
    }
}
