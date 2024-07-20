using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.InventorySystem;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.InputService;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.SceneLoad;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GarnnetProject.Assets.CodeBase.Runtime.Root
{
    public class GlobalLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var input = new InputHandler();
            input.Actions.Enable();
            builder.RegisterInstance(input).AsImplementedInterfaces().AsSelf();

            var uiRootPrefab = Resources.Load<UIRootView>("UIRoot");
            var uiRoot = Object.Instantiate(uiRootPrefab);
            builder.RegisterInstance(uiRoot).AsSelf();
            DontDestroyOnLoad(uiRoot.gameObject);

            builder.Register<Inventory>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            
            DontDestroyOnLoad(this);
        }
    }
}
