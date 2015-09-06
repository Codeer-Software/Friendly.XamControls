using Infragistics.Windows.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace XamApp
{
    public partial class XamRibbonWindow : Window
    {
        public XamRibbonWindow()
        {
            InitializeComponent();
        }

        bool b_1_1_clicked;
        private void Click_B_1_1(object sender, RoutedEventArgs e)
        {
            b_1_1_clicked = true;
        }
    }
}
