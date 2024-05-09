using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WEATHERREPORT
{
    public partial class MainPage : TabbedPage
    {
        const string API = "552983a2a41dde9c009dbfd542e85b9e";
        public MainPage()
        {
            InitializeComponent();

            DateValue.Text = DateTime.Today.ToLongDateString().ToString();
        }

        private async void SenderButton_Clicked(object sender, EventArgs e)
        {
            string city = CityTextBox.Text.Trim();

            if (city.Length < 2)
            {
                await DisplayAlert("Error", "City have most biggest name", "Okay");
                return;
            }

            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API}&units=metric";
            string response = await client.GetStringAsync(url);

            var json = JObject.Parse(response);
            int temp = Convert.ToInt32(json["main"]["temp"]);

            CityValue.Text = city.ToString();
            WeatherValue.Text = temp.ToString() + "°C";
            CityTextBox.Text = "";


        }
    }
}
