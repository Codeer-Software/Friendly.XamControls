﻿using System.Collections.Generic;
using System.Windows;

namespace XamApp
{
    public partial class XamDataTreeWindow : Window
    {
        public XamDataTreeWindow()
        {
            InitializeComponent();

            Children = new List<Data>();
            for (int i = 0; i < 100; i++)
            {
                var c = new Data() { Name = i.ToString() };
                c.Children.Add(new Data() { Name = i.ToString() + "-0" });
                Children.Add(c);
            }
            DataContext = this;
        }

        void ConnectActiveNodeChanged()
        {
            _tree.ActiveNodeChanged += delegate { MessageBox.Show(""); };
        }

        void ConnectNodeCheckedChanged()
        {
            _tree.NodeCheckedChanged += delegate { MessageBox.Show(""); };
        }

        void ConnectNodeExpansionChanged()
        {
            _tree.NodeExpansionChanged += delegate { MessageBox.Show(""); };
        }

        void ConnectNodeExitedEditMode()
        {
            _tree.NodeExitingEditMode += delegate { MessageBox.Show(""); };
        }

        public List<Data> Children { get; set; }

        public class Data
        {
            public string Name { get; set; }
            public List<Data> Children { get; set; }

            public Data()
            {
                Children = new List<Data>();
            }
        }
    }

}
