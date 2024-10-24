using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameExperiments.SpriteSorting;

internal class SpriteSortingSample(Game game) : DrawableGameComponent(game)
{
    readonly Vector2 _margin = new(20, 20);
    SpriteFont _font;
    Sprite _arrow, _earth, _shuttle;

    public SpriteBatch SpriteBatch { get; private set; }
    public SpriteSortMode SortMode { get; private set; }

    public override void Initialize()
    {
        SortMode = SpriteSortMode.BackToFront;
        _arrow = new Sprite("arrow",     3, 0, this);
        _earth = new Sprite("earth",     1, 1, this);
        _shuttle = new Sprite("shuttle", 2, 0, this);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new(GraphicsDevice);
        _font = Game.Content.Load<SpriteFont>("Fonts/Arial");
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        SpriteBatch.Begin(SortMode);

        string text = $"SpriteSortMode: {SortMode}";
        var position = Vector2.Zero + _margin;
        SpriteBatch.DrawString(_font, text, position, Color.Black);

        var spacing = GetSpacing(text);
        DrawSpriteInfo(_earth, spacing, 0);
        DrawSpriteInfo(_shuttle, spacing, 1);
        DrawSpriteInfo(_arrow, spacing, 2);

        SpriteBatch.End();
    }

    void DrawSpriteInfo(Sprite sprite, Vector2 spacing, int lineNumber)
    {
        var position = GetSpritePosition(sprite.ToString(), spacing, lineNumber);
        SpriteBatch.DrawString(_font, sprite.ToString(), position, Color.Brown);
    }

    Vector2 GetSpritePosition(string text, Vector2 spacing, int lineNumber)
    {
        var size = _font.MeasureString(text);
        var x = GraphicsDevice.Viewport.TitleSafeArea.Width - size.X - _margin.X;
        return new Vector2(x, _margin.Y) + spacing * lineNumber;
    }

    Vector2 GetSpacing(string text)
    {
        var size = _font.MeasureString(text);
        return new Vector2(0, size.Y + 5);
    }

    public Vector2 GetCenteredPosition(Texture2D texture)
    {
        int x = (GraphicsDevice.Viewport.TitleSafeArea.Width - texture.Width) / 4;
        int y = (GraphicsDevice.Viewport.TitleSafeArea.Height - texture.Height) / 2;
        return new Vector2(x, y);
    }
}