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
            Width = 0;
            Height = 0;
            WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
        }
    }
}
