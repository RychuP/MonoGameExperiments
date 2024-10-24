using MonoGame.Extended.Input;
using MonoGame.Extended.Input.InputListeners;

namespace MonoGameExperiments.Extended.Input;

internal class MouseExtendedSample(Manager manager) : MouseTester(manager)
{
    public override void Initialize()
    {
        base.Initialize();

        var im = Manager.InputManager;
        im.Mouse.MouseDown += Mouse_OnMouseDown;
        im.Mouse.MouseUp += Mouse_OnMouseUp;
    }

    public override void Update(GameTime gameTime)
    {
        MouseExtended.Update();
        MouseStateExtended mouseState = MouseExtended.GetState();

        if (mouseState.WasButtonReleased(MouseButton.Left))
            Shoot(MouseButton.Left);

        if (mouseState.WasButtonReleased(MouseButton.Right))
            Shoot(MouseButton.Right);
    }

    void Mouse_OnMouseDown(object o, MouseEventArgs e)
    {
        MouseButton |= e.Button;
    }

    void Mouse_OnMouseUp(object o, MouseEventArgs e)
    {
        MouseButton &= ~e.Button;
    }
}