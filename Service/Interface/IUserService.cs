using Model.DTO;
using Model.JWT;

namespace Service.Interface
{
    public interface IUserService
    {
        Task<SsoDTO> SignIn(LoginModel signInDTO);
        Task<bool> SignUp(RegisterModel signUpDTO);
    }
}