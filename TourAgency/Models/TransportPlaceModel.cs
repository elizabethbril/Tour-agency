using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public class TransportPlaceModel
    {
        public int Id { get; set; }
        [ForeignKey("TransportId")]
        public virtual TransportModel Transport { get; set; }
        public int TransportId { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public bool IsBooked { get; set; }
    }
}