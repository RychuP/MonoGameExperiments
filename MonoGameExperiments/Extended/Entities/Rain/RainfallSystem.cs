using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.ECS;
using MonoGame.Extended;

namespace MonoGameExperiments.Extended.Entities.Rain;

public class RainfallSystem() : EntityUpdateSystem(Aspect.All(typeof(Transform2), typeof(RainDrop)))
{
    private readonly FastRandom _random = new();
    private ComponentMapper<Transform2> _transformMapper;
    private ComponentMapper<RainDrop> _raindropMapper;
    private ComponentMapper<Expiry> _expiryMapper;

    private const float MinSpawnDelay = 0.0f;
    private const float MaxSpawnDelay = 0.02f;
    private float _spawnDelay = MaxSpawnDelay;

    public override void Initialize(IComponentMapperService mapperService)
    {
        _transformMapper = mapperService.GetMapper<Transform2>();
        _raindropMapper = mapperService.GetMapper<RainDrop>();
        _expiryMapper = mapperService.GetMapper<Expiry>();
    }

    public override void Update(GameTime gameTime)
    {
        var elapsedSeconds = gameTime.GetElapsedSeconds();

        foreach (var entityId in ActiveEntities)
        {
            var transform = _transformMapper.Get(entityId);
            var raindrop = _raindropMapper.Get(entityId);

            raindrop.Velocity += new Vector2(0, 500) * elapsedSeconds;
            transform.Position += raindrop.Velocity * elapsedSeconds;

            if (transform.Position.Y >= 480 && !_expiryMapper.Has(entityId))
            {
                for (var i = 0; i < 3; i++)
                {
                    var velocity = new Vector2(_random.NextSingle(-100, 100), -raindrop.Velocity.Y * _random.NextSingle(0.1f, 0.2f));
                    var id = CreateRaindrop(transform.Position.SetY(479), velocity, (i + 1) * 0.5f);
                    _expiryMapper.Put(id, new Expiry(1f));
                }

                DestroyEntity(entityId);
            }
        }

        _spawnDelay -= gameTime.GetElapsedSeconds();

        if (_spawnDelay <= 0)
        {
            for (var q = 0; q < 50; q++)
            {
                var position = new Vector2(_random.NextSingle(0, 800), _random.NextSingle(-240, -480));
                CreateRaindrop(position);
            }
            _spawnDelay = _random.NextSingle(MinSpawnDelay, MaxSpawnDelay);
        }
    }

    private int CreateRaindrop(Vector2 position, Vector2 velocity = default, float size = 3)
    {
        var entity = CreateEntity();
        entity.Attach(new Transform2(position));
        entity.Attach(new RainDrop { Velocity = velocity, Size = size });
        return entity.Id;
    }
}