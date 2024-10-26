using Microsoft.Xna.Framework.Graphics;

namespace MonoGameExperiments.SpriteSorting;

internal class SpriteSortingSample(Manager manager) : DrawableGameComponent(manager)
{
    readonly Vector2 _margin = new(20, 20);
    Sprite _arrow, _earth, _shuttle;

    public SpriteSortMode SortMode { get; private set; }

    public override void Initialize()
    {
        SortMode = SpriteSortMode.BackToFront;
        _ = new Sprite("arrow", 2, 0f, 0, this);
        _ = new Sprite("shuttle", 1, 0f, 0, this);

        _shuttle = new Sprite("shuttle", 4, 0.1f, 100, this);
        _earth = new Sprite("earth", 1, 0.1f, 50, this);
        _arrow = new Sprite("arrow", 3, 0.1f, 100, this);
        base.Initialize();
    }

    public override void Draw(GameTime gameTime)
    {
        string text = $"SpriteSortMode: {SortMode}";
        var position = Vector2.Zero + _margin;
        manager.SpriteBatch.DrawString(manager.Arial, text, position, Color.Black);

        var spacing = GetSpacing(text);
        DrawSpriteInfo(_earth, spacing, 0);
        DrawSpriteInfo(_shuttle, spacing, 1);
        DrawSpriteInfo(_arrow, spacing, 2);
    }

    void DrawSpriteInfo(Sprite sprite, Vector2 spacing, int lineNumber)
    {
        var position = GetSpritePosition(sprite.ToString(), spacing, lineNumber);
        manager.SpriteBatch.DrawString(manager.Arial, sprite.ToString(), position, Color.Brown);
    }

    Vector2 GetSpritePosition(string text, Vector2 spacing, int lineNumber)
    {
        var size = manager.Arial.MeasureString(text);
        var x = GraphicsDevice.Viewport.TitleSafeArea.Width - size.X - _margin.X;
        return new Vector2(x, _margin.Y) + spacing * lineNumber;
    }

    Vector2 GetSpacing(string text)
    {
        var size = manager.Arial.MeasureString(text);
        return new Vector2(0, size.Y + 5);
    }

    public Vector2 GetCenteredPosition(Texture2D texture)
    {
        int x = (GraphicsDevice.Viewport.TitleSafeArea.Width - texture.Width) / 4;
        int y = (GraphicsDevice.Viewport.TitleSafeArea.Height - texture.Height) / 2;
        return new Vector2(x, y);
    }
}