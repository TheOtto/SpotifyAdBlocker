using System;

namespace SpotifyAdBlocker.Helper
{
    public class Location
    {
        public static string FindAppDomain()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
