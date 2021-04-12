using Dapper;
using PruebaTecnica_talycapglobal.Data.Model;
using PruebaTecnica_talycapglobal.Repository.Base;
using PruebaTecnica_talycapglobal.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PruebaTecnica_talycapglobal.Repository.Implementation
{
    /// <summary>
    /// class BookRepository
    /// </summary>
    public class BookRepository : Repository<Book>, IBookRepository
    {
        /// <summary>
        /// Constructor del Repositorio de Books
        /// </summary>
        /// <param name="connectionString"></param>
        public BookRepository(string connectionString) : base(connectionString) { }

        /// <summary>
        /// Funcion que crea la relacion entre authors y books
        /// </summary>
        /// <param name="idBook">Id de la tabla Book</param>
        /// <param name="idAuthor">Id de la tabla Author</param>
        public void BookAuthorInsert(int idBook, int idAuthor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string uQuery = string.Format("INSERT INTO [dbo].[AuthorBook] ([IdBook], [IdAuthor]) VALUES({0}, {1})",idBook,idAuthor);
                connection.Open();
                connection.Execute(uQuery);                
            }
        }
        /// <summary>
        /// Funcion que trae los los libros relacionada con los autores
        /// </summary>
        /// <param name="idBook">Id de la tabla Book</param>
        /// <returns>Lista de string con Authors</returns>
        public List<string> BookAuthorGet(int idBook)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string uQuery = string.Format("SELECT CONCAT(A.FirstName,' ',A.LastName) AS NAME FROM DBO.Author A JOIN DBO.AuthorBook AB ON AB.IdAuthor = A.Id AND AB.IdBook = {0}", idBook);
                connection.Open();
                var authors = connection.Query<string>(uQuery).ToList();
                return authors;
            }
        }
    }
}
