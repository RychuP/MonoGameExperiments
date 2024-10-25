using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace MonoGameExperiments.Extended.Screen;

internal class ScreenManagementSample(Manager manager) : DrawableGameComponent(manager)
{
    ScreenManager _screenManager;
    SampleScreenOne _screen1;
    SampleScreenTwo _screen2;
    Manager Manager => Game as Manager;

    public override void Initialize()
    {
        Manager.InputManager.Keyboard.KeyPressed += KeyboardListener_OnKeyPressed;

        _screenManager = new ScreenManager();
        Game.Components.Add(_screenManager);

        _screen1 = new(Manager);
        _screen2 = new(Manager);
        LoadScreen1();

        base.Initialize();
    }

    private void LoadScreen1() => LoadScreen(_screen1);

    private void LoadScreen2() => LoadScreen(_screen2);

    void LoadScreen(SampleScreenBase screen) =>
        _screenManager.LoadScreen(screen, new FadeTransition(GraphicsDevice, Color.Black));

    void KeyboardListener_OnKeyPressed(object o, KeyboardEventArgs e)
    {
        switch (e.Key)
        {
            case Keys.D1:
                LoadScreen1();
                break;

            case Keys.D2:
                LoadScreen2();
                break;
        }
    }
}