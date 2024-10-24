using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace MonoGameExperiments.Extended.Graphics;

internal class SpriteSample2(Game game) : DrawableGameComponent(game)
{
    private SpriteBatch _spriteBatch;

    private Texture2DAtlas _atlas;
    private Sprite _aceOfClubsSprite;
    private Sprite _aceOfDiamondsSprite;
    private Sprite _aceOfHeartsSprite;
    private Sprite _aceOfSpadesSprite;

    protected override void LoadContent()
    {
        _spriteBatch = new(GraphicsDevice);

        Texture2D cardsTexture = Game.Content.Load<Texture2D>("Art/cards");
        _atlas = Texture2DAtlas.Create("Atlas/Cards", cardsTexture, 32, 32);

        _aceOfClubsSprite = _atlas.CreateSprite(regionIndex: 12);
        _aceOfDiamondsSprite = _atlas.CreateSprite(regionIndex: 25);
        _aceOfHeartsSprite = _atlas.CreateSprite(regionIndex: 38);
        _aceOfSpadesSprite = _atlas.CreateSprite(regionIndex: 51);

        // Change the color mask of the heart and diamond to red
        _aceOfHeartsSprite.Color = Color.Red;
        _aceOfDiamondsSprite.Color = Color.Red;

        // Change the Alpha transparency of the club and spade to half
        _aceOfClubsSprite.Alpha = 0.5f;
        _aceOfSpadesSprite.Alpha = 0.5f;
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_aceOfClubsSprite, new Vector2(336, 284));
        _spriteBatch.Draw(_aceOfDiamondsSprite, new Vector2(368, 284));
        _spriteBatch.Draw(_aceOfHeartsSprite, new Vector2(400, 284));
        _spriteBatch.Draw(_aceOfSpadesSprite, new Vector2(432, 284));
        _spriteBatch.End();
    }
}