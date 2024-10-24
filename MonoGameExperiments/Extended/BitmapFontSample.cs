using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace MonoGameExperiments.Extended;

internal class BitmapFontSample(Game game) : DrawableGameComponent(game)
{
    SpriteBatch _spriteBatch;
    BitmapFont _font;

    protected override void LoadContent()
    {
        _spriteBatch = new(GraphicsDevice);
        using var stream = TitleContainer.OpenStream("curlz.fnt");
        _font = BitmapFont.FromStream(GraphicsDevice, stream, "curlz");
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _spriteBatch.DrawString(_font, "Hello World", new Vector2(50, 50), Color.Black);
        _spriteBatch.End();
    }
}