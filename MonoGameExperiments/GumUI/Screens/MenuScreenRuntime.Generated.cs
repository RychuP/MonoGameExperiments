//Code for MenuScreen
using Gum.Converters;
using MonoGameGum.GueDeriving;
using MonoGameExperiments.GumUI.Components;

namespace MonoGameExperiments.GumUI.Screens
{
    public partial class MenuScreenRuntime:ContainerRuntime
    {
        public ColoredRectangleRuntime Background { get; protected set; }
        public MenuEntryRuntime MainTitle { get; protected set; }
        public ContainerRuntime ContainerInstance { get; protected set; }
        public MenuEntryRuntime SubTitle { get; protected set; }
        public ButtonRuntime SomeButton { get; protected set; }

        public MenuScreenRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true)
        {
            if(fullInstantiation)
            {

                 

                InitializeInstances();

                ApplyDefaultVariables();
                AssignParents();
                CustomInitialize();
            }
        }
        protected virtual void InitializeInstances()
        {
            Background = new ColoredRectangleRuntime();
            Background.Name = "Background";
            MainTitle = new MenuEntryRuntime();
            MainTitle.Name = "MainTitle";
            ContainerInstance = new ContainerRuntime();
            ContainerInstance.Name = "ContainerInstance";
            SubTitle = new MenuEntryRuntime();
            SubTitle.Name = "SubTitle";
            SomeButton = new ButtonRuntime();
            SomeButton.Name = "SomeButton";
        }
        protected virtual void AssignParents()
        {
            this.Children.Add(Background);
            ContainerInstance.Children.Add(MainTitle);
            this.Children.Add(ContainerInstance);
            ContainerInstance.Children.Add(SubTitle);
            this.Children.Add(SomeButton);
        }
        private void ApplyDefaultVariables()
        {
            this.Background.Blue = 182;
            this.Background.Green = 231;
            this.Background.Height = 0f;
            this.Background.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.Background.Red = 107;
            this.Background.Width = 0f;
            this.Background.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.Background.X = 0f;
            this.Background.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.Background.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.Background.Y = 0f;
            this.Background.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.Background.YUnits = GeneralUnitType.PixelsFromMiddle;

            this.MainTitle.DescriptionText = "Main Title";
            this.MainTitle.Rotation = 0f;
            this.MainTitle.X = 0f;
            this.MainTitle.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.MainTitle.Y = 15f;
            this.MainTitle.YUnits = GeneralUnitType.Percentage;

            this.ContainerInstance.ChildrenLayout = global::Gum.Managers.ChildrenLayout.TopToBottomStack;
            this.ContainerInstance.Height = 0f;
            this.ContainerInstance.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.ContainerInstance.StackSpacing = 34.4f;
            this.ContainerInstance.Width = 0f;
            this.ContainerInstance.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.ContainerInstance.X = 0f;
            this.ContainerInstance.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.ContainerInstance.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.ContainerInstance.Y = 0f;
            this.ContainerInstance.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.ContainerInstance.YUnits = GeneralUnitType.PixelsFromMiddle;

            this.SubTitle.DescriptionText = "Sub Title";

            this.SomeButton.X = 0f;
            this.SomeButton.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.SomeButton.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.SomeButton.Y = 85f;
            this.SomeButton.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Bottom;
            this.SomeButton.YUnits = GeneralUnitType.Percentage;

        }
        partial void CustomInitialize();
    }
}
