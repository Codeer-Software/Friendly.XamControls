Friendly.XamControls
============================

This library is a layer on top of
Friendly, so you must learn that first.
But it is very easy to learn.

http://www.english.codeer.co.jp/test-automation/friendly-fundamental  

============================
Friendly.XamControls defines the following classes.   
They can operate the control easily from a separate process.  

* XamCalendarDriver
* XamComboEditorDriver
* XamValueEditorDriver
* XamContentPaneDriver
* XamDataGridDriver
* XamDataGridCellDriver
* XamDataGridCheckCellDriver
* XamDataGridComboCellDriver
* XamDataGridTextCellDriver
* XamDataTreeDriver
* XamDataTreeCheckNodeDriver
* XamDataTreeNodeDriver
* XamDataTreeTextNodeDriver
* XamDockManagerDriver
* XamGridDriver
* XamGridCellDriver
* XamGridCheckCellDriver
* XamGridComboCellDriver
* XamGridTextCellDriver
* XamOutlookBarDriver
* XamOutlookBarGroupDriver
* XamRibbonDriver
* XamApplicationMenu2010Driver
* XamApplicationMenu2010ItemDriver
* XamApplicationMenuDriver
* XamToolMenuItemDriver
* XamTabControlDriver
* XamTabItemDriver

============================
```cs  
//sample  
var process = Process.GetProcessesByName("Target")[0];  
using (var app = new WindowsAppFriend(process))  
{  
    dynamic main = app.Type(typeof(Application)).Current.Window;  
    var _grid = new XamGridDriver(main._grid);
    
    var cell = _grid.GetCell(2, 1);
    cell.EmulateActivate();
    bool isActive = cell.IsActive;
    
    var cellText = _grid.GetCell(2, 0).AsText();
    cellText.EmulateEdit("abc");
    string text = cellText.Text;
    
    var cellCombo = _grid.GetCell(99, 1).AsCombo();
    cellCombo.EmulateEdit(1);
    cellCombo.EmulateEdit("c");
    text = cellCombo.Text;
    int selectedIndex = cellCombo.SelectedIndex;
    
    var cellCheck = _grid.GetCell(99, 2).AsCheck();
    cellCheck.EmulateEdit(false);
    bool checked = cellCheck.IsChecked;
}
```

============================
Download from NuGet.
https://www.nuget.org/packages/Friendly.XamControls/

============================
For other GUI types, use the following libraries:

* For Win32.  
https://www.nuget.org/packages/Codeer.Friendly.Windows.NativeStandardControls/  

* For WinForms.  
https://www.nuget.org/packages/Ong.Friendly.FormsStandardControls/  

* For WPF.  
https://www.nuget.org/packages/RM.Friendly.WPFStandardControls/  

* For getting the target window.  
https://www.nuget.org/packages/Codeer.Friendly.Windows.Grasp/  

* For 3d party.  
https://www.nuget.org/packages/Friendly.XamControls/  
https://www.nuget.org/packages/Friendly.C1.Win/  
https://www.nuget.org/packages/Friendly.FarPoint/  

============================
If you use PinInterface, you map control simple.  
https://www.nuget.org/packages/VSHTC.Friendly.PinInterface/

