using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Application.Services.TokenManager;
using Application.Services.TokenManager.Dto;
using NUnit.Framework;

namespace NUnitTestCases.Application
{
    [TestFixture]
    public class TokenManagerTest
    {
        private TokenManager _tokenManager = new TokenManager();
        private JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();

        private static string GetToken()
        {
            return
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiIsImV4cCI6MTYwODEzMjA5MCwiaXNzIjoiRml0bmVzc0JhdHRsZSIsImF1ZCI6IkZpdG5lc3NCYXR0bGUifQ.pLLojw9iQzHYut78j0sXjuc3Fw9wddMYuOWQGMR3HmE";
        }

        [Test]
        public void GetIdFromToken_token_AreSame()
        {
            var token = GetToken();

            var res = _tokenManager.GetIdFromToken(token);
            
            var tokenBody = _handler.ReadJwtToken(token);
            
            var expected = int.Parse((tokenBody.Claims.Where(c =>c.Type == ClaimTypes.NameIdentifier)).First().Value);
            
            Assert.AreEqual(expected,res);
        }
        
        [Test]
        public void GetNameFromToken_token_AreSame()
        {
            var token = GetToken();

            var res = _tokenManager.GetNameFromToken(token);
            
            var tokenBody = _handler.ReadJwtToken(token);
            
            var expected =(tokenBody.Claims.Where(c =>c.Type == ClaimTypes.Name)).First().Value;
            
            Assert.AreEqual(expected,res);
        }
        
        [Test]
        public void GetEmailFromToken_token_AreSame()
        {
            var token = GetToken();

            var res = _tokenManager.GetEmailFromToken(token);
            
            var tokenBody = _handler.ReadJwtToken(token);
            
            var expected = (tokenBody.Claims.Where(c =>c.Type == ClaimTypes.Email)).First().Value;
            
            Assert.AreEqual(expected,res);
        }
        
        [Test]
        public void GetRoleFromToken_token_AreSame()
        {
            var token = GetToken();

            var res = _tokenManager.GetRoleFromToken(token);
            
            var tokenBody = _handler.ReadJwtToken(token);
            
            var expected = (tokenBody.Claims.Where(c =>c.Type == ClaimTypes.Role)).First().Value;
            
            Assert.AreEqual(expected,res);
        }
        
        [Test]
        public void GetUserFromToken_token_AreSame()
        {
            var token = GetToken();

            var res = _tokenManager.GetUserFromToken(token);

            var expected = new OutputDtoTokenUser("admin","admin@gmail.com","admin");
            
            Assert.AreEqual(expected,res);
        }
        
        
        
        
    }
}