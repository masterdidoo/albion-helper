using System.Windows;
using System.Windows.Input;
using Albion.GUI.Libs;

namespace Albion.GUI.Views
{
    /// <summary>
    ///     Interaction logic for ItemWindow.xaml
    /// </summary>
    public partial class ItemWindow : Window
    {
        public ItemWindow()
        {
            InitializeComponent();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            CommonHelpers.OnKeyDownHandler(sender, e);
        }
    }
}