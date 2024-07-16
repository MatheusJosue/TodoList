using Infrastructure.Data.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Model;
using Service.Interface;

namespace Service.Implementation
{
    public class AuthService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : IAuthService
    {
        public async Task<User> GetCurrentUser()
        {
            var userId = userManager.GetUserId(httpContextAccessor.HttpContext.User) ?? throw new ArgumentException("Id do usuário não encontrado.");
            return await userRepository.GetUserById(userId);
        }

        public async Task<User> GetUserById(string userId)
        {
            User user = await userRepository.GetUserById(userId);
            return user ?? throw new ArgumentException("Usuario não encontrado");
        }

        public async Task<User> GetUserByUserName(string username)
        {
            User user = await userRepository.GetUserByUserName(username);
            return user ?? throw new ArgumentException("Usuário não encontrado");
        }
    }
}
