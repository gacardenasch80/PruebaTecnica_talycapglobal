using PruebaTecnica_talycapglobal.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_talycapglobal.Service.Server.Interface
{
    /// <summary>
    /// interface IAuthorService
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Function to get all Authors
        /// </summary>
        /// <returns>Author list</returns>
        Task<List<Author>> AuthorGet();
        /// <summary>
        /// Function to get a Author by id
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <returns>Author object</returns>
        Task<Author> AuthorGetById(int id);
        /// <summary>
        /// Function to create a new Author
        /// </summary>
        /// <param name="Author">Author object with the information</param>
        /// <returns>New Author identifier</returns>
        Task<int> AuthorCreate(Author Author);
        /// <summary>
        /// Funcion que realiza la Sincronización entre el api externo y la base de datos
        /// </summary>
        /// <returns>true or false</returns>
        Task<bool> AuthorSync();
        /// <summary>
        /// Function to update a Author
        /// </summary>
        /// <param name="Author">Author object with the information to update</param>
        /// <returns>True if the update is correct; otherwise it is false</returns>
        Task<bool> AuthorUpdate(Author Author);
        /// <summary>
        /// Function to delete a Author
        /// </summary>
        /// <param name="id">Author identifier to delete</param>
        /// <returns>True if the deletion is correct; otherwise it is false</returns>
        Task<bool> AuthorDelete(int id);
    }
}
