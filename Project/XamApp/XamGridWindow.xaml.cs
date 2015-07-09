using Infragistics.Controls.Grids;
using Infragistics.Windows.DataPresenter;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;

namespace XamApp
{
    public partial class XamGridWindow : Window
    {
        public XamGridWindow()
        {
            InitializeComponent();

            var data = new List<Data>();
            for (int i = 0; i < 100; i++)
            {
                data.Add(new Data() { Text = "t" + i, Combo = "a", Check = true });
            }
            _grid.ItemsSource = data;
        }

        class Data
        {
            public string Text { get; set; }
            public string Combo { get; set; }
            public bool Check { get; set; }
        }

        void ConnectActiveCellChanged()
        {
            _grid.ActiveCellChanged += delegate { MessageBox.Show(""); };
        }

        void ConnectCellExitedEditMode()
        {
            _grid.CellExitedEditMode += delegate { MessageBox.Show(""); };
        }
    }

    public class ComboItems : List<string>
    {
        public ComboItems()
        {
            Add("a");
            Add("b");
            Add("c");
        }
    }
}
