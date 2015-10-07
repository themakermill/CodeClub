using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

            loadWeather();
        }

        private async void getWeather_Click(object sender, RoutedEventArgs e)
        {
            if (cityList.SelectedIndex > -1)
            {
                string selectedItem = cityList.SelectedItem.ToString();

                RootObject myWeather = await OpenWeatherMapProxy.GetWeather(selectedItem);

                string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);

                weatherImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                weatherText.Text = myWeather.name + " - " + ((int)myWeather.main.temp).ToString() + " - " + myWeather.weather[0].description;
            }
        }

        private async void loadWeather()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61482/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/citys");

                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();

                    List<City> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<City>>(resp);

                    foreach (City city in list)
                    {
                        cityList.Items.Add(city.Name + ", " + city.State); 
                    }
                }
            }
        }
    }
}
