using Microsoft.Xna.Framework.Graphics;

namespace MonoGameExperiments.Extended.Input;

class Bullet : DrawableGameComponent
{
    readonly Texture2D _texture;
    readonly TimeSpan _duration = TimeSpan.FromSeconds(2f);
    Manager Manager => Game as Manager;

    Vector2 _start;
    Vector2 _destination;
    Vector2 _position;
    Vector2 _delta;
    float _percent;

    public Bullet(Manager manager, Texture2D texture, Vector2 position) : base(manager)
    {
        _texture = texture;
        _start = position;
        _position = position;
        _destination = new Vector2(position.X, -texture.Height);
        _delta = _destination - _start;
        Game.Components.Add(this);
    }

    public override void Update(GameTime gameTime)
    {
        _percent += (float)(gameTime.ElapsedGameTime.TotalSeconds / _duration.TotalSeconds);
        _position = _start + _delta * _percent;
        if (_position.Y <= _destination.Y)
            Game.Components.Remove(this);
    }

    public override void Draw(GameTime gameTime)
    {
        var sb = Manager.SpriteBatch;
        sb.Begin();
        sb.Draw(_texture, _position, Color.White);
        sb.End();
    }
}