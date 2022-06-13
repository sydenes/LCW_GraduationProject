using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Application.ViewModels.Users
{
    public class AccessToken
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public static AccessToken CreateAccessToken(string userId) //string secret
        {
            try
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mySecretKeymySecretKeymySecretKey"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "www.vestiyer.com",
                    audience: "vestiyer/user",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return new AccessToken { Token = tokenString, UserId=userId };
            }
            catch (Exception exp)
            {
                return null;
            }
        }
    }
}
