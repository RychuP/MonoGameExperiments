using MonoGame.Extended.ECS;

namespace MonoGameExperiments.Extended.Entities.Rain;

internal class RainSimulator(Manager manager) : GameComponent(manager)
{
    readonly World _world = new WorldBuilder()
        .AddSystem(new RainfallSystem())
        .AddSystem(new ExpirySystem())
        .AddSystem(new RenderSystem(manager))
        .Build();

    public override void Initialize()
    {
        manager.Components.Add(_world);
        base.Initialize();
    }
}