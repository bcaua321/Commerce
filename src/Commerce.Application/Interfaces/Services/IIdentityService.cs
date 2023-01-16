using Commerce.Application.Transfers.Requests;
using Commerce.Application.Transfers.Responses;

namespace Commerce.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        public Task<UserRegisterResponse> RegisterUser(UserRegisterRequest user);
        public Task<UserLoginResponse> Login(UserLoginRequest user);
    }
}
