using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.Graphics;

namespace MonoGameExperiments.Extended.Entities;

class RenderSystem(Manager manager) : EntityDrawSystem(Aspect.All(typeof(Sprite), typeof(Transform2)))
{
    ComponentMapper<Transform2> _transformMapper;
    ComponentMapper<Sprite> _spriteMapper;

    public override void Draw(GameTime gameTime)
    {
        manager.SpriteBatch.Begin();

        foreach (var entityId in ActiveEntities)
        {
            var transform = _transformMapper.Get(entityId);
            var sprite = _spriteMapper.Get(entityId);
            manager.SpriteBatch.Draw(sprite, transform);
        }

        manager.SpriteBatch.End();
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _transformMapper = mapperService.GetMapper<Transform2>();
        _spriteMapper = mapperService.GetMapper<Sprite>();
    }
}