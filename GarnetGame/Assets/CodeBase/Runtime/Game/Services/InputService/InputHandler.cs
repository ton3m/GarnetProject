namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Services.InputService
{
    public class InputHandler : IInputHandler
    {
        private InputMap _actions;
        public InputMap Actions => _actions ??= new InputMap();
    }
}
