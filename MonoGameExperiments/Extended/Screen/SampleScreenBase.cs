using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;
using MonoGame.Extended;
using MonoGame.Extended.Screens;

namespace MonoGameExperiments.Extended.Screen;

internal class SampleScreenBase : GameScreen
{
    Manager Manager => Game as Manager;
    Vector2 _position = new(50, 50);
    readonly string _textureName;
    readonly string _name;
    readonly Color _bgColor;
    Texture2D _logo;

    public SampleScreenBase(Manager manager, string textureName, string name, Color color) 
        : base(manager)
    {
        _textureName = textureName;
        _bgColor = color;
        _name = name;
    }

    public override void LoadContent()
    {
        base.LoadContent();
        _logo = Game.Content.Load<Texture2D>($"Art/{_textureName}");
    }

    public override void Update(GameTime gameTime)
    {
        _position = Vector2.Lerp(_position, Mouse.GetState().Position.ToVector2(), 
            1f * gameTime.GetElapsedSeconds());
    }

    public override void Draw(GameTime gameTime)
    {
        Game.GraphicsDevice.Clear(_bgColor);
        var sb = Manager.SpriteBatch;

        sb.Begin();
        sb.DrawString(Manager.Font, _name, new Vector2(10, 10), Color.White);
        sb.Draw(_logo, _position, Color.White);
        sb.End();
    }
}

internal class SampleScreenOne(Manager manager) :
    SampleScreenBase(manager, "earth", "Screen One", new Color(16, 139, 204))
{ }

internal class SampleScreenTwo(Manager manager) :
    SampleScreenBase(manager, "shuttle", "Screen Two", Color.CornflowerBlue)
{ }