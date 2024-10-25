using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System.Collections.Generic;

namespace MonoGameExperiments.Extended.Collisions;

internal class ColisionsSample(Manager manager) : DrawableGameComponent(manager)
{
    private readonly List<IEntity> _entities = new();
    private CollisionComponent _collisionComponent;

    public override void Initialize()
    {
        var width = GraphicsDevice.Viewport.TitleSafeArea.Width;
        var height = GraphicsDevice.Viewport.TitleSafeArea.Height;
        var bounds = new RectangleF(0, 0, width, height);
        _collisionComponent = new CollisionComponent(bounds);

        int wallWidth = 3;
        RectangleF leftWallBounds = new(0, 0, wallWidth, height);
        RectangleF rightWallBounds = new(width - wallWidth, 0, wallWidth, height);
        RectangleF topWallBounds = new(wallWidth, 0, width - wallWidth * 2, wallWidth);
        RectangleF botomWallBounds = new(wallWidth, height - wallWidth, 
            width - wallWidth * 2, wallWidth);

        _collisionComponent.Insert(new Wall(manager, leftWallBounds));
        _collisionComponent.Insert(new Wall(manager, rightWallBounds));
        _collisionComponent.Insert(new Wall(manager, topWallBounds));
        _collisionComponent.Insert(new Wall(manager, botomWallBounds));

        for (var i = 0; i < 40; i++)
        {
            var size = manager.Random.Next(20, 40);
            int x = manager.Random.Next(wallWidth + size, width - wallWidth);
            int y = manager.Random.Next(wallWidth, height - wallWidth);
            var position = new Vector2(x, y);
            if (i % 2 == 0)
            {
                _entities.Add(new BallEntity(manager, new CircleF(position, size)));
            }
            else
            {
                var rectSize = new SizeF(size, size);
                _entities.Add(new CubeEntity(manager, new RectangleF(position, rectSize)));
            }
        }

        foreach (IEntity entity in _entities)
            _collisionComponent.Insert(entity);

        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        foreach (IEntity entity in _entities)
            entity.Update(gameTime);
        _collisionComponent.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        manager.SpriteBatch.Begin();
        foreach (IEntity entity in _entities)
            entity.Draw();
        manager.SpriteBatch.End();
    }
}