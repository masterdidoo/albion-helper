using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Albion.GUI.Libs
{
    public class CommonHelpers
    {
        public static void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            BindingExpression be = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
            be?.UpdateSource();
        }
    }
}