using MonoGame.Extended.Collisions;
using MonoGame.Extended;

namespace MonoGameExperiments.Extended.Collisions;

public class Entity : IEntity
{
    readonly int _velocityModifier;
    public Vector2 Velocity;
    public IShapeF Bounds { get; }
    protected Manager Manager { get; }

    public Entity(Manager manager, IShapeF shape, int velocityModifier)
    {
        Manager = manager;
        _velocityModifier = velocityModifier;
        Bounds = shape;
        RandomizeVelocity();
    }

    public virtual void Draw() { }

    public virtual void Update(GameTime gameTime)
    {
        var prevPos = Bounds.Position;
        Bounds.Position += Velocity * gameTime.GetElapsedSeconds() * _velocityModifier;
        if (Bounds.Position == prevPos)
            RandomizeVelocity();
    }

    public virtual void OnCollision(CollisionEventArgs collisionInfo)
    {
        RandomizeVelocity();
        Bounds.Position -= collisionInfo.PenetrationVector;
    }

    protected void RandomizeVelocity()
    {
        Velocity.X = Manager.Random.Next(-1, 2);
        Velocity.Y = Manager.Random.Next(-1, 2);
    }
}