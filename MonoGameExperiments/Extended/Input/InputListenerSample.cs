﻿using MonoGame.Extended.BitmapFonts;
using MonoGame.Extended.Input.InputListeners;

namespace MonoGameExperiments.Extended.Input;

internal class InputListenerSample(Manager manager) : MouseTester(manager)
{
    string _text = string.Empty;

    public override void Initialize()
    {
        var im = Manager.InputManager;
        im.Keyboard.KeyPressed += Keyboard_OnKeyPressed;
        im.Mouse.MouseClicked += Mouse_OnMouseClicked;
        im.Mouse.MouseDown += Mouse_OnMouseDown;
        im.Mouse.MouseUp += Mouse_OnMouseUp;

        base.Initialize();
    }

    public override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        var size = GraphicsDevice.Viewport.TitleSafeArea.Size;
        var sb = Manager.SpriteBatch;
        sb.Begin();
        sb.DrawString(Manager.Font, $"Pressed: {_text}", new Vector2(30), Color.Maroon);
        sb.End();
    }

    void Keyboard_OnKeyPressed(object o, KeyboardEventArgs e)
    {
        _text = $"Key {e.Key} Pressed";
    }

    void Mouse_OnMouseClicked(object o, MouseEventArgs e)
    {
        _text = $"Mouse {e.Button} Clicked";
        Shoot(e.Button);
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