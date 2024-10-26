using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace MonoGameExperiments.Extended.Graphics;

internal class SpriteSample2(Manager manager) : DrawableGameComponent(manager)
{
    private Texture2DAtlas _atlas;
    private Sprite _aceOfClubsSprite;
    private Sprite _aceOfDiamondsSprite;
    private Sprite _aceOfHeartsSprite;
    private Sprite _aceOfSpadesSprite;

    protected override void LoadContent()
    {
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

        manager.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        manager.SpriteBatch.Draw(_aceOfClubsSprite, new Vector2(336, 284));
        manager.SpriteBatch.Draw(_aceOfDiamondsSprite, new Vector2(368, 284));
        manager.SpriteBatch.Draw(_aceOfHeartsSprite, new Vector2(400, 284));
        manager.SpriteBatch.Draw(_aceOfSpadesSprite, new Vector2(432, 284));
        manager.SpriteBatch.End();
    }
}