using Microsoft.AspNetCore.Identity;

namespace Model
{
    public class User : IdentityUser
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        public User(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
