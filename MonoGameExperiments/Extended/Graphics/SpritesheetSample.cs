using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Graphics;

namespace MonoGameExperiments.Extended.Graphics;

internal class SpritesheetSample(Manager manager) : DrawableGameComponent(manager)
{
    private SpriteSheet _spriteSheet;
    private AnimationController _attackAnimationController;

    protected override void LoadContent()
    {
        Texture2D adventurerTexture = Game.Content.Load<Texture2D>("Art/adventurer");
        Texture2DAtlas atlas = Texture2DAtlas.Create("Atlas/adventurer", adventurerTexture, 50, 37);
        _spriteSheet = new SpriteSheet("SpriteSheet/adventurer", atlas);

        _spriteSheet.DefineAnimation("attack", builder =>
        {
            builder.IsLooping(true)
                    .AddFrame(regionIndex: 0, duration: TimeSpan.FromSeconds(0.1))
                    .AddFrame(1, TimeSpan.FromSeconds(0.1))
                    .AddFrame(2, TimeSpan.FromSeconds(0.1))
                    .AddFrame(3, TimeSpan.FromSeconds(0.1))
                    .AddFrame(4, TimeSpan.FromSeconds(0.1))
                    .AddFrame(5, TimeSpan.FromSeconds(0.1));
        });

        SpriteSheetAnimation attackAnimation = _spriteSheet.GetAnimation("attack");
        _attackAnimationController = new AnimationController(attackAnimation)
        {
            Speed = 0.8d
        };
    }

    public override void Update(GameTime gameTime)
    {
        _attackAnimationController.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        Texture2DRegion currentFrameTexture =
            _spriteSheet.TextureAtlas[_attackAnimationController.CurrentFrame];

        manager.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        manager.SpriteBatch.Draw(currentFrameTexture, Vector2.Zero, Color.White,
            0.0f, Vector2.Zero, new Vector2(3), SpriteEffects.None, 0.0f);
        manager.SpriteBatch.End();
    }
}