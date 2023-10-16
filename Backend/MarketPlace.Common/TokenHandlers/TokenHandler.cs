using MarketPlace.DataTransfer.Dtos;
using MarketPlace.DataTransfer.Dtos.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarketPlace.Common.TokenHandlers
{
    public class TokenHandler
    {
        private readonly IConfiguration _config;
        public TokenHandler(IConfiguration config)
        {
            _config = config;
        }
        public Token CreateAccessToken(LoginPageDto user, List<Claim> claims)
        {
            var token = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.Now.AddMinutes(300);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _config["Token:Issuer"],
                audience: _config["Token:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: claims
           );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            //Token üretiliyor
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreatRefreshToken();
            return token;

        }


        public Token UpdateAccessToken(LoginPageDto user, List<Claim> claims)
        {
            var token = new Token();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:SecurityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.Now.AddMinutes(300);


            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _config["Token:Issuer"],
                audience: _config["Token:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: credentials,
                claims: claims
           );
            var newToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            //Token üretiliyor
            token.AccessToken = newToken;
            token.RefreshToken = CreatRefreshToken();
            return token;
        }

        public string CreatRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
