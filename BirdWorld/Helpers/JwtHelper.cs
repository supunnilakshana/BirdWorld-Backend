using BirdWorld.Config;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BirdWorld.Helpers
{
    public class JwtHelper
    {
        public String createToken()
        {

            var claims = new[] {
                new Claim("FullName","Kusum Dasa"),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub,"uuid"),

                };

            var keybytes = Encoding.UTF8.GetBytes(JwtConfig.Secrete_Key);

            var key = new SymmetricSecurityKey(keybytes);

            var signinCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
                (
                  JwtConfig.Audience,
                  JwtConfig.Audience,
                  claims: claims,
                  notBefore: DateTime.Now,
                  expires: DateTime.Now.AddDays(1),
                  signinCredential

                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            return tokenString;

        }









    }
}
