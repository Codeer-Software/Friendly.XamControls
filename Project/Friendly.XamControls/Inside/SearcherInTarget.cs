using Codeer.Friendly.DotNetExecutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Linq;

using Codeer.Friendly;
using Codeer.Friendly.Dynamic;

namespace Friendly.XamControls.Inside
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
            foreach (var e in ByType(collection, typeof(T).FullName))
            {
                list.Add((T)e);
            }
            return list;
        }

        internal static IEnumerable<DependencyObject> ByType(this IEnumerable<DependencyObject> collection, string typeFullName)
        {
            List<DependencyObject> list = new List<DependencyObject>();
            TypeFinder finder = new TypeFinder();
            var type = finder.GetType(typeFullName);
            return collection.Where(e => type.IsAssignableFrom(e.GetType()));
        }
    }

    static class Searcher
    {
        internal static dynamic IdentifyByType<T>(this AppVar obj)
        {
            return IdentifyByType(obj, typeof(T).FullName);
        }
        internal static dynamic IdentifyByType(this AppVar obj, string typeFullName)
        {
            return obj.App.Type(typeof(Searcher)).IdentifyByType(obj, typeFullName);
        }
        static DependencyObject IdentifyByType(DependencyObject obj, string typeFullName)
        {
            return obj.VisualTree().ByType(typeFullName).Single();
        }
    }
}
