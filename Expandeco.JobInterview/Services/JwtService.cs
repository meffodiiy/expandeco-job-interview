using Expandeco.JobInterview.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Expandeco.JobInterview.Services
{
    public interface IJwtService
    {
        string Authenticate(int id);
    }

    public class JwtService : IJwtService
    {
        private readonly IConfiguration Configuration;
        private readonly ApplicationDbContext _dbContext;

        public JwtService(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            Configuration = configuration;
            _dbContext = dbContext;
        }


        public string Authenticate(int id)
        {
            var user = _dbContext.Users.Find(id);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.TypeId.ToString())
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "Issuer",
                Audience = "Audience"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
