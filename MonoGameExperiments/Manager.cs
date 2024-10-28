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
        //Components.Add(new DrawingSample(this));
        //Components.Add(new SpriteSortingSample(this));

        // -- monogame extended experiments --
        //Components.Add(new Texture2DRegionSample(this));
        //Components.Add(new Texture2DRegionSample(this));
        //Components.Add(new SpriteSample(this));
        //Components.Add(new SpriteSample2(this));
        //Components.Add(new SpritesheetSample(this));
        //Components.Add(new AnimatedSpriteSample(this));
        //Components.Add(new BitmapFontSample(this));
        //Components.Add(new InputListenerSample(this));
        //Components.Add(new MouseExtendedSample(this));
        //Components.Add(new CameraSample(this));
        //Components.Add(new ScreenManagementSample(this));
        //Components.Add(new TweeningSample(this));
        //Components.Add(new ColisionsSample(this));
        Components.Add(new RainSimulator(this));

        base.Initialize();
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