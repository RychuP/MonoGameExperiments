using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;

namespace MonoGameExperiments.Extended.Input;

public class InputManager : InputListenerComponent
{
    public KeyboardListener Keyboard => Listeners[0] as KeyboardListener;
    public MouseListener Mouse => Listeners[1] as MouseListener;

    public InputManager(Game game) : base(game, new KeyboardListener(), new MouseListener())
    {
        Game.Components.Add(this);
    }
}