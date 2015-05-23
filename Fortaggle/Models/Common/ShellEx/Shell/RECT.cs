using System.Runtime.InteropServices;

namespace Fortaggle.Models.Common.ShellEx.Shell
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
