using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace MonoGameExperiments.Extended;

internal class SpriteSample(Game game) : DrawableGameComponent(game)
{
    private SpriteBatch _spriteBatch;
    private Texture2DAtlas _atlas;
    private Sprite _aceOfClubsSprite;

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D cardsTexture = Game.Content.Load<Texture2D>("Art/cards");
        _atlas = Texture2DAtlas.Create("Atlas/Cards", cardsTexture, 32, 32);

        _aceOfClubsSprite = _atlas.CreateSprite(12);
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_aceOfClubsSprite, new Vector2(384, 284));
        _spriteBatch.End();
    }
}