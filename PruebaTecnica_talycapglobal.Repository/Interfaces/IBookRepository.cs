using PruebaTecnica_talycapglobal.Data.Model;
using PruebaTecnica_talycapglobal.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PruebaTecnica_talycapglobal.Repository.Interfaces
{
    /// <summary>
    /// interface IBookRepository
    /// </summary>
    public interface IBookRepository : IRepository<Book>
    {
        /// <summary>
        /// Funcion que crea la relacion entre authors y books
        /// </summary>
        /// <param name="idBook">Id de la tabla Book</param>
        /// <param name="idAuthor">Id de la tabla Author</param>
        void BookAuthorInsert(int idBook, int idAuthor);
        /// <summary>
        /// Funcion que trae los los libros relacionada con los autores
        /// </summary>
        /// <param name="idBook">Id de la tabla Book</param>
        /// <returns>Lista de string con Authors</returns>
        List<string> BookAuthorGet(int idBook);
    }
}
