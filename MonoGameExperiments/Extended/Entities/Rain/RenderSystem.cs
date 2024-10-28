using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.ECS;
using MonoGame.Extended;

namespace MonoGameExperiments.Extended.Entities.Rain;

public class RenderSystem(Manager manager) : 
    EntityDrawSystem(Aspect.All(typeof(Transform2), typeof(RainDrop)))
{
    private ComponentMapper<Transform2> _transformMapper;
    private ComponentMapper<RainDrop> _raindropMapper;

    public override void Initialize(IComponentMapperService mapperService)
    {
        _transformMapper = mapperService.GetMapper<Transform2>();
        _raindropMapper = mapperService.GetMapper<RainDrop>();
    }

    public override void Draw(GameTime gameTime)
    {
        manager.GraphicsDevice.Clear(Color.DarkBlue * 0.2f);
        manager.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        foreach (var entityId in ActiveEntities)
        {
            var transform = _transformMapper.Get(entityId);
            var raindrop = _raindropMapper.Get(entityId);
            var size = new SizeF(raindrop.Size, raindrop.Size);
            manager.SpriteBatch.FillRectangle(transform.Position, size, Color.LightBlue);
        }

        manager.SpriteBatch.End();
    }
}