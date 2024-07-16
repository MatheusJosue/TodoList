using Model;

namespace Infrastructure.Data.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserById(string userId);
        Task<User> GetUserByUserName(string userName);
    }
}