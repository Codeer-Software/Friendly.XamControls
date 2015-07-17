namespace Test
{
    static class Target
    {
        internal static string Path 
        {
#if DEBUG
            get { return System.IO.Path.GetFullPath("../../../XamApp/bin/Debug/XamApp.exe"); }
#else
            get { return System.IO.Path.GetFullPath("../../../XamApp/bin/Release/XamApp.exe"); }
#endif
        }
    }
}
