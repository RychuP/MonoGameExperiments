using MonoGameGum.GueDeriving;

namespace MonoGameExperiments.GumUI.Components;

partial class ButtonRuntime : ContainerRuntime
{
    partial void CustomInitialize()
    {
        Push += (o, e) => LowerButtonDown();
        LosePush += (o, e) => RaiseButtonUp();
        RollOn += (o, e) => SetLightButtonColors();
        RollOff += (o, e) => SetDarkButtonColors();
    }

    public void LowerButtonDown() => ButtonElevationState = ButtonElevation.Lowered;
    public void RaiseButtonUp() => ButtonElevationState = ButtonElevation.Raised;
    public void SetDarkButtonColors() => ButtonBrightnessState = ButtonBrightness.Dark;
    public void SetLightButtonColors() => ButtonBrightnessState = ButtonBrightness.Light;
}
