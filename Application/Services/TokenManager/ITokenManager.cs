using Application.Services.TokenManager.Dto;
using Application.Services.User.Dto;

namespace FitnessBattle.TokenManager
{
    public interface ITokenManager
    {
        public int GetIdFromToken(string token);
        public string GenerateJwtToken(OutputDtoQueryUser user);
        public string GetNameFromToken(string token);
        public string GetEmailFromToken(string token);
        public string GetRoleFromToken(string token);
        public OutputDtoTokenUser GetUserFromToken(string token);
    }
}