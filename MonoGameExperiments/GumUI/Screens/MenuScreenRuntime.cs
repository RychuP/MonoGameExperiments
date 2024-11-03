using Gum.Converters;
using MonoGameGum.GueDeriving;
using MonoGameExperiments.GumUI.Components;

namespace MonoGameExperiments.GumUI.Screens
{
    partial class MenuScreenRuntime : ContainerRuntime
    {
        public int RollOnCount;

        partial void CustomInitialize()
        {
            Width = 0;
            Height = 0;
            WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;

            MainTitle.RollOn += (o, e) =>
            {
                RollOnCount++;
                MainTitle.Background.Color = Color.Yellow;
            };

            MainTitle.RollOff += (o, e) => MainTitle.Background.Color = Color.White;

            SubTitle.RollOn += (o,e) => SomeButton.SetLightButtonColors();
            SubTitle.RollOff += (o,e) => SomeButton.SetDarkButtonColors();
            SubTitle.Push += (o,e) => SomeButton.LowerButtonDown();
            SubTitle.LosePush += (o,e) => SomeButton.RaiseButtonUp();


            //ButtonInstance.RollOver += (o, e) => ButtonInstance
            //ButtonInstance.RollOff += (o, e) => ButtonInstance.SetDarkButtonColors();
            //ButtonInstance.Push += (o, e) => ButtonInstance.LowerButtonDown();
            //ButtonInstance.LosePush += (o, e) => ButtonInstance.RaiseButtonUp();
            //MenuEntryInstance.RollOn += (o, e) => MenuEntryInstance.Background.Color = Color.Yellow;
        }

        private void MainTitle_RollOff(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}