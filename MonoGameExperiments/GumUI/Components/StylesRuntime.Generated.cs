//Code for Styles (Container)
using Gum.Converters;
using MonoGameGum.GueDeriving;

namespace MonoGameExperiments.GumUI.Components
{
    public partial class StylesRuntime:ContainerRuntime
    {
        public ColoredRectangleRuntime TextColorRect { get; protected set; }
        public ColoredRectangleRuntime TextColor { get; protected set; }
        public TextRuntime TextColorDesc { get; protected set; }
        public ContainerRuntime HighlightColor { get; protected set; }
        public ColoredRectangleRuntime ColoredRectangleInstance { get; protected set; }

        public StylesRuntime(bool fullInstantiation = true)
        {
            if(fullInstantiation)
            {

                this.AutoGridHorizontalCells = 4;
                this.AutoGridVerticalCells = 4;
                this.ChildrenLayout = global::Gum.Managers.ChildrenLayout.TopToBottomStack;
                this.ClipsChildren = false;
                 
                this.FlipHorizontal = false;
                 
                this.Height = 0f;
                this.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                this.IgnoredByParentSize = false;
                 
                this.Rotation = 0f;
                this.StackSpacing = 5f;
                this.Visible = true;
                this.Width = 0f;
                this.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                this.WrapsChildren = false;
                this.X = 0f;
                this.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
                this.XUnits = GeneralUnitType.PixelsFromMiddle;
                this.Y = 0f;
                this.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
                this.YUnits = GeneralUnitType.PixelsFromMiddle;

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
            TextColorRect = new ColoredRectangleRuntime();
            TextColorRect.Name = "TextColorRect";
            TextColor = new ColoredRectangleRuntime();
            TextColor.Name = "TextColor";
            TextColorDesc = new TextRuntime();
            TextColorDesc.Name = "TextColorDesc";
            HighlightColor = new ContainerRuntime();
            HighlightColor.Name = "HighlightColor";
            ColoredRectangleInstance = new ColoredRectangleRuntime();
            ColoredRectangleInstance.Name = "ColoredRectangleInstance";
        }
        protected virtual void AssignParents()
        {
            TextColor.Children.Add(TextColorRect);
            this.Children.Add(TextColor);
            TextColor.Children.Add(TextColorDesc);
            this.Children.Add(HighlightColor);
            this.Children.Add(ColoredRectangleInstance);
        }
        private void ApplyDefaultVariables()
        {
            this.TextColorRect.Blue = 37;
            this.TextColorRect.Green = 37;
            this.TextColorRect.Height = 0f;
            this.TextColorRect.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.TextColorRect.Red = 37;
            this.TextColorRect.Width = 100f;
            this.TextColorRect.WidthUnits = global::Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;

            this.TextColor.Height = 0f;
            this.TextColor.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.TextColor.Width = 0f;
            this.TextColor.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

            this.TextColorDesc.Blue = 37;
            this.TextColorDesc.Green = 37;
            this.TextColorDesc.Height = 4f;
            this.TextColorDesc.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.TextColorDesc.HorizontalAlignment = global::RenderingLibrary.Graphics.HorizontalAlignment.Left;
            this.TextColorDesc.Red = 37;
            this.TextColorDesc.Text = "Text Color";
            this.TextColorDesc.VerticalAlignment = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.TextColorDesc.Width = 4f;
            this.TextColorDesc.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.TextColorDesc.X = 4f;



        }
        partial void CustomInitialize();
    }
}
