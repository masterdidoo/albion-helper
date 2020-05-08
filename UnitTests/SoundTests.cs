using System;
using System.Media;
using System.Threading;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class SoundTests
    {
        [TestMethod]
        public void TestPlaySound()
        {
            SystemSounds.Beep.Play();
        }

        //[TestMethod]
        public void TestMpSound()
        {
            SoundPlayer player = new SoundPlayer("sound.wav");
            player.Play();

            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"sound.mp3",UriKind.Relative));
            mediaPlayer.Play();
            Thread.Sleep(10000);
        }
    }
}