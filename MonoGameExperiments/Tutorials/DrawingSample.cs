using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameExperiments.Tutorials;

/// <summary>
/// Drawing experiments based on MonoGame tutorials.
/// </summary>
internal class DrawingSample : DrawableGameComponent
{
    readonly GraphicsDeviceManager _graphics;
    SpriteBatch _spriteBatch;

    Texture2D _background;
    Texture2D _shuttle;
    Texture2D _earth;

    Sprite _arrow;

    Rectangle _screenArea;
    Color _tintColor = Color.White;

    Vector2 _earthPosition;
    Vector2 _shuttlePosition;
    Vector2 _titleTextPosition = new(40, 40);
    Vector2 _timeTextPosition;
    Vector2 _scorePosition;
    Vector2 _arrowAngleTextPosition;

    readonly string _scoreTitle = "Score: ";
    SpriteFont _font;
    int _score = 0;

    AnimatedSprite _animatedSprite;

    public DrawingSample(Game game) : base(game)
    {
        _screenArea = GraphicsDevice.Viewport.Bounds;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // textures
        _background = Game.Content.Load<Texture2D>("Art/stars");
        _shuttle = Game.Content.Load<Texture2D>("Art/shuttle");
        _earth = Game.Content.Load<Texture2D>("Art/earth");

        // arrow sprite
        var texture = Game.Content.Load<Texture2D>("Art/arrow");
        _arrow = new(texture);

        _font = Game.Content.Load<SpriteFont>("Fonts/Score");
        _font.Spacing = 1;

        texture = Game.Content.Load<Texture2D>("Art/SmileyWalk");
        _animatedSprite = new AnimatedSprite(texture, 4, 4);

        SetSpritePositions();

        base.LoadContent();
    }

    void SetSpritePositions()
    {
        // calculate image positions
        int spacing = 30;
        _earthPosition = new Vector2(_screenArea.Width - _earth.Width * 2, _screenArea.Height - _earth.Height);
        _shuttlePosition = new Vector2(spacing * 2, _screenArea.Height - _shuttle.Height - spacing);

        // calculate text positions
        var textSize = _font.MeasureString(_scoreTitle);
        int textHeight = Convert.ToInt32(textSize.Y);
        spacing = 5;
        _timeTextPosition = GetNextLinePos(_titleTextPosition);
        _scorePosition = GetNextLinePos(_timeTextPosition);
        _arrowAngleTextPosition = GetNextLinePos(_scorePosition);

        // calculates positions for consecutive lines of text
        Vector2 GetNextLinePos(Vector2 currentLinePos) =>
            new(_titleTextPosition.X, currentLinePos.Y + textHeight + spacing);
    }

    public override void Update(GameTime gameTime)
    {
        ProcessKeyboard();

        // score update
        if (_score++ >= 1000)
            _score = 0;

        // moving character update
        _animatedSprite.Update();
        if (!_screenArea.Contains(_animatedSprite.DestRect))
        {
            _animatedSprite.RevertPosition();
            _animatedSprite.ChangeDirection();
        }

        // arrow update
        _arrow.Update();

        base.Update(gameTime);
    }

    void ProcessKeyboard()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
            _tintColor = Color.DarkGray;
        else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            _tintColor = Color.White;
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        // draw background
        _spriteBatch.Draw(_background, _screenArea, _tintColor);

        // draw earth bottom right corner of the screen
        var destRect = new Rectangle((int)_earthPosition.X, (int)_earthPosition.Y, _earth.Width * 2, _earth.Height);
        var sourceRect = new Rectangle(0, 0, _earth.Width / 2, _earth.Height / 2);
        _spriteBatch.Draw(_earth, destRect, sourceRect, Color.White);

        // flipped earth top right corner of the screen
        Vector2 pos = new(_screenArea.Width - _earth.Width / 2, 0);
        _spriteBatch.Draw(_earth, pos, sourceRect, Color.White, 0, Vector2.Zero, 1,
            SpriteEffects.FlipVertically, 0);

        // animation of a small guy running around the perimeter of the screen
        _animatedSprite.Draw(_spriteBatch);

        // center arrow turning roung
        _arrow.Draw(_spriteBatch);

        // shuttle bottom left corner of the screen
        _spriteBatch.Draw(_shuttle, _shuttlePosition, Color.White);

        // draw text
        _spriteBatch.DrawString(_font, _scoreTitle + _score, _scorePosition, Color.White);
        _spriteBatch.DrawString(_font, $"Title: {Game.Window.Title}", _titleTextPosition, Color.Yellow);
        _spriteBatch.DrawString(_font, $"Elapsed Time: {gameTime.TotalGameTime:ss}", _timeTextPosition, Color.Pink);
        _spriteBatch.DrawString(_font, $"Arrow Angle: {_arrow.Angle:F2}", _arrowAngleTextPosition, Color.LimeGreen);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}