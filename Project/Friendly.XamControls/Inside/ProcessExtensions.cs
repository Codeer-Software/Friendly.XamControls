using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Friendly.XamControls.Inside
{
    static class ProcessExtensions
    {
        internal static void Activate(this Process process)
        {
            while (true)
            {
                int id = 0;
                GetWindowThreadProcessId(GetForegroundWindow(), out id);
                if (id == process.Id)
                {
                    break;
                }
                Interaction.AppActivate(process.Id);
                InvokeUtility.DoEvents();
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
    }
}
