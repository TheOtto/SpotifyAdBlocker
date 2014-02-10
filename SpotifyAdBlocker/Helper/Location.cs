using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
