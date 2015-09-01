using System.Windows;

namespace XamApp
{
    public partial class XamDockManagerWindow : Window
    {
        public XamDockManagerWindow()
        {
            InitializeComponent();
            _dock.ActivePane.ExecuteCommand(Infragistics.Windows.DockManager.ContentPaneCommands.Close);
        }
    }
}
