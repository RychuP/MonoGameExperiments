using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameExperiments.Tutorials;

internal class AnimatedSprite
{
    const int MovementSpeed = 4;

    readonly int _totalFrames;
    readonly int _frameWidth;
    readonly int _frameHeight;
    int _currentFrame;

    readonly Vector2[] _directions =
    {
        new(MovementSpeed, 0),
        new(0, MovementSpeed),
        new(-MovementSpeed, 0),
        new(0, -MovementSpeed),
    };

    public AnimatedSprite(Texture2D texture, int rows, int columns)
    {
        _currentFrame = 0;
        _totalFrames = rows * columns;
        _frameWidth = texture.Width / columns;
        _frameHeight = texture.Height / rows;
        (Texture, Rows, Columns) = (texture, rows, columns);
        Direction = _directions[0];
    }

    public Texture2D Texture { get; init; }
    public int Rows { get; init; }
    public int Columns { get; init; }
    public Vector2 Position { get; private set; } = Vector2.Zero;
    public Vector2 Direction { get; private set; }
    public Rectangle SrcRect { get; private set; }
    public Rectangle DestRect { get; private set; }

    public void ChangeDirection()
    {
        int i = Array.IndexOf(_directions, Direction) + 1;
        if (i >= _directions.Length)
            i = 0;
        Direction = _directions[i];
    }

    public void Update()
    {
        if (++_currentFrame >= _totalFrames)
            _currentFrame = 0;
        Position += Direction;

        int row = _currentFrame / Columns;
        int column = _currentFrame % Columns;

        SrcRect = new(_frameWidth * column, _frameHeight * row, _frameWidth, _frameHeight);
        DestRect = new((int)Position.X, (int)Position.Y, _frameWidth, _frameHeight);
    }

    public void RevertPosition()
    {
        Position -= Direction;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, DestRect, SrcRect, Color.White);
    }
}