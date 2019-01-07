using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TransportTicket
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

        public TransportTicket() { }
        public TransportTicket(TransportPlace TransportPlace, string PassangerName, string PassangerSurname)
        {
            TransportType = TransportPlace.Transport.Type;
            DeparturePoint = TransportPlace.Transport.DeparturePoint;
            DepartureTime = TransportPlace.Transport.DepartureTime;
            ArrivalPoint = TransportPlace.Transport.ArrivalPoint;
            ArrivalTime = TransportPlace.Transport.ArrivalTime;
            NumberOfSeat = TransportPlace.Number;
            Price = TransportPlace.Price;
            this.PassangerName = PassangerName;
            this.PassangerSurname = PassangerSurname;
        }
    }
}
