using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_talycapglobal.Data.Model;
using PruebaTecnica_talycapglobal.Service.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_talycapglobal.Controllers
{
    /// <summary>
    /// Controlador BooksController
    /// </summary>
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        /// <summary>
        /// Controller constructor
        /// </summary>
        public BooksController(IBookService service)
        {
            _service = service;
        }
        /// <summary>
        /// Returns the complete list of books in the database
        /// </summary>
        /// <returns>Book list</returns>
        /// <response code="200">Returns the get item</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var response = await _service.BookGet();
            return Ok(response);
        }
        /// <summary>
        /// Returns the complete list of rols in the database
        /// </summary>
        /// <returns>Rol list</returns>
        /// <response code="200">Returns the get item</response>
        [HttpGet("Authors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookAuthors>>> GetBookAuthorsAll()
        {
            var response = await _service.BookAuthorGetAll();
            return Ok(response);
        }
        /// <summary>
        /// Function to get a book by id
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <returns>Rol object with the information</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var response = await _service.BookGetById(id);
            if (response != null)
                return Ok(response);
            else
                return NotFound();
        }
        /// <summary>
        /// Function to get a rol by id
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <returns>Rol object with the information</returns>
        [HttpGet("Count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetCount()
        {
            var response = await _service.BookGet();
            return Ok(response.Count);
        }
        /// <summary>
        /// Function to create a new rol
        /// </summary>
        /// <param name="rol">Rol JSON object with all information</param>
        /// <returns>Expense type list</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="400">Model is not valid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Post(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _service.BookCreate(book);
            return Ok(response);
        }
        /// <summary>
        /// Function to update a rol
        /// </summary>
        /// <param name="book">Rol JSON object with all information to update</param>
        /// <returns>True if the update is correct; otherwise it is false</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="400">Model is not valid</response>
        /// <response code="404">Id not found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> Put(Book book)
        {
            if (!ModelState.IsValid || book.Id <= 0)
            {
                return BadRequest();
            }
            if (await _service.BookUpdate(book))
                return Ok(true);
            else
                return NotFound();
        }
        /// <summary>
        /// Function to delete a rol by id
        /// </summary>
        /// <param name="id">Rol by id</param>
        /// <returns>True if the deletion is correct; otherwise it is false</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="404">Id is not found</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (await _service.BookDelete(id))
                return Ok(true);
            else
                return NotFound();
        }
    }
}
