using System.Runtime.InteropServices;
using System.Text;

namespace WindowTitler
{
    internal class WinStuff
    {

        public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string? className, string windowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetWindowText(IntPtr hwnd, string windowName);

        [DllImport("USER32.DLL")]
        public static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        public static string? GetWindowText(IntPtr hWnd)
        {
            int len = GetWindowTextLength(hWnd);
            if (len <= 0)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder(len);
            GetWindowText(hWnd, sb, len + 1);
            return sb.ToString();
        }

        [DllImport("USER32.DLL")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        public static extern IntPtr GetShellWindow();

    }
}
