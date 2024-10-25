using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collisions;

namespace MonoGameExperiments.Extended.Collisions;

public interface IEntity : ICollisionActor
{
    public void Update(GameTime gameTime);
    public void Draw();
}