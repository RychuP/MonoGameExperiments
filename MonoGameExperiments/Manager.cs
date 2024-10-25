global using System;
global using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;
using MonoGameExperiments.Extended.Collisions;
using MonoGameExperiments.Extended.Input;
using MonoGameExperiments.Extended.Tweening;

namespace MonoGameExperiments;

public class Manager : Game
{
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
        Components.Add(new ColisionsSample(this));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new(GraphicsDevice);
        using var stream = TitleContainer.OpenStream("curlz.fnt");
        Font = BitmapFont.FromStream(GraphicsDevice, stream, "curlz");
    }

    static void Main()
    {
        using var game = new Manager();
        game.Run();
    }
}