global using System;
global using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;
using MonoGameExperiments.Extended.Collisions;
using MonoGameExperiments.Extended.Entities.Rain;
using MonoGameExperiments.Extended.Graphics;
using MonoGameExperiments.Extended.Input;
using MonoGameExperiments.Extended.Screen;
using MonoGameExperiments.Extended.Tweening;
using MonoGameExperiments.GumUI;
using MonoGameExperiments.SpriteSorting;

namespace MonoGameExperiments;

public class Manager : Game
{
    public SpriteFont Arial { get; private set; }
    public BitmapFont Font { get; private set; }
    public SpriteBatch SpriteBatch { get; private set; }
    public InputManager InputManager { get; private set; }
    public Random Random { get; } = new();

    public Manager()
    {
        _ = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        //Window.AllowUserResizing = true;
        IsMouseVisible = true;
    }

    // uncomment one, hide everything else
    protected override void Initialize()
    {
        InputManager = new(this);
        InputManager.Keyboard.KeyPressed += (o, e) => { if (e.Key == Keys.Escape) Exit(); };

        // -- monogame experiments --
        //Test<DrawingSample>();
        //Test<SpriteSortingSample>();

        // -- monogame extended experiments --
        //Test<Texture2DRegionSample>();
        //Test<Texture2DRegionSample>();
        //Test<SpriteSample>();
        //Test<SpriteSample2>();
        //Test<SpritesheetSample>();
        //Test<AnimatedSpriteSample>();
        //Test<BitmapFontSample>();
        //Test<InputListenerSample>();
        //Test<MouseExtendedSample>();
        //Test<CameraSample>();
        //Test<ScreenManagementSample>();
        //Test<TweeningSample>();
        //Test<ColisionsSample>();
        //Test<RainSimulator>();
        Test<GumSample>();

        base.Initialize();
    }

    void Test<T>() where T : GameComponent
    {
        var component = Activator.CreateInstance(typeof(T), this) as GameComponent;
        Components.Add(component);
    }

    protected override void LoadContent()
    {
        SpriteBatch = new(GraphicsDevice);
        Font = BitmapFont.FromFile(GraphicsDevice, "Content/Fonts/curlz.fnt");
        Arial = Content.Load<SpriteFont>("Fonts/Arial");
    }

    static void Main()
    {
        using var game = new Manager();
        game.Run();
    }
}