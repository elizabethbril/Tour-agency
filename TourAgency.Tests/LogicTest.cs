using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using DAL;
using BLL.Logics;
using Ninject;
using Ninject.Modules;
using DAL.UnitOfWork;
using BLL.DTOs.Exceptions;

namespace TourAgency.Tests
{
    [TestFixture]
    public class LogicTest
    {
        [Test]
        public void AddingTransport()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var TransportLogic = new TransportLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");

            TransportLogic.AddTransport(new BLL.DTOs.TransportDTO("Bus", "Kyiv", DateTimeOffset.Parse("22.10.18 11:15"), "Krakow", DateTimeOffset.Parse("22.10.18 23:45")), 30, 150);

            var Transport = TransportLogic.GetAllTransport().ToList()[0];

            Assert.That(TransportLogic.GetAllTransport().Count() == 1);
            Assert.That(Transport.Type == "Bus");
            Assert.That(Transport.DeparturePoint == "Kyiv");
            Assert.That(Transport.DepartureTime == DateTimeOffset.Parse("22.10.18 11:15"));
            Assert.That(Transport.ArrivalPoint == "Krakow");
            Assert.That(Transport.ArrivalTime == DateTimeOffset.Parse("22.10.18 23:45"));
            Assert.That(Transport.TransportPlaces.Count == 30);
            Assert.That(Transport.TransportPlaces[0].Number == 1);
            Assert.That(Transport.TransportPlaces[0].Price == 150);
            Assert.That(Transport.TransportPlaces[0].Transport.Id == Transport.Id);

        }

        [Test]
        public void DeletingTransport()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var TransportLogic = new TransportLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");

            TransportLogic.AddTransport(new BLL.DTOs.TransportDTO("Bus", "Kyiv", DateTimeOffset.Parse("22.10.18 11:15"), "Krakow", DateTimeOffset.Parse("22.10.18 23:45")), 30, 150);
            var Transport = TransportLogic.GetAllTransport().ToList()[0];

            Assert.That(TransportLogic.GetAllTransport().Count() == 1);

            TransportLogic.DeleteTransport(1);

