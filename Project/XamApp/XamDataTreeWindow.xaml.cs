using System.Collections.Generic;
using System.Windows;

namespace XamApp
{
    public partial class XamDataTreeWindow : Window
    {
        public XamDataTreeWindow()
        {
            InitializeComponent();

            Children = new List<TreeData>();
            for (int i = 0; i < 100; i++)
            {
                var c = new TreeData() { Name = i.ToString() };
                c.Children.Add(new TreeData() { Name = i.ToString() + "-0" });
                Children.Add(c);
            }
            DataContext = this;
        }

        public List<TreeData> Children { get; set; }
    }

    public class TreeData
    {
        public string Name { get; set; }
        public List<TreeData> Children { get; set; }

        public TreeData()
        {
            Children = new List<TreeData>();
        }
    }
}
