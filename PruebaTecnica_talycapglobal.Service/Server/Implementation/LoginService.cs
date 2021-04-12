using Microsoft.Extensions.Options;
using PruebaTecnica_talycapglobal.Data.Model;
using PruebaTecnica_talycapglobal.Service.ExternService;
using PruebaTecnica_talycapglobal.Service.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace PruebaTecnica_talycapglobal.Service.Server.Implementation
{
    /// <summary>
    /// class LoginService
    /// </summary>
    public class LoginService : ILoginService
    {
        /// <summary>
        /// Funcion que se encarga de realizar el logueo del usuario al sistema
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="passWord">Password del usuario</param>
        /// <returns></returns>
        public async Task<User> Login(string userName, string passWord)
        {
            var users = await FakeRestAPI.GetUser();
            if (users.Any(x => x.UserName == userName && x.Password == passWord))
            {
                var user = users.FirstOrDefault();
                return new User() {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password
                };
            }
            return null;
        }
        /// <summary>
        /// Funcion que retorna la cantidad de usuarios en el servicio externo
        /// </summary>
        /// <returns>Cantidad de usuarios</returns>
        public async Task<int> UsersCount()
        {
            var users = await FakeRestAPI.GetUser();
            return users.Count();
        }
    }
}
