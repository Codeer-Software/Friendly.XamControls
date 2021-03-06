﻿using Codeer.Friendly;
using Friendly.XamControls.Inside;
using Codeer.Friendly.Dynamic;
using System.Collections.Generic;
using System.Diagnostics;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Linq;

namespace Friendly.XamControls
{
    [ControlDriver(TypeFullName = "Infragistics.Windows.DockManager.XamDockManager")]
    public class XamDockManagerDriver : XamControlBase
    {
        public XamContentPaneDriver ActivePane { get { return new XamContentPaneDriver(Static.GetActivePane(this)); } }

        public XamDockManagerDriver(AppVar src) : base(src) { }

        public XamContentPaneDriver[] GetPanes()
        { 
            var order = App.Type().Infragistics.Windows.DockManager.PaneNavigationOrder.ActivationOrder;
            var list = new List<XamContentPaneDriver>(); 
            foreach (var e in Static.GetPanes(this, order))
            {
                list.Add(new XamContentPaneDriver(e));
            }
            return list.ToArray();
        }

        public XamContentPaneDriver GetPane(string text) => GetPanes().SingleOrDefault(e => e.HeaderText == text);

        static dynamic GetActivePane(dynamic dock)
        {
            Process.GetCurrentProcess().Activate();
            return dock.ActivePane;
        }

        static dynamic GetPanes(dynamic dock, dynamic order)
        {
            return dock.GetPanes(order);
        }
    }
}
