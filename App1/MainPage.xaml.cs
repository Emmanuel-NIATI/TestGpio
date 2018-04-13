using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources.Core;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private GpioController _gpc;
        private GpioPin _pin18;
        private GpioPin _pin23;
        private GpioPin _pin24;
        private GpioPin _pin25;
        private GpioPin _pin12;
        private GpioPin _pin16;
        private GpioPin _pin20;

        private MediaPlayer mediaPlayerNoir;
        private MediaPlayer mediaPlayerGris;
        private MediaPlayer mediaPlayerBlanc;
        private MediaPlayer mediaPlayerRouge;
        private MediaPlayer mediaPlayerVert;
        private MediaPlayer mediaPlayerBleu;
        private MediaPlayer mediaPlayerJaune;

        public MainPage()
        {

            this.InitializeComponent();

            this.travauxTimer();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            _gpc = GpioController.GetDefault();

            // Bouton Noir sur GPIO18 (broche 12)
            _pin18 = _gpc.OpenPin(18);
            _pin18.SetDriveMode(GpioPinDriveMode.Input);

            mediaPlayerNoir = new MediaPlayer();

            // Bouton Gris sur GPIO23 (broche 16)
            _pin23 = _gpc.OpenPin(23);
            _pin23.SetDriveMode(GpioPinDriveMode.Input);

            mediaPlayerGris = new MediaPlayer();

            // Bouton Blanc sur GPIO24 (broche 18)
            _pin24 = _gpc.OpenPin(24);
            _pin24.SetDriveMode(GpioPinDriveMode.Input);

            mediaPlayerBlanc = new MediaPlayer();

            // Bouton Rouge sur GPIO25 (broche 22)
            _pin25 = _gpc.OpenPin(25);
            _pin25.SetDriveMode(GpioPinDriveMode.Input);

            mediaPlayerRouge = new MediaPlayer();
            mediaPlayerRouge.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/cloche.mp3"));

            // Bouton Vert sur GPIO12 (broche 32)
            _pin12 = _gpc.OpenPin(12);
            _pin12.SetDriveMode(GpioPinDriveMode.Input);

            mediaPlayerVert = new MediaPlayer();

            // Bouton Bleu sur GPIO16 (broche 36)
            _pin16 = _gpc.OpenPin(16);
            _pin16.SetDriveMode(GpioPinDriveMode.Input);

            mediaPlayerBleu = new MediaPlayer();

            // Bouton Jaune sur GPIO20 (broche 38)
            _pin20 = _gpc.OpenPin(20);
            _pin20.SetDriveMode(GpioPinDriveMode.Input);

            mediaPlayerJaune = new MediaPlayer();
        }

        private void travauxTimer()
        {

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        private async void dispatcherTimer_Tick(object sender, object e)
        {

            // Bouton Noir
            if (_pin18.Read() == GpioPinValue.High)
            {

                MediaElement mediaElement = new MediaElement();
                var synth = new SpeechSynthesizer();
                SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Salinger");
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();

                string html = @"<iframe src=""https://www.youtube.com/embed/2SXKukJN8HM"" width=""560"" height=""315"" allow=""autoplay; encrypted - media"" frameborder=""0""></iframe>";

                this.Navigateur.NavigateToString(html);

            }

            // Bouton Gris
            if (_pin23.Read() == GpioPinValue.High)
            {

                MediaElement mediaElement = new MediaElement();
                var synth = new SpeechSynthesizer();
                SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Oracle");
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();

                this.Navigateur.Source = new Uri("https://www.boursorama.com/cours/ORCL/");

            }

            // Bouton Blanc
            if (_pin24.Read() == GpioPinValue.High)
            {

                MediaElement mediaElement = new MediaElement();
                var synth = new SpeechSynthesizer();
                SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Justine !!!");
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
            }

            // Bouton Rouge
            if ( _pin25.Read() == GpioPinValue.High )
            {

                MediaElement mediaElement = new MediaElement();
                var synth = new SpeechSynthesizer();
                SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Justine !!!");
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();

                mediaPlayerRouge.Play();
            }

            // Bouton Vert
            if (_pin12.Read() == GpioPinValue.High)
            {

                MediaElement mediaElement = new MediaElement();
                var synth = new SpeechSynthesizer();
                SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Justine !!!");
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
            }

            // Bouton Bleu
            if (_pin16.Read() == GpioPinValue.High)
            {

                MediaElement mediaElement = new MediaElement();
                var synth = new SpeechSynthesizer();
                SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Microsoft");
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();

                this.Navigateur.Source = new Uri("https://www.boursorama.com/cours/MSFT/");
            }

            // Bouton Jaune
            if (_pin20.Read() == GpioPinValue.High)
            {

                MediaElement mediaElement = new MediaElement();
                var synth = new SpeechSynthesizer();
                SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Yellow");
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
            }


        }

        /*
        private void Noir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Gris_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Blanc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rouge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Vert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bleu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Jaune_Click(object sender, RoutedEventArgs e)
        {

        }
         */




    }
}
