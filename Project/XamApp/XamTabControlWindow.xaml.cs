using Infragistics.Windows.Controls;
using System.Linq;
using System.Windows;

namespace XamApp
{
    public partial class XamTabControlWindow : Window
    {
        public XamTabControlWindow()
        {
            InitializeComponent();
            _tab.ItemsSource = Enumerable.Range(0, 100);
        }

        void ConnectSelectionChanged()
        {
            _tab.SelectionChanged += delegate { MessageBox.Show(""); };
        }

        void ConnectTabItemClosing(TabItemEx item)
        {
            item.Closing += delegate { MessageBox.Show(""); };
        }
    }
}
