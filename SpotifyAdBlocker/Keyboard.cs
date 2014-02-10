using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace SpotifyAdBlocker
{
    public class Keyboard
    {
        /***/
        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern void keybd_event(byte bVk, byte bScan, Int32 dwFlags, Int32 dwExtraInfo);

        public static void SendKey(Keys key)
        {
            keybd_event(Convert.ToByte(key), 0, 0, 0);
        }
    }
}
