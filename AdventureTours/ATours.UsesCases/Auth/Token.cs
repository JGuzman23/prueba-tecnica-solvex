using ATours.UseCasesDtos.Auth;
using ATours.UseCasesPorts.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ATours.UseCases.Auth
{
    public class Token: IToken
    {
        readonly IConfiguration _configuration;
        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task GenerateToken(AuthDto dto)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            var claims = new List<Claim>
            {
                new Claim("id", dto.Id.ToString()),
                new Claim("name", dto.Name.ToString()),
                new Claim("email", dto.Email.ToString()),


            };


            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Issuer"],
                claims,
                DateTime.Now, DateTime.UtcNow.AddMonths(1)
            //DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["Authentication:Hour"]))
            );

            var token = new JwtSecurityToken(header, payload);
            dto.Token = await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
