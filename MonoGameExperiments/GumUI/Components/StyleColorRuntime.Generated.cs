//Code for StyleColor (Container)
using Gum.Converters;
using MonoGameGum.GueDeriving;

namespace MonoGameExperiments.GumUI.Components
{
    public partial class StyleColorRuntime:ContainerRuntime
    {
        public ColoredRectangleRuntime ColorRect { get; protected set; }
        public TextRuntime ColorDesc { get; protected set; }

        public string ColorDescText
        {
            get => ColorDesc.Text;
            set => ColorDesc.Text = value;
        }

        public int ColorRectBlue
        {
            get => ColorRect.Blue;
            set => ColorRect.Blue = value;
        }

        public int ColorRectGreen
        {
            get => ColorRect.Green;
            set => ColorRect.Green = value;
        }

        public int ColorRectRed
        {
            get => ColorRect.Red;
            set => ColorRect.Red = value;
        }

        public StyleColorRuntime(bool fullInstantiation = true)
        {
            if(fullInstantiation)
            {

                this.ChildrenLayout = global::Gum.Managers.ChildrenLayout.LeftToRightStack;
                this.Height = 0f;
                this.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                 
                this.Width = 0f;
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
            ColorRect = new ColoredRectangleRuntime();
            ColorRect.Name = "ColorRect";
            ColorDesc = new TextRuntime();
            ColorDesc.Name = "ColorDesc";
        }
        protected virtual void AssignParents()
        {
            this.Children.Add(ColorRect);
            this.Children.Add(ColorDesc);
        }
        private void ApplyDefaultVariables()
        {
            this.ColorRect.Blue = 37;
            this.ColorRect.Green = 37;
            this.ColorRect.Height = 0f;
            this.ColorRect.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.ColorRect.Red = 37;
            this.ColorRect.Width = 100f;
            this.ColorRect.WidthUnits = global::Gum.DataTypes.DimensionUnitType.PercentageOfOtherDimension;

            this.ColorDesc.Blue = 37;
            this.ColorDesc.Green = 37;
            this.ColorDesc.Height = 4f;
            this.ColorDesc.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.ColorDesc.HorizontalAlignment = global::RenderingLibrary.Graphics.HorizontalAlignment.Left;
            this.ColorDesc.Red = 37;
            this.ColorDesc.Text = "ColorDesc";
            this.ColorDesc.VerticalAlignment = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.ColorDesc.Width = 4f;
            this.ColorDesc.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.ColorDesc.X = 4f;

        }
        partial void CustomInitialize();
    }
}
