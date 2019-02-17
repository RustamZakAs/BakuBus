using BakuBusX.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BakuBusX
{
    public partial class MainPage : ContentPage
    {
        string appName = "BakuBusX";
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Go_Map_Clicked(object sender, EventArgs e)
        {
            BUSAPI bus = new BUSAPI();
            bus.GetBusAPI();

            if (bus.BUS != null)
            {
                string lat = bus.BUS.Attributes[0].LATITUDE.ToString();
                string lon = bus.BUS.Attributes[0].LONGITUDE.ToString();
                await DisplayAlert(appName, lat + " " + lon, "Cancel");
            }
            else
            {
                await DisplayAlert(appName, "Error", "Cancel");
            }

            
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
