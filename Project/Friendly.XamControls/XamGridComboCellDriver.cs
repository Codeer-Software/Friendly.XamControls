﻿using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamGridComboCellDriver : XamGridCellDriver
    {
        public string Text { get { return Control.IdentifyByType<ComboBox>().Text; } }

        public int SelectedIndex { get { return Control.IdentifyByType<ComboBox>().SelectedIndex; } }

        public XamGridComboCellDriver(XamGridCellDriver cell)
            : base(cell.Grid, cell.AppVar) { }

        public void EmulateEdit(int index)
        {
            Static.EmulateEdit(Grid, this, index);
        }

        public void EmulateEdit(int index, Async async)
        {
            Static.EmulateEdit(Grid, this, index, async);
        }

        static void EmulateEdit(dynamic grid, dynamic cell, int index)
        {
            EmulateActivate(grid, cell);
            grid.EnterEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = grid.ActiveCell.Control;
            var comboBox = ctrl.VisualTree().ByType<ComboBox>().Single();
            comboBox.SelectedIndex = index;
            grid.ExitEditMode(false);
        }

        public void EmulateEdit(string text)
        {
            Static.EmulateEdit(Grid, this, text);
        }

        public void EmulateEdit(string text, Async async)
        {
            Static.EmulateEdit(Grid, this, text, async);
        }

        static void EmulateEdit(dynamic grid, dynamic cell, string text)
        {
            EmulateActivate(grid, cell);
            grid.EnterEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = grid.ActiveCell.Control;
            var textBox = ctrl.VisualTree().ByType<ComboBox>().Single();
            textBox.Text = text;
            grid.ExitEditMode(false);
        }
    }

    public static class XamGridComboCellDriverExtensions
    {
        public static XamGridComboCellDriver AsCombo(this XamGridCellDriver cell)
        {
            return new XamGridComboCellDriver(cell);
        }
    }
}
