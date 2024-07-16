using Model;

namespace Service.Interface
{
    public interface IAuthService
    {
        Task<User> GetCurrentUser();
        Task<User> GetUserById(string userId);
        Task<User> GetUserByUserName(string username);
    }
}