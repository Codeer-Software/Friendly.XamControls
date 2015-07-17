using System.Windows;

namespace XamApp
{
    public partial class XamCalendarWindow : Window
    {
        public XamCalendarWindow()
        {
            InitializeComponent();
        }

        void ConnectSelectedDatesChanged()
        {
            _calendar.SelectedDatesChanged += delegate { MessageBox.Show(""); };
        }
    }
}
