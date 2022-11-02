using TestApiJwt.Model;

namespace TestApiJwt.services
{
    public interface IuthoService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(LoginModel model);
    }
}
