//Code for Button (Container)
using Gum.Converters;
using MonoGameGum.GueDeriving;
using MonoGameExperiments.GumUI.Components;

namespace MonoGameExperiments.GumUI.Components
{
    public partial class ButtonRuntime:ContainerRuntime
    {
        public enum ButtonBrightness
        {
            Dark,
            Light,
        }
        public enum ButtonElevation
        {
            Raised,
            Lowered,
        }

        ButtonBrightness mButtonBrightnessState;
        public ButtonBrightness ButtonBrightnessState
        {
            get => mButtonBrightnessState;
            set
            {
                mButtonBrightnessState = value;
                var appliedDynamically = false;
                if(!appliedDynamically)
                {
                    switch (value)
                    {
                        case ButtonBrightness.Dark:
                            this.Description.Blue = 37;
                            this.Description.Green = 37;
                            this.Description.Red = 37;
                            this.TopGreySurface.Visible = true;
                            break;
                        case ButtonBrightness.Light:
                            this.Description.Blue = 49;
                            this.Description.Green = 66;
                            this.Description.Red = 142;
                            this.TopGreySurface.Visible = false;
                            break;
                    }
                }
            }
        }

        ButtonElevation mButtonElevationState;
        public ButtonElevation ButtonElevationState
        {
            get => mButtonElevationState;
            set
            {
                mButtonElevationState = value;
                var appliedDynamically = false;
                if(!appliedDynamically)
                {
                    switch (value)
                    {
                        case ButtonElevation.Raised:
                            this.Side.Visible = true;
                            this.Top.Y = 0f;
                            break;
                        case ButtonElevation.Lowered:
                            this.Side.Visible = false;
                            this.Top.Y = 4f;
                            break;
                    }
                }
            }
        }
        public ContainerRuntime Top { get; protected set; }
        public ContainerRuntime Side { get; protected set; }
        public ColoredRectangleRuntime TopOutline { get; protected set; }
        public ColoredRectangleRuntime TopWhiteSurface { get; protected set; }
        public ColoredRectangleRuntime TopGreySurface { get; protected set; }
        public TextRuntime Description { get; protected set; }
        public ColoredRectangleRuntime SideOutline { get; protected set; }
        public ColoredRectangleRuntime SideColor { get; protected set; }

        public string Text
        {
            get => Description.Text;
            set => Description.Text = value;
        }

        public ButtonRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true)
        {
            if(fullInstantiation)
            {
                this.Height = 0f;
                this.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                 
                this.Width = 0f;
                this.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

                InitializeInstances();

                ApplyDefaultVariables();
                AssignParents();
                CustomInitialize();
            }
        }
        protected virtual void InitializeInstances()
        {
            Top = new ContainerRuntime();
            Top.Name = "Top";
            Side = new ContainerRuntime();
            Side.Name = "Side";
            TopOutline = new ColoredRectangleRuntime();
            TopOutline.Name = "TopOutline";
            TopWhiteSurface = new ColoredRectangleRuntime();
            TopWhiteSurface.Name = "TopWhiteSurface";
            TopGreySurface = new ColoredRectangleRuntime();
            TopGreySurface.Name = "TopGreySurface";
            Description = new TextRuntime();
            Description.Name = "Description";
            SideOutline = new ColoredRectangleRuntime();
            SideOutline.Name = "SideOutline";
            SideColor = new ColoredRectangleRuntime();
            SideColor.Name = "SideColor";
        }
        protected virtual void AssignParents()
        {
            this.Children.Add(Top);
            this.Children.Add(Side);
            Top.Children.Add(TopOutline);
            Top.Children.Add(TopWhiteSurface);
            Top.Children.Add(TopGreySurface);
            Top.Children.Add(Description);
            Side.Children.Add(SideOutline);
            Side.Children.Add(SideColor);
        }
        private void ApplyDefaultVariables()
        {
            this.Top.Height = 16f;
            this.Top.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.Top.Width = 60f;
            this.Top.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

            this.Side.Height = 5f;
            this.Side.HeightUnits = global::Gum.DataTypes.DimensionUnitType.Absolute;
            this.Side.Width = 0f;
            this.Side.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.Side.X = 0f;
            this.Side.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.Side.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.Side.Y = -1f;
            this.Side.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Top;
            this.Side.YUnits = GeneralUnitType.PixelsFromLarge;

            this.TopOutline.Blue = 40;
            this.TopOutline.Green = 41;
            this.TopOutline.Height = 0f;
            this.TopOutline.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.TopOutline.Red = 41;
            this.TopOutline.Width = 0f;
            this.TopOutline.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.TopOutline.X = 0f;
            this.TopOutline.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.TopOutline.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.TopOutline.Y = 0f;
            this.TopOutline.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.TopOutline.YUnits = GeneralUnitType.PixelsFromMiddle;

            this.TopWhiteSurface.Height = -2f;
            this.TopWhiteSurface.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.TopWhiteSurface.Width = -2f;
            this.TopWhiteSurface.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.TopWhiteSurface.X = 0f;
            this.TopWhiteSurface.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.TopWhiteSurface.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.TopWhiteSurface.Y = 1f;
            this.TopWhiteSurface.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Top;
            this.TopWhiteSurface.YUnits = GeneralUnitType.PixelsFromSmall;

            this.TopGreySurface.Blue = 232;
            this.TopGreySurface.Green = 232;
            this.TopGreySurface.Height = -4f;
            this.TopGreySurface.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.TopGreySurface.Red = 232;
            this.TopGreySurface.Visible = true;
            this.TopGreySurface.Width = -4f;
            this.TopGreySurface.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.TopGreySurface.X = 0f;
            this.TopGreySurface.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.TopGreySurface.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.TopGreySurface.Y = 2f;
            this.TopGreySurface.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Top;
            this.TopGreySurface.YUnits = GeneralUnitType.PixelsFromSmall;

            this.Description.Blue = 37;
            this.Description.FontSize = 32;
            this.Description.Green = 37;
            this.Description.Height = 0f;
            this.Description.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.Description.Red = 37;
            this.Description.Width = 0f;
            this.Description.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.Description.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.Description.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.Description.Y = 0f;
            this.Description.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.Description.YUnits = GeneralUnitType.PixelsFromMiddle;

            this.SideOutline.Blue = 0;
            this.SideOutline.Green = 0;
            this.SideOutline.Height = 0f;
            this.SideOutline.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.SideOutline.Red = 0;
            this.SideOutline.Width = 0f;
            this.SideOutline.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.SideOutline.X = 0f;
            this.SideOutline.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.SideOutline.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.SideOutline.Y = 0f;
            this.SideOutline.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.SideOutline.YUnits = GeneralUnitType.PixelsFromMiddle;

            this.SideColor.Blue = 175;
            this.SideColor.Green = 175;
            this.SideColor.Height = 4f;
            this.SideColor.HeightUnits = global::Gum.DataTypes.DimensionUnitType.Absolute;
            this.SideColor.Red = 175;
            this.SideColor.Width = -2f;
            this.SideColor.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.SideColor.X = 0f;
            this.SideColor.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.SideColor.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.SideColor.Y = -1f;
            this.SideColor.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Bottom;
            this.SideColor.YUnits = GeneralUnitType.PixelsFromLarge;

        }
        partial void CustomInitialize();
    }
}
