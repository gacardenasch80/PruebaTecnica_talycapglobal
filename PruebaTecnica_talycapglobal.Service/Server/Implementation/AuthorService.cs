using PruebaTecnica_talycapglobal.Data.Model;
using PruebaTecnica_talycapglobal.Service.ExternService;
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
    /// class AuthorService
    /// </summary>
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// Constructor de la clase AuthorService
        /// </summary>
        /// <param name="unitOfWork"></param>
        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Function to create a new Author
        /// </summary>
        /// <param name="Author">Author object with the information</param>
        /// <returns>New Author identifier</returns>
        public async Task<int> AuthorCreate(Author author)
        {
            var id = await Task.FromResult(_unitOfWork.Authors.Insert(author));
            return id;
        }
        /// <summary>
        /// Funcion que realiza la Sincronización entre el api externo y la base de datos
        /// </summary>
        /// <returns>true or false</returns>
        public async Task<bool> AuthorSync()
        {
            var authors = await FakeRestAPI.GetAuthors();
            var books = await FakeRestAPI.GetBooks();
            var bookService = new BookService(_unitOfWork);
            foreach (var author in authors)
            {
                var newAuthor = await AuthorGetById(author.id);
                bool bandera = false;
                if (newAuthor == null)
                {
                    newAuthor = new Author()
                    {
                        Id = author.id,
                        FirstName = author.firstName,
                        LastName = author.lastName
                    };
                    await Task.FromResult(_unitOfWork.Authors.Insert(newAuthor));
                    bandera = true;
                }
                var newBook = await bookService.BookGetById(author.idBook);
                if (newBook == null)
                {
                    var book = books.Where(x => x.id == author.idBook).FirstOrDefault();
                    if (book != null)
                    {
                        newBook = new Book()
                        {
                            Id = book.id,
                            Description = book.description,
                            Excerpt = book.excerpt,
                            Title = book.title,
                            PageCount = book.pageCount,
                            PublishDate = book.publishDate
                        };
                        await bookService.BookCreate(newBook);
                        bandera = true;
                    }
                }
                if (bandera)
                {
                    await bookService.BookAuthorCreate(newBook.Id, newAuthor.Id);
                }
            }
            return true;
        }
        /// <summary>
        /// Function to update a Author
        /// </summary>
        /// <param name="Author">Author object with the information to update</param>
        /// <returns>True if the update is correct; otherwise it is false</returns>
        public async Task<bool> AuthorUpdate(Author author)
        {
            var response = false;
            // Get Author by id
            var authorToUpdate = _unitOfWork.Authors.GetById(author.Id);
            // Check if authorToUpdate is not null
            if (authorToUpdate != null)
            {
                // Change the Author FirstName
                authorToUpdate.FirstName = author.FirstName;
                // Change the Author LastName
                authorToUpdate.LastName = author.LastName;
                // Update Author
                response = await Task.FromResult(_unitOfWork.Authors.Update(authorToUpdate));
            }
            // Return response
            return response;
        }
        /// <summary>
        /// Function to delete a Author
        /// </summary>
        /// <param name="id">Author identifier to delete</param>
        /// <returns>True if the deletion is correct; otherwise it is false</returns>
        public async Task<bool> AuthorDelete(int id)
        {
            // Get author by id
            var authorToDelete = _unitOfWork.Authors.GetById(id);
            // Check if authorToDelete is not null
            if (authorToDelete != null)
            {
                return await Task.FromResult(_unitOfWork.Authors.Delete(authorToDelete));
            }
            return false;
        }
        /// <summary>
        /// Function to get all Authors
        /// </summary>
        /// <returns>Author list</returns>
        public async Task<List<Author>> AuthorGet()
        {
            var authors = await Task.FromResult(_unitOfWork.Authors.Get());
            return authors.ToList();
        }
        /// <summary>
        /// Function to get a Author by id
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <returns>Author object</returns>
        public async Task<Author> AuthorGetById(int id)
        {
            var author = await Task.FromResult(_unitOfWork.Authors.GetById(id));
            return author;
        }
    }
}
