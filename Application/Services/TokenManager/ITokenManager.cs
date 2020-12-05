using Application.Services.User.Dto;

namespace FitnessBattle.TokenManager
{
    public interface ITokenManager
    {
        public int GetIdFromToken(string token);
        public string GenerateJwtToken(OutputDtoQueryUser user);
    }
}