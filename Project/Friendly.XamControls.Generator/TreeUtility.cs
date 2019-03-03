using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Friendly.XamControls.Generator
{
    static class TreeUtility
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
    }
}
