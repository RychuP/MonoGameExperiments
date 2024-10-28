using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.Graphics;

namespace MonoGameExperiments.Extended.Entities;

internal class ECSSample(Manager manager) : DrawableGameComponent(manager)
{
    readonly World _world = new WorldBuilder()
        .AddSystem(new RenderSystem(manager))
        .Build();
    //.AddSystem(new PlayerSystem())
    //.AddSystem(new RenderSystem(GraphicsDevice))
    //.Build();

    public override void Initialize()
    {
        var entity = _world.CreateEntity();
        entity.Attach(new Transform2(Vector2.Zero));
        //entity.Attach(new Sprite(textureRegion));

        // _buffMapper.Put(entityId, buffComponent);

        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        _world.Update(gameTime);
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        _world.Draw(gameTime);
        base.Draw(gameTime);
    }
}