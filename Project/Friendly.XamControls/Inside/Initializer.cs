using System;
using System.Reflection;
using Codeer.Friendly.Windows;

namespace Friendly.XamControls.Inside
{
    static class Initializer
    {
        internal static void Init(WindowsAppFriend app)
        {
            string key = typeof(Initializer).FullName;
            object isInit;
            if (!app.TryGetAppControlInfo(key, out isInit))
            {
                WindowsAppExpander.LoadAssembly(app, typeof(Initializer).Assembly);
                app.AddAppControlInfo(key, true);
            }
        }
    }
}
