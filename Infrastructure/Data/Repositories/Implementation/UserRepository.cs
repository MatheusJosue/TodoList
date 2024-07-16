using Infrastructure.Data.Repositories.Interface;
using Infrastructure.Data.Repositories.Interface.Context;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Infrastructure.Data.Repositories.Implementation
{
    public class UserRepository(MySQLContext context) : IUserRepository
    {
        public async Task<User> GetUserByUserName(string userName)
        {
            return await context.User.Where(x => x.UserName == userName).FirstOrDefaultAsync() ?? throw new ArgumentException("Usuário não encontrado.");
        }

        public async Task<User> GetUserById(string userId)
        {
            return await context.User.FindAsync(userId) ?? throw new ArgumentException("Usuário não encontrado.");
        }
    }
}
