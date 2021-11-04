using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PracticaCore.Models.DAO;
using PracticaCore.Models.DTO;
using PracticaCore.Models.ObjectValues;
using PracticaCore.Models.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCore.Models.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }
        public UserResponse Auth(AuthRequest model)
        {
            UsuarioDAO usuario = new UsuarioDAO();
            UserResponse response = new UserResponse();
            var usr = usuario.GetUsuarios(model.username, model.password);
            if (usr == false) return null;
            response.username = model.username;
            Usuarios usuarios = new Usuarios();
            response.token = GetToken(usuarios);

            return response;
        }
        private string GetToken(Usuarios model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, UserCache.idusr.ToString()),
                        new Claim(ClaimTypes.Email, UserCache.email)
                    }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
