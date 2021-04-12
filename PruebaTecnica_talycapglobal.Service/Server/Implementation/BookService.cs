using PruebaTecnica_talycapglobal.Data.Model;
using PruebaTecnica_talycapglobal.Service.Server.Interface;
using PruebaTecnica_talycapglobal.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_talycapglobal.Service.Server.Implementation
{
    /// <summary>
    /// class BookService
    /// </summary>
    public class BookService : IBookService
    {
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// Constructor de la clase BookService
        /// </summary>
        /// <param name="unitOfWork"></param>
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Function to create a new Book
        /// </summary>
        /// <param name="Book">Book object with the information</param>
        /// <returns>New Book identifier</returns>
        public async Task<int> BookCreate(Book book)
        {
            var id = await Task.FromResult(_unitOfWork.Book.Insert(book));
            return id;
        }
        /// <summary>
        /// Function to update a Book
        /// </summary>
        /// <param name="Book">Book object with the information to update</param>
        /// <returns>True if the update is correct; otherwise it is false</returns>
        public async Task<bool> BookUpdate(Book book)
        {
            var response = false;
            // Get book by id
            var bookToUpdate = _unitOfWork.Book.GetById(book.Id);
            // Check if bookToUpdate is not null
            if (bookToUpdate != null)
            {
                // Change the book Title
                bookToUpdate.Title = book.Title;
                // Change the book Description
                bookToUpdate.Description = book.Description;
                // Change the book PageCount
                bookToUpdate.PageCount = book.PageCount;
                // Change the book Excerpt
                bookToUpdate.Excerpt = book.Excerpt;
                // Change the book PublishDate
                bookToUpdate.PublishDate = book.PublishDate;
                // Update book
                response = await Task.FromResult(_unitOfWork.Book.Update(bookToUpdate));
            }
            // Return response
            return response;
        }
        /// <summary>
        /// Function to delete a Book
        /// </summary>
        /// <param name="id">Book identifier to delete</param>
        /// <returns>True if the deletion is correct; otherwise it is false</returns>
        public async Task<bool> BookDelete(int id)
        {
            // Get book by id
            var bookToDelete = _unitOfWork.Book.GetById(id);
            // Check if bookToUpdate is not null
            if (bookToDelete != null)
            {
                return await Task.FromResult(_unitOfWork.Book.Delete(bookToDelete));
            }
            return false;
        }
        /// <summary>
        /// Function to get all Books
        /// </summary>
        /// <returns>Book list</returns>
        public async Task<List<Book>> BookGet()
        {
            var books = await Task.FromResult(_unitOfWork.Book.Get());
            return books.ToList();
        }
        /// <summary>
        /// Function to get a Book by id
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <returns>Book object</returns>
        public async Task<Book> BookGetById(int id)
        {
            var book = await Task.FromResult(_unitOfWork.Book.GetById(id));
            return book;
        }
        /// <summary>
        /// Function to get all Books whith Authors
        /// </summary>
        /// <returns>List BooksAuthors</returns>
        public async Task<List<BookAuthors>> BookAuthorGetAll()
        {
            var rest = new List<BookAuthors>();
            var books = await Task.FromResult(_unitOfWork.Book.Get());
            foreach (var book in books)
            {
                var authors = _unitOfWork.Book.BookAuthorGet(book.Id);
                rest.Add(new BookAuthors()
                {
                    Id = book.Id,
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate,
                    Authors = authors.Aggregate((i, j) => i + ", " + j)
                });
            }
            return rest;
        }
        /// <summary>
        /// Funcion que crea la relacion entre Book y author
        /// </summary>
        /// <param name="idBook">Id de la tabla Book</param>
        /// <param name="idAuthor">id de la tabla Author</param>
        /// <returns></returns>
        public async Task<bool> BookAuthorCreate(int idBook, int idAuthor)
        {
            _unitOfWork.Book.BookAuthorInsert(idBook, idAuthor);
            return await Task.FromResult(true);
        }
    }
}
