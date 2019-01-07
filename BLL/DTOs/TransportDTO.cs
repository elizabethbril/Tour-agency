using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TransportDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string DeparturePoint { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public string ArrivalPoint { get; set; }
        public DateTimeOffset ArrivalTime { get; set; }
        public virtual List<TransportPlaceDTO> TransportPlaces { get; set; }

        public TransportDTO() { }
        public TransportDTO(string Type, string DeparturePoint, DateTimeOffset DepartureTime, string ArrivalPoint, DateTimeOffset ArrivalTime)
        {
            this.Type = Type;
            this.DeparturePoint = DeparturePoint;
            this.DepartureTime = DepartureTime;
            this.ArrivalPoint = ArrivalPoint;
            this.ArrivalTime = ArrivalTime;
            TransportPlaces = new List<TransportPlaceDTO>();
        }
    }
}
