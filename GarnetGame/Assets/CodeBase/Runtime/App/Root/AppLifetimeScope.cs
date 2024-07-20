using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.InventorySystem.View;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.ShopSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Root
{
    public class AppLifetimeScope : LifetimeScope
    {
        [SerializeField] private InventoryViewController _inventoryViewController;
        [SerializeField] private AppEntryPoint _appEntryPoint;
        [SerializeField] private Shop _shop;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_inventoryViewController);
            builder.RegisterComponent(_appEntryPoint);
            builder.RegisterComponent(_shop);
        }
    }
}
