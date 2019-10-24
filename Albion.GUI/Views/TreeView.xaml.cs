using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Albion.GUI.Views
{
    /// <summary>
    /// Interaction logic for TreeViewControl.xaml
    /// </summary>
    public partial class TreeView : UserControl
    {
        public TreeView()
        {
            InitializeComponent();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            BindingExpression be = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
            be?.UpdateSource();
        }
    }
}
