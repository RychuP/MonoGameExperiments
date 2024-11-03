//Code for MenuEntry (Container)
using Gum.Converters;
using MonoGameGum.GueDeriving;
using MonoGameExperiments.GumUI.Components;

namespace MonoGameExperiments.GumUI.Components
{
    public partial class MenuEntryRuntime:ContainerRuntime
    {
        public ColoredRectangleRuntime Background { get; protected set; }
        public TextRuntime Description { get; protected set; }

        public string DescriptionText
        {
            get => Description.Text;
            set => Description.Text = value;
        }

        public MenuEntryRuntime(bool fullInstantiation = true)
        {
            if(fullInstantiation)
            {

                this.Height = 0f;
                this.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                 
                this.Width = 0f;
                this.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                this.X = 0f;
                this.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
                this.XUnits = GeneralUnitType.PixelsFromMiddle;
                this.Y = 0f;
                this.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Top;
                this.YUnits = GeneralUnitType.PixelsFromSmall;

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
            Description = new TextRuntime();
            Description.Name = "Description";
        }
        protected virtual void AssignParents()
        {
            this.Children.Add(Background);
            this.Children.Add(Description);
        }
        private void ApplyDefaultVariables()
        {
            this.Background.Height = 0f;
            this.Background.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.Background.Width = 0f;
            this.Background.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;

            this.Description.Blue = 7;
            this.Description.FontSize = 64;
            this.Description.Green = 39;
            this.Description.Height = 20f;
            this.Description.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.Description.HorizontalAlignment = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.Description.Red = 39;
            this.Description.VerticalAlignment = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.Description.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.Description.X = 0f;
            this.Description.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.Description.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.Description.Y = 0f;
            this.Description.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.Description.YUnits = GeneralUnitType.PixelsFromMiddle;

        }
        partial void CustomInitialize();
    }
}
