using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FoodFinder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnLaunchMap_Click(object sender, RoutedEventArgs e)
        {
            string genre = (cbxGenre.SelectedItem as ComboBoxItem).Content.ToString();
            string trafficValue = (ckbTraffic.IsChecked.Value) ? "1" : "0";

            string uriString = string.Format($"bingmaps:?q={genre}&where={txtLocation.Text}&lvl=15&trfc={trafficValue}");

            Uri uri = new Uri(uriString);
            await Launcher.LaunchUriAsync(uri);

        }

        private async void btnSearchMusic_Click(object sender, RoutedEventArgs e)
        {
            //ms-windows-store://search/?query=Bayonne&type=Songs
            string uriString = string.Format($"ms-windows-store://search/?query={txtLocation.Text}&type=Songs");

            Uri uri = new Uri(uriString);
            await Launcher.LaunchUriAsync(uri);

        }

        private async void btnSearchWeb_Click(object sender, RoutedEventArgs e)
        {
            string genre = (cbxGenre.SelectedItem as ComboBoxItem).Content.ToString();
            string queryString = Uri.EscapeDataString($"{genre} in {txtLocation.Text}");
            var searchUri = $"https://www.bing.com/search?q={queryString}";

            var uriBing = new Uri(searchUri);

            var promptOptions = new Windows.System.LauncherOptions();
            promptOptions.TreatAsUntrusted = true;
            promptOptions.DisplayApplicationPicker = true;
            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);

        }
    }
}
