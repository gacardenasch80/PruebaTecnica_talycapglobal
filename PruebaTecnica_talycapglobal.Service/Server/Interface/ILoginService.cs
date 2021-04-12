using PruebaTecnica_talycapglobal.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_talycapglobal.Service.Server.Interface
{
    /// <summary>
    /// interface ILoginService
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Funcion que se encarga de realizar el logueo del usuario al sistema
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="passWord">Password del usuario</param>
        /// <returns></returns>
        Task<User> Login(string userName, string passWord);
        /// <summary>
        /// Funcion que retorna la cantidad de usuarios en el servicio externo
        /// </summary>
        /// <returns>Cantidad de usuarios</returns>
        Task<int> UsersCount();
    }
}
