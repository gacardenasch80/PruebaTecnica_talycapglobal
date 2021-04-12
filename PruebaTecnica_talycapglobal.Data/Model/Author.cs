using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_talycapglobal.Data.Model
{
    /// <summary>
    /// class Author
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Id de la tabla Author
        /// </summary>
        [ExplicitKey]
        public int Id { get; set; }
        /// <summary>
        /// FirstName de la tabla Author
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName de la tabla Author
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Lista de libros relacionados al author
        /// </summary>
        [Write(false)]
        [Computed]
        public IList<Book> Books { get; set; }
    }
}
