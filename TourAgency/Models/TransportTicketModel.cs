using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class TransportTicketModel
    {
        public int Id { get; set; }
        public string TransportType { get; set; }
        public string DeparturePoint { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public string ArrivalPoint { get; set; }
        public DateTimeOffset ArrivalTime { get; set; }
        public int NumberOfSeat { get; set; }
        public int Price { get; set; }
        public string PassangerName { get; set; }
        public string PassangerSurname { get; set; }
    }
}