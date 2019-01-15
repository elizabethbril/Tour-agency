using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TransportPlaceDTO
    {
        public int Id { get; set; }
        public TransportDTO Transport { get; set; }
        public int TransportId { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public bool IsBooked { get; set; }

        public TransportPlaceDTO() { }
        public TransportPlaceDTO(TransportDTO Transport, int Number, int Price)
        {
            this.Transport = Transport;
            this.Number = Number;
            this.Price = Price;
            IsBooked = false;
        }
    }
}