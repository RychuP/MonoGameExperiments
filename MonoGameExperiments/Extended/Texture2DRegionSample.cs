using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace MonoGameExperiments.Extended;

internal class Texture2DRegionSample(Game game) : DrawableGameComponent(game)
{
    private SpriteBatch _spriteBatch;
    private Texture2DRegion _aceOfHearts;
    private Texture2DRegion _aceOfDiamonds;
    private Texture2DRegion _aceOfClubs;
    private Texture2DRegion _aceOfSpades;

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D cardsTexture = Game.Content.Load<Texture2D>("Art/cards");

        _aceOfHearts = new Texture2DRegion(cardsTexture, 384, 64, 32, 32);
        _aceOfDiamonds = new Texture2DRegion(cardsTexture, 384, 32, 32, 32);
        _aceOfClubs = new Texture2DRegion(cardsTexture, 384, 0, 32, 32);
        _aceOfSpades = new Texture2DRegion(cardsTexture, 384, 96, 32, 32);
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _spriteBatch.Draw(_aceOfHearts, new Vector2(336, 284), Color.White);
        _spriteBatch.Draw(_aceOfDiamonds, new Vector2(368, 284), Color.White);
        _spriteBatch.Draw(_aceOfClubs, new Vector2(400, 284), Color.White);
        _spriteBatch.Draw(_aceOfSpades, new Vector2(432, 284), Color.White);

        _spriteBatch.End();
    }
}