//Code for Button (Container)
using Gum.Converters;
using MonoGameGum.GueDeriving;

namespace MonoGameExperiments.GumUI.Components
{
    public partial class ButtonRuntime:ContainerRuntime
    {
        public enum ButtonTopColors
        {
            Dark,
            Light,
        }
        public enum ButtonElevationState
        {
            Raised,
            Lowered,
        }

        ButtonTopColors mButtonTopColorsState;
        public ButtonTopColors ButtonTopColorsState
        {
            get => mButtonTopColorsState;
            set
            {
                mButtonTopColorsState = value;
                var appliedDynamically = false;
                if(!appliedDynamically)
                {
                    switch (value)
                    {
                        case ButtonTopColors.Dark:
                            this.Description.Blue = 37;
                            this.Description.Green = 37;
                            this.Description.Red = 37;
                            this.GreyTop.Visible = true;
                            break;
                        case ButtonTopColors.Light:
                            this.Description.Blue = 49;
                            this.Description.Green = 66;
                            this.Description.Red = 142;
                            this.GreyTop.Visible = false;
                            break;
                    }
                }
            }
        }

        ButtonElevationState mButtonElevationStateState;
        public ButtonElevationState ButtonElevationStateState
        {
            get => mButtonElevationStateState;
            set
            {
                mButtonElevationStateState = value;
                var appliedDynamically = false;
                if(!appliedDynamically)
                {
                    switch (value)
                    {
                        case ButtonElevationState.Raised:
                            this.Side.Height = 5f;
                            this.Y -= 4;
                            break;
                        case ButtonElevationState.Lowered:
                            this.Side.Height = 1f;
                            this.Y += 4;
                            break;
                    }
                }
            }
        }
        public ContainerRuntime Side { get; protected set; }
        public ColoredRectangleRuntime Outline { get; protected set; }
        public ColoredRectangleRuntime WhiteTop { get; protected set; }
        public ColoredRectangleRuntime GreyTop { get; protected set; }
        public TextRuntime Description { get; protected set; }
        public ColoredRectangleRuntime SideOutline { get; protected set; }
        public ColoredRectangleRuntime SideColor { get; protected set; }

        public string Text
        {
            get => Description.Text;
            set => Description.Text = value;
        }

        public ButtonRuntime(bool fullInstantiation = true)
        {
            if(fullInstantiation)
            {

                this.Height = 16f;
                this.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                 
                this.Width = 60f;
                this.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

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
            Side = new ContainerRuntime();
            Side.Name = "Side";
            Outline = new ColoredRectangleRuntime();
            Outline.Name = "Outline";
            WhiteTop = new ColoredRectangleRuntime();
            WhiteTop.Name = "WhiteTop";
            GreyTop = new ColoredRectangleRuntime();
            GreyTop.Name = "GreyTop";
            Description = new TextRuntime();
            Description.Name = "Description";
            SideOutline = new ColoredRectangleRuntime();
            SideOutline.Name = "SideOutline";
            SideColor = new ColoredRectangleRuntime();
            SideColor.Name = "SideColor";
        }
        protected virtual void AssignParents()
        {
            this.Children.Add(Side);
            this.Children.Add(Outline);
            this.Children.Add(WhiteTop);
            this.Children.Add(GreyTop);
            this.Children.Add(Description);
            Side.Children.Add(SideOutline);
            Side.Children.Add(SideColor);
        }
        private void ApplyDefaultVariables()
        {
            this.Side.Height = 5f;
            this.Side.HeightUnits = global::Gum.DataTypes.DimensionUnitType.Absolute;
            this.Side.Width = 0f;
            this.Side.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.Side.X = 0f;
            this.Side.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.Side.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.Side.Y = 0f;
            this.Side.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Top;
            this.Side.YUnits = GeneralUnitType.PixelsFromLarge;

            this.Outline.Blue = 40;
            this.Outline.Green = 41;
            this.Outline.Height = 0f;
            this.Outline.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.Outline.Red = 41;
            this.Outline.Width = 0f;
            this.Outline.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.Outline.X = 0f;
            this.Outline.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.Outline.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.Outline.Y = 0f;
            this.Outline.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.Outline.YUnits = GeneralUnitType.PixelsFromMiddle;

            this.WhiteTop.Height = -1f;
            this.WhiteTop.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.WhiteTop.Width = -2f;
            this.WhiteTop.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.WhiteTop.X = 0f;
            this.WhiteTop.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.WhiteTop.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.WhiteTop.Y = 1f;
            this.WhiteTop.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Top;
            this.WhiteTop.YUnits = GeneralUnitType.PixelsFromSmall;

            this.GreyTop.Blue = 232;
            this.GreyTop.Green = 232;
            this.GreyTop.Height = -3f;
            this.GreyTop.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.GreyTop.Red = 232;
            this.GreyTop.Visible = true;
            this.GreyTop.Width = -4f;
            this.GreyTop.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.GreyTop.X = 0f;
            this.GreyTop.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.GreyTop.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.GreyTop.Y = 2f;
            this.GreyTop.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Top;
            this.GreyTop.YUnits = GeneralUnitType.PixelsFromSmall;

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
