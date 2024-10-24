using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Input.InputListeners;
using System;

namespace MonoGameExperiments.Extended;

internal class AnimatedSpriteSample(Game game) : DrawableGameComponent(game)
{
    private SpriteBatch _spriteBatch;
    private AnimatedSprite _adventurer;
    private KeyboardListener _keyboardListener;

    public override void Initialize()
    {
        _keyboardListener = new KeyboardListener();
        _keyboardListener.KeyPressed += (sender, eventArgs) =>
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
        _spriteBatch = new(GraphicsDevice);

        Texture2D adventurerTexture = Game.Content.Load<Texture2D>("Art/adventurer");
        Texture2DAtlas atlas = Texture2DAtlas.Create("Atlas/adventurer", adventurerTexture, 50, 37);
        SpriteSheet spriteSheet = new("SpriteSheet/adventurer", atlas);

        spriteSheet.DefineAnimation("attack", builder =>
        {
            builder.IsLooping(false)
                   .AddFrame(regionIndex: 0, duration: TimeSpan.FromSeconds(0.1))
                   .AddFrame(1, TimeSpan.FromSeconds(0.1))
                   .AddFrame(2, TimeSpan.FromSeconds(0.1))
                   .AddFrame(3, TimeSpan.FromSeconds(0.1))
                   .AddFrame(4, TimeSpan.FromSeconds(0.1))
                   .AddFrame(5, TimeSpan.FromSeconds(0.1));
        });

        spriteSheet.DefineAnimation("idle", builder =>
        {
            builder.IsLooping(true)
                   .AddFrame(6, TimeSpan.FromSeconds(0.1))
                   .AddFrame(7, TimeSpan.FromSeconds(0.1))
                   .AddFrame(8, TimeSpan.FromSeconds(0.1))
                   .AddFrame(9, TimeSpan.FromSeconds(0.1));
        });

        spriteSheet.DefineAnimation("run", builder =>
        {
            builder.IsLooping(true)
                   .AddFrame(10, TimeSpan.FromSeconds(0.1))
                   .AddFrame(11, TimeSpan.FromSeconds(0.1))
                   .AddFrame(12, TimeSpan.FromSeconds(0.1))
                   .AddFrame(13, TimeSpan.FromSeconds(0.1))
                   .AddFrame(14, TimeSpan.FromSeconds(0.1))
                   .AddFrame(15, TimeSpan.FromSeconds(0.1));
        });

        _adventurer = new AnimatedSprite(spriteSheet, "idle");
    }

    public override void Update(GameTime gameTime)
    {
        _keyboardListener.Update(gameTime);
        _adventurer.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        int scale = 3;
        _spriteBatch.Draw(_adventurer, _adventurer.Origin * scale, 0, new Vector2(scale));
        _spriteBatch.End();
    }
}