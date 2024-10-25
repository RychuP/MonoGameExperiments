using MonoGame.Extended.Collisions;
using MonoGame.Extended;

namespace MonoGameExperiments.Extended.Collisions;

public class BallEntity(Manager manager, CircleF circleF) : Entity(manager, circleF, 30)
{
    public override void Draw()
    {
        Manager.SpriteBatch.DrawCircle((CircleF)Bounds, 8, Color.Sienna, 3f);
    }
}