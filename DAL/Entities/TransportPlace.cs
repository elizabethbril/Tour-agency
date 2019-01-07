using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Entities
{
    public class TransportPlace
    {
        public int Id { get; set; }
        [ForeignKey("TransportId")]
        public virtual Transport Transport { get; set; }
        public int TransportId { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public bool IsBooked { get; set; }
    }
}