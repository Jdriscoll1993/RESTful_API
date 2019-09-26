using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Helpers;
using AutoMapper;

namespace Library.API.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private ILibraryRepository _libraryRepository;
        //Injecting an instance of our repository thorugh constructor injection
        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        // In this action we should get the authors from our repository and return them. But we need an instance of our repository.

        //GET api/authors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            
            var authorsFromRepo = _libraryRepository.GetAuthors();

            var authors = Mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);

            return Ok(authors);
        }

        //GET api/authors/{id}
        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            //call into repository to get our author
            var authorFromRepo = _libraryRepository.GetAuthor(id);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            var author = Mapper.Map<AuthorDto>(authorFromRepo);
            return Ok(author);
        }
    }
}

