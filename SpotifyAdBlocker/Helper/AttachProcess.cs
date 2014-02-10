using System.Diagnostics;

namespace SpotifyAdBlocker
{
    public class AttachProcess
    {
        public static bool IsPlaying { get; set; }
        public static string Artist { get; set; }
        /// <summary>
        /// If Spotify play something it will get you the title of the song.
        /// </summary>
        /// <returns>Artist name</returns>
        public static string GetTitle()
        {
            string processTitle = null;
            foreach (var spotifyProcess in Process.GetProcessesByName("Spotify"))
            {
                    processTitle = spotifyProcess.MainWindowTitle;
            }

            if (!string.IsNullOrEmpty(processTitle))
                if (processTitle.Contains("-")) //If return true it is playing
                {
                    IsPlaying = true;
                    processTitle = processTitle.Remove(0, 10).Replace(" – ", "#"); //Handling &mdash
                    var artistAndSongTitle = processTitle.Split('#'); //Split Artist and Song Name
                    Artist = artistAndSongTitle[0];
                }
                else
                {
                    IsPlaying = false;
                    Artist = "Not Playing";
                }
            return Artist;
        }
    }
}
