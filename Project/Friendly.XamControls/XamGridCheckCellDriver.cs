﻿using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamGridCheckCellDriver : XamGridCellDriver
    {
        public bool? IsChecked { get { return AppVar.IdentifyByType<CheckBox>().IsChecked; } }

        public XamGridCheckCellDriver(XamGridCellDriver cell)
            : base(cell.Grid, cell.CellData) { }

        public void EmulateEdit(bool? check)
        {
            Static.EmulateEdit(Grid, CellData, check);
        }

        public void EmulateEdit(bool? check, Async async)
        {
            Static.EmulateEdit(Grid, CellData, check, async);
        }

        static void EmulateEdit(dynamic grid, dynamic cell, bool? check)
        {
            EmulateActivate(grid, cell);
            grid.EnterEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = grid.ActiveCell.Control;
            var checkBox = ctrl.VisualTree().ByType<CheckBox>().Single();
            checkBox.IsChecked = check;
            grid.ExitEditMode(false);
        }
    }

    public static class XamGridCheckCellDriverExtensions
    {
        public static XamGridCheckCellDriver AsCheck(this XamGridCellDriver cell)
        {
            return new XamGridCheckCellDriver(cell);
        }
    }
}
