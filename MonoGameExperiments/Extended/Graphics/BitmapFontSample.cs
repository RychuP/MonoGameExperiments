using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace MonoGameExperiments.Extended.Graphics;

internal class BitmapFontSample(Manager manager) : DrawableGameComponent(manager)
{
    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        manager.SpriteBatch.Begin();
        manager.SpriteBatch.DrawString(manager.Font, "Hello World", new Vector2(50, 50), Color.Black);
        manager.SpriteBatch.End();
    }
}