using System.Windows;

namespace XamApp
{
    public partial class XamEditorsWindow : Window
    {
        public XamEditorsWindow()
        {
            InitializeComponent();
            _combo.DisplayMemberPath = "Text";
            _combo.ItemsSource = new ComboCandidate[] {
                new ComboCandidate(){Text = "a"},
                new ComboCandidate(){Text = "b"},
                new ComboCandidate(){Text = "c"},
            };
        }

        void ConnectSelectedIndexChanged() 
        {
            _combo.SelectionChanged += delegate { MessageBox.Show(""); };
        }

        public class ComboCandidate 
        {
            public string Text { get; set; }
        }
    }
}
