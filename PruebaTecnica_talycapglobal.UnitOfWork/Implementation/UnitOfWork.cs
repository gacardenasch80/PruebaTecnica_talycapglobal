using PruebaTecnica_talycapglobal.Repository.Implementation;
using PruebaTecnica_talycapglobal.Repository.Interfaces;
using PruebaTecnica_talycapglobal.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_talycapglobal.UnitOfWork.Implementation
{
    /// <summary>
    /// class UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Constructor de la UnitOfWork
        /// </summary>
        /// <param name="connectionString"></param>
        public UnitOfWork(string connectionString)
        {
            Authors = new AuthorRepository(connectionString);
            Book = new BookRepository(connectionString);
        }
        /// <summary>
        /// Interface Authors
        /// </summary>
        public IAuthorRepository Authors { get; private set; }
        /// <summary>
        /// Interface Book
        /// </summary>
        public IBookRepository Book { get; private set; }
    }
}
