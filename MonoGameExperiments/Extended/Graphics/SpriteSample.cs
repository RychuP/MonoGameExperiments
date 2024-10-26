using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace MonoGameExperiments.Extended.Graphics;

internal class SpriteSample(Manager manager) : DrawableGameComponent(manager)
{
    private Texture2DAtlas _atlas;
    private Sprite _aceOfClubsSprite;

    protected override void LoadContent()
    {
        Texture2D cardsTexture = Game.Content.Load<Texture2D>("Art/cards");
        _atlas = Texture2DAtlas.Create("Atlas/Cards", cardsTexture, 32, 32);
        _aceOfClubsSprite = _atlas.CreateSprite(12);
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        manager.SpriteBatch.Begin();
        manager.SpriteBatch.Draw(_aceOfClubsSprite, new Vector2(384, 284));
        manager.SpriteBatch.End();
    }
}