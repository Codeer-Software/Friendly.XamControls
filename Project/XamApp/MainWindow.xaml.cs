﻿using System.Windows;

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
            var dlg = new XamDataGridWindow();
            dlg.ShowDialog();
        }

        void ButtonXamRibbon2010Click(object sender, RoutedEventArgs e)
        {
            var dlg = new XamRibbonWindow2010();
            dlg.ShowDialog();
        }
        void ButtonXamRibbonClick(object sender, RoutedEventArgs e)
        {
            var dlg = new XamRibbonWindow();
            dlg.ShowDialog();
        }

        void ButtonXamDataTreeClick(object sender, RoutedEventArgs e)
        {
            var dlg = new XamDataTreeWindow();
            dlg.ShowDialog();
        }

        void ButtonXamOutlookBarClick(object sender, RoutedEventArgs e)
        {
            var dlg = new XamOutlookBarWindow();
            dlg.ShowDialog();
        }

        void ButtonXamCalendarClick(object sender, RoutedEventArgs e)
        {
            var dlg = new XamCalendarWindow();
            dlg.ShowDialog();
        }

        void ButtonXamTabControlClick(object sender, RoutedEventArgs e)
        {
            var dlg = new XamTabControlWindow();
            dlg.ShowDialog();
        }
        
        void ButtonXamEditorsClick(object sender, RoutedEventArgs e)
        {
            var dlg = new XamEditorsWindow();
            dlg.ShowDialog();
        }

        void ButtonXamDockManagerClick(object sender, RoutedEventArgs e)
        {
            var dlg = new XamDockManagerWindow();
            dlg.ShowDialog();
        }
    }
}
