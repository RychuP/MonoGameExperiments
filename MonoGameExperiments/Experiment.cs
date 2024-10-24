using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameExperiments.Extended;

namespace MonoGameExperiments;

public class Experiment : Game
{
    public Experiment()
    {
        _ = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.AllowUserResizing = true;
        Window.Title = "Test";
    }

    // uncomment one, hide everything else
    protected override void Initialize()
    {
        // monogame experiments
        //Components.Add(new DrawingSample(this));
        //Components.Add(new SpriteSortingSample(this));

        // extended experiments
        //Components.Add(new Texture2DRegionSample(this));
        //Components.Add(new Texture2DRegionSample(this));
        //Components.Add(new SpriteSample(this));
        //Components.Add(new SpriteSample2(this));
        //Components.Add(new SpritesheetSample(this));
        Components.Add(new AnimatedSpriteSample(this));
        //Components.Add(new BitmapFontSample(this));

        base.Initialize();
    }

    static void Main()
    {
        using var game = new Experiment();
        game.Run();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
            || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }
}