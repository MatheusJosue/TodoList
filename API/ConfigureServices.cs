using Infrastructure.Data.Repositories.Implementation;
using Infrastructure.Data.Repositories.Interface;
using Infrastructure.Data.Repositories.Interface.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model;
using Service.Implementation;
using Service.Interface;
using System.Text;

namespace API
{
    public static class ConfigureServices
    { 
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            string mySqlConnection = configuration.GetConnectionString("Database") ?? throw new ArgumentException("String de conexão não foi encontrada.");

            services.AddDbContextPool<MySQLContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection), b => b.MigrationsAssembly("API")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MySQLContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],

                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"] ?? throw new ArgumentException("JWT:Secret configuration value is missing."))),

                    ValidateLifetime = true
                };
            });
        }
    }
}
