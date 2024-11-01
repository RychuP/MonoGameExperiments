using MonoGameGum.Forms.Controls;
using MonoGameGum.Forms;
using MonoGameGum.GueDeriving;
using RenderingLibrary;
using MonoGameExperiments.GumUI.Components;

namespace MonoGameExperiments.GumUI;

internal class GumSample(Manager manager) : DrawableGameComponent(manager)
{
    // Gum renders and updates using a hierarchy. At least
    // one object must have its AddToManagers method called.
    // If not loading from-file, then the easiest way to do this
    // is to create a ContainerRuntime and add it to the managers.
    ContainerRuntime Root;

    public override void Initialize()
    {
        SystemManagers.Default = new SystemManagers(); 
        SystemManagers.Default.Initialize(Game.GraphicsDevice, fullInstantiation: true);
        FormsUtilities.InitializeDefaults();

        

        Root = new ContainerRuntime
        {
            Width = 0,
            Height = 0,
            WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer,
            HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer
        };
        Root.AddToManagers();


        var button = new Button
        {
            X = 50,
            Y = 50,
            Width = 100,
            Height = 50,
            Text = "Hello MonoGame.Extended!"
        };
        Root.Children.Add(button.Visual);
        int clickCount = 0;
        button.Click += (_, _) =>
        {
            clickCount++;
            button.Text = $"Clicked {clickCount} times";
        };


        var myButton = new ButtonRuntime
        {
            X = 150,
            Y = 150,
            Text = "My Test Button"
        };
        Root.Children.Add(myButton);

        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        FormsUtilities.Update(gameTime, Root);
        SystemManagers.Default.Activity(gameTime.TotalGameTime.TotalSeconds);
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        SystemManagers.Default.Draw();
    }
}   