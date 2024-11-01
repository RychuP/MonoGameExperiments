//Code for VariableReferenceIssue (Container)
using Gum.Converters;
using MonoGameGum.GueDeriving;

namespace MonoGameExperiments.GumUI.Components
{
    public partial class VariableReferenceIssueRuntime:ContainerRuntime
    {
        public ColoredRectangleRuntime TopRect { get; protected set; }
        public ColoredRectangleRuntime BottomRect { get; protected set; }
        public TextRuntime Content { get; protected set; }

        public VariableReferenceIssueRuntime(bool fullInstantiation = true)
        {
            if(fullInstantiation)
            {

                 
                this.Width = 274f;

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
            TopRect = new ColoredRectangleRuntime();
            TopRect.Name = "TopRect";
            BottomRect = new ColoredRectangleRuntime();
            BottomRect.Name = "BottomRect";
            Content = new TextRuntime();
            Content.Name = "Content";
        }
        protected virtual void AssignParents()
        {
            this.Children.Add(TopRect);
            this.Children.Add(BottomRect);
            this.Children.Add(Content);
        }
        private void ApplyDefaultVariables()
        {
            this.TopRect.Height = 85f;
            this.TopRect.Width = 0f;
            this.TopRect.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;

            this.BottomRect.Blue = 148;
            this.BottomRect.Green = 234;
            this.BottomRect.Height = 27f;
            this.BottomRect.Red = 67;
            this.BottomRect.Width = 0f;
            this.BottomRect.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            this.BottomRect.XUnits = GeneralUnitType.PixelsFromSmall;
            this.BottomRect.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Bottom;
            this.BottomRect.YUnits = GeneralUnitType.PixelsFromLarge;

            this.Content.Blue = 0;
            this.Content.Green = 0;
            this.Content.HorizontalAlignment = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.Content.Red = 0;
            this.Content.Text = "Sample Moving Text";
            this.Content.VerticalAlignment = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.Content.Width = 0f;
            this.Content.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.Content.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
            this.Content.XUnits = GeneralUnitType.PixelsFromMiddle;
            this.Content.Y = 27f;

        }
        partial void CustomInitialize();
    }
}
