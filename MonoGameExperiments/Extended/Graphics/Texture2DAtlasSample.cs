using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace MonoGameExperiments.Extended.Graphics;

internal class Texture2DAtlasSample(Manager manager) : DrawableGameComponent(manager)
{
    private Texture2DAtlas _atlas;
    private Texture2DRegion _aceOfClubs;
    private Texture2DRegion _aceOfDiamonds;
    private Texture2DRegion _aceOfHearts;
    private Texture2DRegion _aceOfSpades;

    protected override void LoadContent()
    {
        Texture2D cardsTexture = Game.Content.Load<Texture2D>("Art/cards");
        _atlas = Texture2DAtlas.Create("Atlas/Cards", cardsTexture, 32, 32);

        _aceOfClubs = _atlas[12];
        _aceOfDiamonds = _atlas[25];
        _aceOfHearts = _atlas[38];
        _aceOfSpades = _atlas[51];
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        manager.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        manager.SpriteBatch.Draw(_aceOfClubs, new Vector2(336, 284), Color.White);
        manager.SpriteBatch.Draw(_aceOfDiamonds, new Vector2(368, 284), Color.White);
        manager.SpriteBatch.Draw(_aceOfHearts, new Vector2(400, 284), Color.White);
        manager.SpriteBatch.Draw(_aceOfSpades, new Vector2(432, 284), Color.White);

        manager.SpriteBatch.End();

        base.Draw(gameTime);
    }
}