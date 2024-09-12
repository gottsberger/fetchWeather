using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoloc_util.GeoCodingAPI.GeoCodingAPIModels
{
    internal class LocationResponse
    {
        public string? zip { get; set; }
        public string? name { get; set; }

        public Local_Names? local_names { get; set; }

        public string? state { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }
        public string? country { get; set; }
        public string? cod { get; set; }
        public string? message { get; set; }
    }

    public class Local_Names
    {
        public string? en { get; set; }
    }
}