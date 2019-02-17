using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;

namespace BakuBusX.Services
{
    class BUSAPI
    {
        [JsonProperty("BUS")]
        public BusAPI BUS { get; set; }

        public BUSAPI GetBusAPI()
        {
            BUSAPI buss = new BUSAPI();
            string info = string.Empty;

            try
            {
                info = new WebClient().DownloadString("https://www.bakubus.az/az/ajax/apiNew1");
                buss = JsonConvert.DeserializeObject<BUSAPI>(info);
            }
            catch (Exception)
            {

                //throw;
            }
            BUS = buss.BUS;
            return buss;
        }
    }

    class BusAPI
    {
        [JsonProperty("@attributes")]
        public ObservableCollection<Attributes> Attributes { get; set; }
    }

    class Attributes
    {
        public int BUS_ID { get; set; }
        public string PLATE { get; set; }
        public string DRIVER_NAME { get; set; }
        public string CURRENT_STOP { get; set; }
        public string PREV_STOP { get; set; }
        public int SPEED { get; set; }
        public string BUS_MODEL { get; set; }
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
        public string ROUTE_NAME { get; set; }
        public uint LAST_UPDATE_TIME { get; set; }
        public int DISPLAY_ROUTE_CODE { get; set; }
        public int SVCOUNT { get; set; }
    }
}
