using PruebaTecnica_talycapglobal.Data.Model;
using PruebaTecnica_talycapglobal.Repository.Base;
using PruebaTecnica_talycapglobal.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_talycapglobal.Repository.Implementation
{
    /// <summary>
    /// class AuthorRepository
    /// </summary>
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        /// <summary>
        /// /// Constructor del Repositorio de authors
        /// </summary>
        /// <param name="connectionString"></param>
        public AuthorRepository(string connectionString) : base(connectionString) { }
    }
}
