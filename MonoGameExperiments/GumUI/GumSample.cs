using MonoGameGum.Forms.Controls;
using MonoGameGum.Forms;
using MonoGameGum.GueDeriving;
using RenderingLibrary;
using MonoGameExperiments.GumUI.Components;
using System.Text;
using MonoGameExperiments.GumUI.Screens;
using Microsoft.Xna.Framework.Input;
using Gum.Wireframe;

namespace MonoGameExperiments.GumUI;

internal class GumSample(Manager manager) : DrawableGameComponent(manager)
{
    MenuScreenRuntime MenuScreen;
    TestScreenRuntime TestScreen;
    ContainerRuntime _currentScreen;
    ButtonRuntime _button;

    public override void Initialize()
    {
        SystemManagers.Default = new SystemManagers(); 
        SystemManagers.Default.Initialize(Game.GraphicsDevice, fullInstantiation: true);
        FormsUtilities.InitializeDefaults();

        MenuScreen = new MenuScreenRuntime();
        TestScreen = new TestScreenRuntime();
        ChangeScreen(MenuScreen);

        var button = new Button
        {
            X = 30,
            Y = 30,
            Width = 100,
            Height = 50,
            Text = "Forms Button"
        };
        int clickCount = 0;
        button.Click += (o, e) =>
        {
            clickCount++;
            button.Text = $"Clicked {clickCount} times";
        };
        TestScreen.Children.Add(button.Visual);

        _button = new ButtonRuntime
        {
            X = 30,
            Y = 180,
            Text = "My Test Button"
        };
        TestScreen.Children.Add(_button);

        base.Initialize();
    }

    void ChangeScreen(ContainerRuntime screen)
    {
        if (_currentScreen == screen) return;
        _currentScreen?.RemoveFromManagers();
        screen.AddToManagers();
        _currentScreen = screen;
    }

    public override void Update(GameTime gameTime)
    {
        if (FormsUtilities.Keyboard.KeyPushed(Keys.D1))
            ChangeScreen(MenuScreen);
        else if (FormsUtilities.Keyboard.KeyPushed(Keys.D2))
            ChangeScreen(TestScreen);

        FormsUtilities.Update(gameTime, _currentScreen);
        SystemManagers.Default.Activity(gameTime.TotalGameTime.TotalSeconds);
    }

    public override void Draw(GameTime gameTime)
    {
        SystemManagers.Default.Draw();

        if (_currentScreen is MenuScreenRuntime)
        {
            manager.SpriteBatch.Begin();
            string text = $"Main Title RollOnCount: {MenuScreen.RollOnCount}";
            var size = manager.Arial.MeasureString(text);
            float x = (GraphicalUiElement.CanvasWidth - size.X) / 2;
            Vector2 pos = new(x, 300);
            manager.SpriteBatch.DrawString(manager.Arial, text, pos, Color.White);
            manager.SpriteBatch.End();
        }

        else if (_currentScreen is TestScreenRuntime)
        {
            manager.SpriteBatch.Begin();
            var text = new StringBuilder();
            text.AppendLine(_button.ButtonElevationState.ToString());
            text.AppendLine(_button.ButtonBrightnessState.ToString());
            manager.SpriteBatch.DrawString(manager.Arial, text,
                new Vector2(30, 100), Color.White);
            manager.SpriteBatch.End();
        }
    }
}   