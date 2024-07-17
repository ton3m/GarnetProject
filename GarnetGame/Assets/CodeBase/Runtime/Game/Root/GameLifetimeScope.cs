using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.InventorySystem;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.InventorySystem.View;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.InputService;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private InventoryViewController _inventoryViewController;
        [SerializeField] private Shop _shop;
        [SerializeField] private ClickBehaviour _click;
        [SerializeField] private TestInput _testInput;

        protected override void Configure(IContainerBuilder builder)
        {
            var input = new InputHandler();
            input.Actions.Enable();
            builder.RegisterInstance(input).AsImplementedInterfaces().AsSelf();

            builder.Register<Inventory>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.RegisterComponent(_inventoryViewController);
            builder.RegisterComponent(_shop);
            builder.RegisterComponent(_testInput);
            builder.RegisterComponent(_click);
        }
    }
}
