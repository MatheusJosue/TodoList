using System.ComponentModel.DataAnnotations;

namespace Model.JWT
{
    public class RegisterModel(string username, string email, string password)
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = username;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = email;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = password;

    }
}
