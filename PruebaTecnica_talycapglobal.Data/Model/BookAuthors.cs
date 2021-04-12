using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_talycapglobal.Data.Model
{
    /// <summary>
    /// class BookAuthors
    /// </summary>
    public class BookAuthors
    {
        /// <summary>
        /// Id de la tabla Book
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Title de la tabla book
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// PageCoun de la tabla Book
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// PublishDate de la tabla Book
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// Authores de la tabla de relacion de libros con autores
        /// </summary>
        public string Authors { get; set; }
    }
}
