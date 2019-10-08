using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Albion.GUI.Controls
{
    /// <summary>
    /// Interaction logic for ArtefactsViewControl.xaml
    /// </summary>
    public partial class RequirementControl : UserControl
    {
        public RequirementControl()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => TitleBox.Text;
            set => TitleBox.Text = value;
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            BindingExpression be = ((TextBox) sender).GetBindingExpression(TextBox.TextProperty);
            be?.UpdateSource();
        }
    }
}
