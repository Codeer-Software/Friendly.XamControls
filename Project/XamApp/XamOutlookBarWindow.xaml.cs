using System.Windows;

namespace XamApp
{
    public partial class XamOutlookBarWindow : Window
    {
        public XamOutlookBarWindow()
        {
            InitializeComponent();
        }

        void ConnectSelectedGroupChanged()
        {
            _outlook.SelectedGroupChanged += delegate { MessageBox.Show(""); };
        }
    }
}
