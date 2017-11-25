using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using System;
using System.Windows;
using System.Windows.Interop;

namespace Friendly.XamControls.Inside
{
    public class XamControlBase : IAppVarOwner, IUIObject
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
        
#if ENG
        /// <summary>
        /// Returns the size of IUIObject.
        /// </summary>
#else
        /// <summary>
        /// IUIObjectのサイズを取得します。
        /// </summary>
#endif
        public System.Drawing.Size Size
        {
            get
            {
                Size size = This.RenderSize;
                return new System.Drawing.Size((int)size.Width, (int)size.Height);
            }
        }

#if ENG
        /// <summary>
        /// Make it active.
        /// </summary>
#else
        /// <summary>
        /// アクティブな状態にします。
        /// </summary>
#endif
        public void Activate()
        {
            var source = App.Type<HwndSource>().FromVisual(this);
            new WindowControl(App, (IntPtr)source.Handle).Activate();
            This.Focus();
        }

#if ENG
        /// <summary>
        /// Convert IUIObject's client coordinates to screen coordinates.
        /// </summary>
        /// <param name="clientPoint">client coordinates.</param>
        /// <returns>screen coordinates.</returns>
#else
        /// <summary>
        /// IUIObjectのクライアント座標からスクリーン座標に変換します。
        /// </summary>
        /// <param name="clientPoint">クライアント座標</param>
        /// <returns>スクリーン座標</returns>
#endif
        public System.Drawing.Point PointToScreen(System.Drawing.Point clientPoint)
        {
            Point pos = This.PointToScreen(new Point(clientPoint.X, clientPoint.Y));
            return new System.Drawing.Point((int)pos.X, (int)pos.Y);
        }
    }
}
