using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourAgency.Models
{
    public enum UserType { Administrator, Manager, User }
    public class UserModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string TelephoneNumber { get; set; }
        public List<TourModel> Tours { get; set; }
        public List<TransportTicketModel> TransportTickets { get; set; }
    }
}