            Assert.That(TransportLogic.GetAllTransport().Count() == 0);

        }

        [Test]
        public void AddingTour()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var TourLogic = new TourLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");

            TourLogic.AddTour(new BLL.DTOs.TourDTO("Krakow tour", 250, "Excursion", "Poland", "Krakow", 3, "The best tour to Krakow"));

            var Tour = TourLogic.GetAllToursTemplates().ToList()[0];

            Assert.That(TourLogic.GetAllToursTemplates().Count() == 1);
            Assert.That(Tour.Name == "Krakow tour");
            Assert.That(Tour.Price == 250);
            Assert.That(Tour.Type == "Excursion");
            Assert.That(Tour.Country == "Poland");
            Assert.That(Tour.City == "Krakow");
            Assert.That(Tour.Duration == 3);
            Assert.That(Tour.Description == "The best tour to Krakow");
        }

        [Test]
        public void EditingTour()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var TourLogic = new TourLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");

            TourLogic.AddTour(new BLL.DTOs.TourDTO("Krakow tour", 250, "Excursion", "Poland", "Krakow", 3, "The best tour to Krakow"));

            var Tour = TourLogic.GetAllToursTemplates().ToList()[0];

            Assert.That(TourLogic.GetAllToursTemplates().Count() == 1);
            Assert.That(Tour.Name == "Krakow tour");
            Assert.That(Tour.Price == 250);
            Assert.That(Tour.Type == "Excursion");
            Assert.That(Tour.Country == "Poland");
            Assert.That(Tour.City == "Krakow");
            Assert.That(Tour.Duration == 3);
            Assert.That(Tour.Description == "The best tour to Krakow");

            Tour.City = "Lviv";
            Tour.Description = "Kek";

            TourLogic.EditTour(Tour.Id, Tour);

            Tour = TourLogic.GetAllToursTemplates().ToList()[0];

            Assert.That(TourLogic.GetAllToursTemplates().Count() == 1);
            Assert.That(Tour.Name == "Krakow tour");
            Assert.That(Tour.Price == 250);
            Assert.That(Tour.Type == "Excursion");
            Assert.That(Tour.Country == "Poland");
            Assert.That(Tour.City == "Lviv");
            Assert.That(Tour.Duration == 3);
            Assert.That(Tour.Description == "Kek");
        }

        [Test]
        public void DeletingTour()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var TourLogic = new TourLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");

            TourLogic.AddTour(new BLL.DTOs.TourDTO("Krakow tour", 250, "Excursion", "Poland", "Krakow", 3, "The best tour to Krakow"));

            var Tour = TourLogic.GetAllToursTemplates().ToList()[0];

            Assert.That(TourLogic.GetAllToursTemplates().Count() == 1);

            TourLogic.DeleteTour(1);

            Assert.That(TourLogic.GetAllToursTemplates().Count() == 0);
        }

        [Test]
        public void FindingTour()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var TourLogic = new TourLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");

            TourLogic.AddTour(new BLL.DTOs.TourDTO("Krakow tour", 250, "Excursion", "Poland", "Krakow", 3, "The best tour to Krakow"));
            TourLogic.AddTour(new BLL.DTOs.TourDTO("Poznan tour", 150, "Excursion", "Poland", "Poznan", 3, "The best tour to Poznan"));
            TourLogic.AddTour(new BLL.DTOs.TourDTO("Morskie Oko", 340, "All", "Poland", "Morskie Oko", 2, "The best tour to mountains"));
            TourLogic.AddTour(new BLL.DTOs.TourDTO("Vancouver", 1890, "Excursion", "Canada", "Vancouver", 10, "The best tour to Vancouver"));
            TourLogic.AddTour(new BLL.DTOs.TourDTO("Lviv", 150, "Hot", "Ukraine", "Lviv", 3, "The best tour to Lviv"));
            TourLogic.AddTour(new BLL.DTOs.TourDTO("Karpaty", 500, "Hot", "Ukraine", "Karpaty", 10, "Very nice mountains tour"));

            Assert.That(TourLogic.GetAllToursTemplates().Count() == 6);

            Assert.That(TourLogic.FindTourTemplates("Hot").Count() == 2);
            Assert.That(TourLogic.FindTourTemplates("Excursion").Count() == 3);
            Assert.That(TourLogic.FindTourTemplates("Error").Count() == 0);
            Assert.That(TourLogic.FindTourTemplates("Excursion").ToList()[0].City == "" + "Krakow");

            Assert.That(TourLogic.FindTourTemplates("Poland").Count() == 3);
            Assert.That(TourLogic.FindTourTemplates("Ukraine").Count() == 2);
            Assert.That(TourLogic.FindTourTemplates("Error").Count() == 0);
            Assert.That(TourLogic.FindTourTemplates("Canada").ToList()[0].City == "Vancouver");

            Assert.That(TourLogic.FindTourTemplates("Ukraine").Count() == 2);
            Assert.That(TourLogic.FindTourTemplates("Vancouver").Count() == 1);
            Assert.That(TourLogic.FindTourTemplates("Error").Count() == 0);

            Assert.That(TourLogic.FindTourTemplatesByDuration(1, 3).Count() == 4);
            Assert.That(TourLogic.FindTourTemplatesByDuration(10, 10).Count() == 2);
            Assert.That(TourLogic.FindTourTemplatesByDuration(1000000, 10000000).Count() == 0);
            Assert.That(TourLogic.FindTourTemplatesByDuration(10, 20).ToList()[0].Country == "Canada");
            
            Assert.That(TourLogic.FindTourTemplatesByPrice(250, 250).Count() == 1);
            Assert.That(TourLogic.FindTourTemplatesByPrice(250, 340).Count() == 2);
            
        }

        [Test]
        public void AddingUser()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.User, "Bril", "Login", "Password"));

            Assert.That(UserLogic.GetAllUsers().Count() == 1);
            Assert.That(UserLogic.GetAllUsers().ToList()[0].Name == "Liza");
            Assert.That(UserLogic.GetAllUsers().ToList()[0].Surname == "Bril");
            Assert.That(UserLogic.GetAllUsers().ToList()[0].UserType == BLL.DTOs.UserType.User);
            Assert.That(UserLogic.GetAllUsers().ToList()[0].Login == "Login");
            Assert.That(UserLogic.GetAllUsers().ToList()[0].Password == "Password");
        }

        [Test]
        public void DeletingUser()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.Manager, "Bril", "Login", "Password"));

            Assert.That(UserLogic.GetAllUsers().Count() == 1);

            UserLogic.DeleteUser(1);

            Assert.That(UserLogic.GetAllUsers().Count() == 0);
        }

        [Test]
        public void LoggingIn()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.Manager, "Bril", "Login", "Password"));

            Assert.That(UserLogic.Login("Login", "Password").Id == UserLogic.GetAllUsers().ToList()[0].Id);
            Assert.Throws<InvalidLoginPasswordCombinationException>(delegate { UserLogic.Login("Wrong", "Password"); });
        }


        [Test]
        public void ReservingTicket()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var UserLogic = new UserLogic(UoW.Object);
            var TransportLogic = new TransportLogic(UoW.Object);

            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.User, "Bril", "Login", "Password"));
            TransportLogic.AddTransport(new BLL.DTOs.TransportDTO("Bus", "Kyiv", DateTimeOffset.Parse("22.10.18 11:15"), "Krakow", DateTimeOffset.Parse("22.10.18 23:45")), 30, 150);

            UserLogic.ReserveTicket(1, 1, 1);

            var User = UserLogic.GetAllUsers().First(u => u.Id == 1);

            //Assert.That(User.TransportTickets.Count == 1);
            //Assert.That(User.TransportTickets[0].TransportType == "Bus");
            //Assert.That(User.TransportTickets[0].PassangerName == "Liza");
            //Assert.That(User.TransportTickets[0].PassangerSurname == "Bril");
            //Assert.That(User.TransportTickets[0].NumberOfSeat == 1);
            //Assert.That(User.TransportTickets[0].DeparturePoint == "Kyiv");
            //Assert.That(User.TransportTickets[0].DepartureTime == DateTimeOffset.Parse("22.10.18 11:15"));
            //Assert.That(User.TransportTickets[0].ArrivalPoint == "Krakow");
            //Assert.That(User.TransportTickets[0].ArrivalTime == DateTimeOffset.Parse("22.10.18 23:45"));
            //Assert.That(User.TransportTickets[0].Price == 150);

            Assert.That(TransportLogic.GetAllTransport().First(t => t.Id == 1).TransportPlaces.First(r => r.Id == 1).IsBooked);
            Assert.Throws<AlreadyBookedItemException>(delegate { UserLogic.ReserveTicket(1, 1, 1); });
        }

        [Test]
        public void ReservingTour()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var TourLogic = new TourLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            TourLogic.AddTour(new BLL.DTOs.TourDTO("Krakow tour", 250, "Excursion", "Poland", "Krakow", 3, "The best tour to Krakow"));
            UserLogic.AddUser(new BLL.DTOs.UserDTO("Liza", BLL.DTOs.UserType.Manager, "Bril", "Login", "Password"));

            UserLogic.ReserveTour(1, 1);

            var User = UserLogic.GetAllUsers().First(u => u.Id == 1);

            Assert.That(User.Tours.Count() == 1);
            Assert.That(User.Tours[0].Name == "Krakow tour");
            Assert.That(User.Tours[0].Price == 250);
            Assert.That(User.Tours[0].Type == "Excursion");
            Assert.That(User.Tours[0].Country == "Poland");
            Assert.That(User.Tours[0].City == "Krakow");
            Assert.That(User.Tours[0].Duration == 3);
            Assert.That(User.Tours[0].Description == "The best tour to Krakow");
        }
    }

}