using System.Windows.Controls;

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
            set { TitleBox.Text = value; }
        }
    }
}
