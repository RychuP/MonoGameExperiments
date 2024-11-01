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

    void ChangeButtonElevation(ButtonElevationState state)
    {
        ButtonElevationStateState = state;
        //Y += 180;
    }

    public void LowerButtonDown() => ChangeButtonElevation(ButtonElevationState.Lowered);
    public void RaiseButtonUp() => ChangeButtonElevation(ButtonElevationState.Raised);
    public void SetDarkButtonColors() => ButtonTopColorsState = ButtonTopColors.Dark;
    public void SetLightButtonColors() => ButtonTopColorsState = ButtonTopColors.Light;
}
