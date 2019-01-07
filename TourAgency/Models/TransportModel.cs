using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class TransportModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string DeparturePoint { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public string ArrivalPoint { get; set; }
        public DateTimeOffset ArrivalTime { get; set; }
        public virtual List<TransportPlaceModel> TransportPlaces { get; set; }
    }
}