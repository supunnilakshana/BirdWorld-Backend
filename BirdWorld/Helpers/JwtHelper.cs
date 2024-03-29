﻿using BirdWorld.Config;
using BirdWorld.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BirdWorld.Helpers
{
    public class JwtHelper
    {
        public String createToken(AppUser appUser,String role)
        {

            var claims = new[] {
                new Claim("FullName",appUser.FirstName+appUser.LastName),
                new Claim(JwtRegisteredClaimNames.NameId,appUser.Id),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.UniqueName,appUser.UserName),
                new Claim(ClaimTypes.Role,role),
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
                  expires: DateTime.Now.AddDays(20),
                  signinCredential

                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;

        }









    }
}
