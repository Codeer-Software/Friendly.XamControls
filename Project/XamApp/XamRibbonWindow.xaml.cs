using Infragistics.Windows.Ribbon;
using System.Windows;

namespace XamApp
{
    public partial class XamRibbonWindow : Window
    {
        public XamRibbonWindow()
        {
            InitializeComponent();
        }

        public void ConnectApplicationMenu2010Opened()
        {
            _ribbon.ApplicationMenu2010.Opened += delegate { MessageBox.Show(""); };
        }

        public void ConnectApplicationMenu2010Closed()
        {
            _ribbon.ApplicationMenu2010.Closed += delegate { MessageBox.Show(""); };
        }

        void ConnectRibbonTabItemSelected()
        {
            _ribbon.RibbonTabItemSelected += delegate { MessageBox.Show(""); };
        }
    }
}
