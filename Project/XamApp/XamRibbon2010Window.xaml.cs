using Infragistics.Windows.Ribbon;
using System.Windows;

namespace XamApp
{
    public partial class XamRibbonWindow2010 : Window
    {
        public XamRibbonWindow2010()
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

        void ConnectApplicationMenu2010Item2Clicked()
        {
            ((ApplicationMenu2010Item)_ribbon.ApplicationMenu2010.Items[2]).Click += delegate { MessageBox.Show(""); };
        }
    }
}
