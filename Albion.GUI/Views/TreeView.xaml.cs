using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Albion.GUI.Libs;

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
            CommonHelpers.OnKeyDownHandler(sender, e);
        }
    }
}
