using Application.Services.User.Dto;

namespace Application.Services.Auth
{
    public interface IAuthService
    {
        OutputDtoAuthUser Login(InputDtoAuthUser user);
    }
}