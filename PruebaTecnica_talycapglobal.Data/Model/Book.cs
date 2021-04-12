using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_talycapglobal.Data.Model
{
    /// <summary>
    /// class Book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Id de la tabla Book
        /// </summary>
        [ExplicitKey]
        public int Id { get; set; }
        /// <summary>
        /// Title de la tabla Book
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description de la tabla Book
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// PageCount de la tabla Book
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// Excerpt de la tabla Book
        /// </summary>
        public string Excerpt { get; set; }
        /// <summary>
        /// PublishDate de la tabla Book
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// Authors de la tabla Book
        /// </summary>
        [Write(false)]
        [Computed]
        public IList<Author> Authors { get; set; }
    }
}
