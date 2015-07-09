using System.Windows;

namespace XamApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void ButtonXamGridClick(object sender, RoutedEventArgs e)
        {
            var dlg = new XamGridWindow();
            dlg.ShowDialog();
        }

        void ButtonXamDataGridClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
