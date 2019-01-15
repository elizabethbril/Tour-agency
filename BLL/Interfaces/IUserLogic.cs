using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserLogic
    {
        void AddUser(UserDTO NewUser);
        Task AddUserAsync(UserDTO NewUser);
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO GetUser(int Id);
        void DeleteUser(int Id);
        void EditUser(int Id, UserDTO User);
        UserDTO Login(string Login, string Password);
        void ReserveTour(int UserId, int TourId);
        void ReserveTicket(int UserId, int TransportId, int SeatNumber);
    }
}
