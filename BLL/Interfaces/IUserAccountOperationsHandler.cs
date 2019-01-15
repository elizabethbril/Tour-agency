using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IUserAccountOperationsHandler : IDisposable
    {
        void AddUserAccount(UserDTO userAccount);
        Task AddUserAccountAsync(UserDTO userAccount);
        void ChangeUserAccount(string userEmail, UserDTO newUserAccount);
        Task ChangeUserAccountAsync(string userEmail, UserDTO newUserAccount);
        void DeleteUserAccount(string userEmail, string hostingEnvironmentPath, string requestUriLeftPart);
        Task DeleteUserAccountAsync(string userEmail, string hostingEnvironmentPath, string requestUriLeftPart);
        UserDTO GetUserAccount(string userEmail);
        Task<UserDTO> GetUserAccountAsync(string userEmail);
        UserDTO GetSellerUser(int tourId);
        Task<UserDTO> GetSellerUserAsync(int tourId);
        UserDTO GetBuyerUser(int tourId);
        Task<UserDTO> GetBuyerUserAsync(int tourId);
        IQueryable<UserDTO> GetAllUserAccounts();
        Task<IQueryable<UserDTO>> GetAllUserAccountsAsync();
    }
}
