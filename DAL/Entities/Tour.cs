using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
    }
}
