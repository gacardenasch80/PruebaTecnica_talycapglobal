using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica_talycapglobal.Data.Model;
using PruebaTecnica_talycapglobal.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_talycapglobal.Authorization
{
    public class Jwt : IJwt
    {
        private readonly AppSettings _appSettings;
        /// <summary>
        /// Constructor de la clase Jwt
        /// </summary>
        /// <param name="appSettings">Cadena de conexion</param>
        public Jwt(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        /// <summary>
        /// Funcion que obtiene el token con jwt
        /// </summary>
        /// <param name="user">Objeto user</param>
        /// <returns>string con token</returns>
        public string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Password)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
