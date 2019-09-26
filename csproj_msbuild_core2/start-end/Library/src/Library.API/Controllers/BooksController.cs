using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    public class BooksController : Controller
    {
        // Repository is injected using Constructor Injection
        private ILibraryRepository _libraryRepository;
        public BooksController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        [HttpGet("api/authors/{authorId}/books")]
        public IActionResult GetBooksFromAuthor()
        { }
    }
}
