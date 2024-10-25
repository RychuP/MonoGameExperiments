using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace MonoGameExperiments.Extended.Collisions;

internal class Wall(Manager manager, RectangleF rectangleF) : Entity(manager, rectangleF)
{
    public override void Draw()
    {
        Manager.SpriteBatch.DrawRectangle((RectangleF)Bounds, Color.Black, 3);
    }

    public override void Update(GameTime gameTime) { }

    public override void OnCollision(CollisionEventArgs collisionInfo) { }
}