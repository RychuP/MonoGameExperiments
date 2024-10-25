using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended.BitmapFonts;

namespace MonoGameExperiments.Extended.Screen;

internal class CameraSample(Manager manager) : DrawableGameComponent(manager)
{
    const float MovementSpeed = 200;
    private OrthographicCamera _camera;
    private Manager Manager => Game as Manager;
    private Vector2 _screenPosition;
    private Vector2 _worldPosition;

    public override void Initialize()
    {
        base.Initialize();

        var viewportAdapter = new BoxingViewportAdapter(Game.Window, GraphicsDevice, 800, 480);
        _camera = new OrthographicCamera(viewportAdapter);
    }

    public override void Update(GameTime gameTime)
    {
        _camera.Move(GetMovementDirection() * MovementSpeed * gameTime.GetElapsedSeconds());
        AdjustZoom();
        RotateCamera();
        UpdatePositions();
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        var sb = Manager.SpriteBatch;
        var transformMatrix = _camera.GetViewMatrix();
        
        sb.Begin(transformMatrix: transformMatrix);
        sb.DrawRectangle(new RectangleF(250, 250, 50, 50), Color.Black, 1f);
        sb.End();

        sb.Begin();
        sb.DrawString(Manager.Font, $"Screen Position: {_screenPosition.X}, {_screenPosition.Y}", 
            new Vector2(30), Color.Maroon);
        sb.DrawString(Manager.Font, $"World Position: {(int)_worldPosition.X}, {(int)_worldPosition.Y}",
            new Vector2(30, 90), Color.Black);
        sb.End();
    }

    private void UpdatePositions()
    {
        var mouseState = Mouse.GetState();
        _screenPosition = mouseState.Position.ToVector2();
        _worldPosition = _camera.ScreenToWorld(_screenPosition);
    }

    private void AdjustZoom()
    {
        var state = Keyboard.GetState();
        float zoomPerTick = 0.01f;
        if (state.IsKeyDown(Keys.Z))
        {
            _camera.ZoomIn(zoomPerTick);
        }
        if (state.IsKeyDown(Keys.X))
        {
            _camera.ZoomOut(zoomPerTick);
        }
    }

    private void RotateCamera()
    {
        var state = Keyboard.GetState();
        float rotateRadiansPerTick = 0.01f;
        if (state.IsKeyDown(Keys.A))
        {
            _camera.Rotate(rotateRadiansPerTick);
        }
        if (state.IsKeyDown(Keys.S))
        {
            _camera.Rotate(-rotateRadiansPerTick);
        }
    }

    private Vector2 GetMovementDirection()
    {
        var movementDirection = Vector2.Zero;
        var state = Keyboard.GetState();
        if (state.IsKeyDown(Keys.Down))
        {
            movementDirection += Vector2.UnitY;
        }
        if (state.IsKeyDown(Keys.Up))
        {
            movementDirection -= Vector2.UnitY;
        }
        if (state.IsKeyDown(Keys.Left))
        {
            movementDirection -= Vector2.UnitX;
        }
        if (state.IsKeyDown(Keys.Right))
        {
            movementDirection += Vector2.UnitX;
        }
        return movementDirection;
    }
}