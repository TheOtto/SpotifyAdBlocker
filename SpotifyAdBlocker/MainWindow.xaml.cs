using System.Windows.Forms;
using SpotifyAdBlocker.Helper;
using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;


namespace SpotifyAdBlocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected DispatcherTimer dispatcherTimer = new DispatcherTimer();
        protected string artist;

        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            artist = AttachProcess.GetTitle();
            if (AttachProcess.IsPlaying)
            {
                if (!CmdOperations.IsMuted)
                {
                    if (File.ReadAllText(Location.FindAppDomain() + "\\blocklist.txt").Contains(artist))
                    {
                        CmdOperations.AdMute();
                    }
                }
                else
                {
                    if (!File.ReadAllText(Location.FindAppDomain() + "\\blocklist.txt").Contains(artist))
                    {
                        CmdOperations.UnMute();
                    }
                }
            }
            else
            {
                CmdOperations.UnMute();
                if(CmdOperations.IsMuted)
                    Keyboard.SendKey(Keys.MediaPlayPause);
            }
        }

        private void MuteBTN_Click(object sender, RoutedEventArgs e)
        {
            if (!CmdOperations.IsMuted)
            {
                CmdOperations.AdMute();
                if (CmdOperations.IsMuted)
                    Keyboard.SendKey(Keys.MediaPlayPause);
            }
            else
            {
                CmdOperations.UnMute();
                if (!CmdOperations.IsMuted)
                    Keyboard.SendKey(Keys.MediaPlayPause);
            }
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            using (var file = new StreamWriter("blocklist.txt", true))
            {
                file.WriteLine(artist);
            }
        }
    }
}
