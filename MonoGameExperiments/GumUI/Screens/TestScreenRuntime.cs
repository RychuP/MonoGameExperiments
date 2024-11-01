using Gum.Converters;
using MonoGameGum.GueDeriving;

namespace MonoGameExperiments.GumUI.Screens
{
    partial class TestScreenRuntime : ContainerRuntime
    {
        partial void CustomInitialize()
        {
            Children.Add(Background);
            Children.Add(ButtonInstance);
        }
    }
}
