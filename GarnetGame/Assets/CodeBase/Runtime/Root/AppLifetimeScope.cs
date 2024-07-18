using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.InputService;
using VContainer;
using VContainer.Unity;

namespace GarnnetProject
{
    public class AppLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            DontDestroyOnLoad(this);

            var input = new InputHandler();
            input.Actions.Enable();

            builder.RegisterInstance(input).AsImplementedInterfaces().AsSelf();
        }
    }
}
