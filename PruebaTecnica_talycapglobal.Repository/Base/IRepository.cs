using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_talycapglobal.Repository.Base
{
    /// <summary>
    /// interface IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        bool Delete(T entity);
        /// <summary>
        /// Function to udpate entity with dapper
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns></returns>
        bool Update(T entity);
        /// <summary>
        /// Function to insert entity with dapper
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns></returns>
        int Insert(T entity);
        /// <summary>
        /// Function get all of entity
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Get();
        /// <summary>
        /// Function to get by id table
        /// </summary>
        /// <param name="id">id Table</param>
        /// <returns></returns>
        T GetById(int id);
    }
}
