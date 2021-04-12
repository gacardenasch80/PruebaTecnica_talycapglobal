using PruebaTecnica_talycapglobal.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_talycapglobal.Service.Server.Interface
{
    /// <summary>
    /// interface IBookService
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Function to get all Books
        /// </summary>
        /// <returns>Book list</returns>
        Task<List<Book>> BookGet();
        /// <summary>
        /// Function to get all Books whith Authors
        /// </summary>
        /// <returns>List BooksAuthors</returns>
        Task<List<BookAuthors>> BookAuthorGetAll();
        /// <summary>
        /// Function to get a Book by id
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <returns>Book object</returns>
        Task<Book> BookGetById(int id);
        /// <summary>
        /// Function to create a new Book
        /// </summary>
        /// <param name="Book">Book object with the information</param>
        /// <returns>New Book identifier</returns>
        Task<int> BookCreate(Book Book);
        /// <summary>
        /// Funcion que crea la relacion entre Book y author
        /// </summary>
        /// <param name="idBook">Id de la tabla Book</param>
        /// <param name="idAuthor">id de la tabla Author</param>
        /// <returns></returns>
        Task<bool> BookAuthorCreate(int idBook,int idAuthor);
        /// <summary>
        /// Function to update a Book
        /// </summary>
        /// <param name="Book">Book object with the information to update</param>
        /// <returns>True if the update is correct; otherwise it is false</returns>
        Task<bool> BookUpdate(Book Book);
        /// <summary>
        /// Function to delete a Book
        /// </summary>
        /// <param name="id">Book identifier to delete</param>
        /// <returns>True if the deletion is correct; otherwise it is false</returns>
        Task<bool> BookDelete(int id);
    }
}
