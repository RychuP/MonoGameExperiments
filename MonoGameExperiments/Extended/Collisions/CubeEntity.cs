using MonoGame.Extended.Collisions;
using MonoGame.Extended;

namespace MonoGameExperiments.Extended.Collisions;

public class CubeEntity(Manager manager, RectangleF rectangleF) : Entity(manager, rectangleF, 50)
{
    public override void Draw()
    {
        Manager.SpriteBatch.DrawRectangle((RectangleF)Bounds, Color.OrangeRed, 3);
    }
}