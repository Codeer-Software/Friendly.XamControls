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

            GridData = new ObservableCollection<DataGridData>(new DataGridData[] { 
               new DataGridData(){ Text = "text1", Combo = "a", Check = true},
               new DataGridData(){ Text = "text2", Combo = "b", Check = true},
               new DataGridData(){ Text = "text3", Combo = "c", Check = true},
            
            });
            DataContext = this;
         //   CellValuePresenter.FromCell()
        }

        public ObservableCollection<DataGridData> GridData { get; set; }
        static public ObservableCollection<string> ComboItems { get; set; }

        static XamDataGridWindow() 
        {
            ComboItems = new ObservableCollection<string>(new[] { "a", "b", "c" });
        }
    }

    public class DataGridData
    {
        public string Text { get; set; }
        public string Combo { get; set; }
        public bool Check { get; set; }
    }
}
