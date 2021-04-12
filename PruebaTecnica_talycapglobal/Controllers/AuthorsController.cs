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
    /// Controlador AuthorsController
    /// </summary>
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("[controller]")]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;

        /// <summary>
        /// Controller constructor
        /// </summary>
        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }
        /// <summary>
        /// Returns the complete list of Authors in the database
        /// </summary>
        /// <returns>Author list</returns>
        /// <response code="200">Returns the get item</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Author>>> GetAll()
        {
            var response = await _service.AuthorGet();
            return Ok(response);
        }
        /// <summary>
        /// Function to get a Author by id
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <returns>Author object with the information</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Author>> GetById(int id)
        {
            var response = await _service.AuthorGetById(id);
            if (response != null)
                return Ok(response);
            else
                return NotFound();
        }
        /// <summary>
        /// Function to get a Author count
        /// </summary>
        /// <returns>Author object with the information</returns>
        [HttpGet("Count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetCount()
        {
            var response = await _service.AuthorGet();
            return Ok(response.Count);
        }
        /// <summary>
        /// Function to create a new Author
        /// </summary>
        /// <param name="Author">Rol JSON object with all information</param>
        /// <returns>Expense type list</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="400">Model is not valid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Post(Author Author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _service.AuthorCreate(Author);
            return Ok(response);
        }
        /// <summary>
        /// Function to create a new Author
        /// </summary>
        /// <param name="Author">Rol JSON object with all information</param>
        /// <returns>Expense type list</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="400">Model is not valid</response>
        [HttpGet("Sync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> PostSync()
        {
            var response = await _service.AuthorSync();
            return Ok(response);
        }
        /// <summary>
        /// Function to update a Author
        /// </summary>
        /// <param name="Author">Rol JSON object with all information to update</param>
        /// <returns>True if the update is correct; otherwise it is false</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="400">Model is not valid</response>
        /// <response code="404">Id not found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> Put(Author Author)
        {
            if (!ModelState.IsValid || Author.Id <= 0)
            {
                return BadRequest();
            }
            if (await _service.AuthorUpdate(Author))
                return Ok(true);
            else
                return NotFound();
        }
        /// <summary>
        /// Function to delete a Author by id
        /// </summary>
        /// <param name="id">Author by id</param>
        /// <returns>True if the deletion is correct; otherwise it is false</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="404">Id is not found</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (await _service.AuthorDelete(id))
                return Ok(true);
            else
                return NotFound();
        }
    }
}
