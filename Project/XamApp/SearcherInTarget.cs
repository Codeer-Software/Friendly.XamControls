using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Linq;
using System.Windows.Threading;

namespace XamApp
{
    static class SearcherInTarget
    {
        internal static IEnumerable<DependencyObject> VisualTree(this DependencyObject obj)
        {
            List<DependencyObject> list = new List<DependencyObject>();
            list.Add(obj);
            int count = VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < count; i++)
            {
                list.AddRange(VisualTree(VisualTreeHelper.GetChild(obj, i)));
            }
            return list;
        }

        internal static IEnumerable<T> ByType<T>(this IEnumerable<DependencyObject> collection) where T : DependencyObject
        {
            List<T> list = new List<T>();
            foreach (var e in ByType(collection, typeof(T)))
            {
                list.Add((T)e);
            }
            return list;
        }

        internal static IEnumerable<DependencyObject> ByType(this IEnumerable<DependencyObject> collection, Type type)
        {
            return collection.Where(e => type.IsAssignableFrom(e.GetType()));
        }
    }
    static class InvokeUtility
    {
        internal static void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrames), frame);
            Dispatcher.PushFrame(frame);
        }

        static object ExitFrames(object f)
        {
            ((DispatcherFrame)f).Continue = false;
            return null;
        }
    }
}
