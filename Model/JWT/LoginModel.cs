using System.ComponentModel.DataAnnotations;

namespace Model.JWT
{
    public class LoginModel
    {
        public LoginModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
