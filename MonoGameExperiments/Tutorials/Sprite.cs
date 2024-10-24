using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGameExperiments.Tutorials;

internal class Sprite
{
    readonly Texture2D _texture;
    readonly Rectangle _sourceRect;

    public Sprite(Texture2D texture)
    {
        _texture = texture;
        _sourceRect = new(0, 0, texture.Width, texture.Height);
        Origin = new Vector2(_texture.Width / 2, _texture.Height);
    }

    public Vector2 Position { get; set; } = new Vector2(400, 240);
    public Vector2 Origin { get; set; }
    public float Angle { get; set; }

    public void Update()
    {
        Angle += 0.01f;
        if (Angle > Math.PI * 2)
            Angle = 0;
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(_texture, Position, _sourceRect, Color.White, Angle, Origin, 1f, SpriteEffects.None, 1);
    }
}