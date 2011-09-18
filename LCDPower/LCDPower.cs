using System;
using Microsoft.Win32;

namespace LCDPower
{
    public static class LCDPower
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr FindWindow(String lpClassName = null, String lpWindowName = null);

        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MONITORPOWER = 0xF170;
        const int HWND_BROADCAST = 0xFFFF;


        static void Main(string[] args)
        {
            TurnOffLCD();
        }

        public static void TurnOffLCD()
        {
            SendMessage(findAnyWindow().ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, 2);
            //SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
        }

        public static void TurnOffLCD(System.IO.StreamWriter sw)
        {
            sw.WriteLine("LCD Power Start");
            sw.Flush();

            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 2);

            sw.WriteLine("LCD Power Done");
            sw.Flush();
        }

        public static IntPtr findAnyWindow()
        {
            return FindWindow(null, null);
        }
    }
}
