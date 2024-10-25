using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Tweening;

namespace MonoGameExperiments.Extended.Tweening;

internal class TweeningSample(Manager manager) : DrawableGameComponent(manager)
{
    private readonly Tweener _tweener = new();
    private readonly Player _player = new() { Position = new Vector2(150, 100) };
    Manager Manager => Game as Manager;

    public override void Initialize()
    {
        base.Initialize();

        _tweener.TweenTo(target: _player, expression: player =>
            _player.Position, toValue: new Vector2(550, 350), duration: 1.5f, delay: 1)
                .RepeatForever(repeatDelay: 0.2f)
                .AutoReverse()
                .Easing(EasingFunctions.ElasticInOut);
    }

    public override void Update(GameTime gameTime)
    {
        _tweener.Update(gameTime.GetElapsedSeconds());
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        var sb = Manager.SpriteBatch;
        sb.Begin(samplerState: SamplerState.PointClamp);
        sb.FillRectangle(_player.Position.X, _player.Position.Y, 20, 20, Color.Red);
        sb.End();
    }
}