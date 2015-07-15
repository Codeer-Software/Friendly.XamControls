using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using System.Windows;

namespace Friendly.XamControls.Inside
{
    public class XamControlBase : IAppVarOwner
    {
        public AppVar AppVar { get; private set; }

        public WindowsAppFriend App { get { return (WindowsAppFriend)AppVar.App; } }

        public Visibility Visibility { get { return this.Dynamic().Visibility; } }

        public bool IsEnabled { get { return this.Dynamic().IsEnabled; } }

        protected dynamic Static { get { return App.Type(GetType()); } }

        protected dynamic This { get { return AppVar.Dynamic(); } }

        public XamControlBase(AppVar src) 
        {
            AppVar = src;
            Initializer.Init(App);
        }
    }
}
