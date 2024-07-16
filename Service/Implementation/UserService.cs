using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.DTO;
using Model.JWT;
using Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Service.Implementation
{
    public class UserService(UserManager<User> userManager, IConfiguration configuration) : IUserService
    {
        public async Task<bool> SignUp(RegisterModel signUpDTO)
        {
            var userExists = await userManager.FindByNameAsync(signUpDTO.Username);
            if (userExists != null)
                throw new ArgumentException("Username já existe!");

            userExists = await userManager.FindByEmailAsync(signUpDTO.Email);
            if (userExists != null)
                throw new ArgumentException("Email já existe!");

            User user;

            user = new User(signUpDTO.Username, signUpDTO.Email, signUpDTO.Password)
            {
                Email = signUpDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = signUpDTO.Username
            };

            var result = await userManager.CreateAsync(user, signUpDTO.Password);

            if (!result.Succeeded)
                throw new ArgumentException("Cadastro do usuário falhou.");

            _ = await userManager.FindByNameAsync(signUpDTO.Username) ?? throw new ArgumentException("Usuário não encontrado.");

            return true;
        }

        public async Task<SsoDTO> SignIn(LoginModel signInDTO)
        {
            var user = await userManager.FindByNameAsync(signInDTO.Username) ?? throw new ArgumentException("Usuário não encontrado.");
            if (!await userManager.CheckPasswordAsync(user, signInDTO.Password))
                throw new ArgumentException("Senha inválida.");

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new SsoDTO(new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo, user);
        }
    }
}
