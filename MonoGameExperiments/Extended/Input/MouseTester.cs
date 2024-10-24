using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;

namespace MonoGameExperiments.Extended.Input;

internal class MouseTester(Manager manager) : DrawableGameComponent(manager)
{
    protected Manager Manager => Game as Manager;
    Texture2D _arrow;
    Vector2 _arrowPosLeft;
    Vector2 _arrowPosRight;
    protected MouseButton MouseButton { get; set; }

    protected override void LoadContent()
    {
        _arrow = Game.Content.Load<Texture2D>("Art/arrow");
        int x = (GraphicsDevice.Viewport.TitleSafeArea.Width - _arrow.Width) / 4;
        int y = (GraphicsDevice.Viewport.TitleSafeArea.Height - _arrow.Height) / 2;
        _arrowPosLeft = new Vector2(x, y);
        _arrowPosRight = new Vector2(x * 3, y);
    }

    public override void Draw(GameTime gameTime)
    {
        var sb = Manager.SpriteBatch;
        GraphicsDevice.Clear(Color.CornflowerBlue);
        sb.Begin();

        // draw arrows
        if (MouseButton.HasFlag(MouseButton.Left))
            sb.Draw(_arrow, _arrowPosLeft, Color.White);
        if (MouseButton.HasFlag(MouseButton.Right))
            sb.Draw(_arrow, _arrowPosRight, Color.White);

        sb.End();
    }

    protected void Shoot(MouseButton button)
    {
        if (button.HasFlag(MouseButton.Left))
            _ = new Bullet(Manager, _arrow, _arrowPosLeft);
        if (button.HasFlag(MouseButton.Right))
            _ = new Bullet(Manager, _arrow, _arrowPosRight);
    }
}