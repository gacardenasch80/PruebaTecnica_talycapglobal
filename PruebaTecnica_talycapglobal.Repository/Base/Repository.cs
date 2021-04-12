using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PruebaTecnica_talycapglobal.Repository.Base
{
    /// <summary>
    /// class Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string _connectionString;
        /// <summary>
        /// Patron de respositorio constructor
        /// </summary>
        /// <param name="connectionString">Cadena de conexion</param>
        public Repository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{ type.Name }"; };
            _connectionString = connectionString;
        }
        /// <summary>
        /// Function to delete entity with dapper
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Delete(entity);
            }
        }
        /// <summary>
        /// Function get all of entity
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Get()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<T>();
            }
        }
        /// <summary>
        /// Function to get by id table
        /// </summary>
        /// <param name="id">id Table</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<T>(id);
            }
        }
        /// <summary>
        /// Function to insert entity with dapper
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns></returns>
        public int Insert(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }
        /// <summary>
        /// Function to udpate entity with dapper
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Update(entity);
            }
        }
    }

}
