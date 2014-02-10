using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAdBlocker.Helper
{
    public class CmdOperations
    {
        public static bool IsMuted { get; set; }
        public static void AdMute()
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = true,
                FileName = "cmd.exe",
                Arguments = "/c nircmd muteappvolume spotify.exe 1"
            };
            process.StartInfo = startInfo;
            process.Start();
            IsMuted = true;
            AttachProcess.IsPlaying = false;
        }

        public static void UnMute()
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = true,
                FileName = "cmd.exe",
                Arguments = "/c nircmd muteappvolume spotify.exe 0"
            };
            process.StartInfo = startInfo;
            process.Start();
            IsMuted = false;
            AttachProcess.IsPlaying = true;
        }
    }
}
