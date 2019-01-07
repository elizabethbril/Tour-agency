using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public enum UserType { Administrator, Manager, User }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string TelephoneNumber { get; set; }
        public virtual List<Tour> Tours { get; set; }
        public virtual List<TransportTicket> TransportTickets { get; set; }
    }
}