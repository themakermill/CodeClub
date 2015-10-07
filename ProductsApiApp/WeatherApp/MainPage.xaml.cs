using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace WeatherApp
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

        private async void getWeather_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ListViewItem)cityList.SelectedItem;
            
            RootObject myWeather = await OpenWeatherMapProxy.GetWeather(selectedItem.Content.ToString());

            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);

            weatherImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            weatherText.Text = myWeather.name + " - " + ((int)myWeather.main.temp).ToString() + " - " + myWeather.weather[0].description;
        }
    }
}
