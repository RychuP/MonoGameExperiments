using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Graphics;

namespace MonoGameExperiments.Extended.Graphics;

internal class AnimatedSpriteSample(Manager manager) : DrawableGameComponent(manager)
{
    private AnimatedSprite _adventurer;

    public override void Initialize()
    {
        manager.InputManager.Keyboard.KeyPressed += (sender, eventArgs) =>
        {
            if (eventArgs.Key == Keys.Enter && _adventurer.CurrentAnimation == "idle")
            {
                _adventurer.SetAnimation("attack").OnAnimationEvent += (sender, trigger) =>
                {
                    if (trigger == AnimationEventTrigger.AnimationCompleted)
                    {
                        _adventurer.SetAnimation("idle");
                    }
                };
            }
        };
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Texture2D adventurerTexture = Game.Content.Load<Texture2D>("Art/adventurer");
        Texture2DAtlas atlas = Texture2DAtlas.Create("Atlas/adventurer", adventurerTexture, 50, 37);

        SpriteSheet spriteSheet = new("SpriteSheet/adventurer", atlas);
        spriteSheet.DefineAnimation("attack", builder => BuildAnimation(builder, false, 0, 5));
        spriteSheet.DefineAnimation("idle", builder => BuildAnimation(builder, true, 6, 9));
        spriteSheet.DefineAnimation("run", builder => BuildAnimation(builder, true, 10, 15));

        _adventurer = new AnimatedSprite(spriteSheet, "idle");
    }

    static void BuildAnimation(SpriteSheetAnimationBuilder builder, bool loop, 
        int startFrame, int endFrame)
    {
        builder.IsLooping(loop);
        for (int i = startFrame; i <= endFrame; i++)
            builder.AddFrame(i, TimeSpan.FromSeconds(0.1));
    }

    public override void Update(GameTime gameTime)
    {
        _adventurer.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        manager.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        int scale = 3;
        manager.SpriteBatch.Draw(_adventurer, _adventurer.Origin * scale, 0, new Vector2(scale));
        manager.SpriteBatch.End();
    }
}