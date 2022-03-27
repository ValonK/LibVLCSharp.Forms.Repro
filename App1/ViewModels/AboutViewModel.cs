using System;
using System.Reflection;
using System.Windows.Input;
using LibVLCSharp.Shared;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private LibVLC LibVLC;
        
        public void Appearing()
        {
            
            Core.Initialize();
            LibVLC = new LibVLC(true);
            
            var media = new Media(LibVLC, PrepareMedia("test1.mp4"));

            MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };
            media.Dispose();
            MediaPlayer.Play();
        }
        
        private MediaPlayer _mediaPlayer;

        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set
            {
                _mediaPlayer = value;
                OnPropertyChanged(nameof(MediaPlayer));
            }
        }
        
        private static StreamMediaInput PrepareMedia(string media)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"App1.Assets.Media.{media}");
            return new StreamMediaInput(stream);
        }

    }
}