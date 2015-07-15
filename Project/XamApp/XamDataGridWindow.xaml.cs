using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.Editors;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace XamApp
{
    public partial class XamDataGridWindow : Window
    {
        public XamDataGridWindow()
        {
            InitializeComponent();

            GridData = new ObservableCollection<Data>();
            
            for (int i = 0; i < 100; i++)
            {
                GridData.Add(new Data() { Text = "t" + i, Combo = "a", Check = true });
            }
            DataContext = this;

            /*
            Infragistics.Windows.Editors.XamTextEditor e;
            e.Text*/
        }

        void ConnectActiveCellChanged()
        {
            _grid.CellActivated += delegate { MessageBox.Show(""); };
        }

        void ConnectCellExitedEditMode()
        {
            _grid.EditModeEnding += delegate { MessageBox.Show(""); };
        }

        public ObservableCollection<Data> GridData { get; set; }
        static public ObservableCollection<string> ComboItems { get; set; }

        static XamDataGridWindow() 
        {
            ComboItems = new ObservableCollection<string>(new[] { "a", "b", "c" });
        }

        public class Data
        {
            public string Text { get; set; }
            public string Combo { get; set; }
            public bool Check { get; set; }
        }
    }
}
