//Code for TestScreen
using Gum.Converters;
using MonoGameExperiments.GumUI.Components;
using MonoGameGum.GueDeriving;

namespace MonoGameExperiments.GumUI.Screens
{
    public partial class TestScreenRuntime:ContainerRuntime
    {
        public ColoredRectangleRuntime Background { get; protected set; }
        public ButtonRuntime ButtonInstance { get; protected set; }

        public TestScreenRuntime(bool fullInstantiation = true)
        {
            if(fullInstantiation)
            {

                 

                InitializeInstances();

                if(fullInstantiation)
                {
                    ApplyDefaultVariables();
                }
                AssignParents();
                CustomInitialize();
            }
        }
        protected virtual void InitializeInstances()
        {
            Background = new ColoredRectangleRuntime();
            Background.Name = "Background";
            ButtonInstance = new ButtonRuntime();
            ButtonInstance.Name = "ButtonInstance";
        }
        protected virtual void AssignParents()
        {
            this.WhatThisContains.Add(Background);
            this.WhatThisContains.Add(ButtonInstance);
        }
        private void ApplyDefaultVariables()
        {
            this.Background.Blue = 237;
            this.Background.Green = 149;
            this.Background.Height = 0f;
            this.Background.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.Background.Red = 100;
            this.Background.Width = 0f;
            this.Background.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.Background.X = 0f;
            this.Background.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.Background.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.Background.Y = 0f;
            this.Background.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.Background.YUnits = GeneralUnitType.PixelsFromMiddle;

            this.ButtonInstance.Text = "Test Button";
            this.ButtonInstance.X = 260.6667f;
            this.ButtonInstance.Y = 114f;

        }
        partial void CustomInitialize();
    }
}
