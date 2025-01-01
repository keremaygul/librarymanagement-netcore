using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Infrastructure.Data;

namespace LibraryManagement.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public BooksController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return Ok(Array.Empty<object>());

            var books = await _context.Books
                .Where(b => b.AvailableCopies > 0 &&
                           (b.Title.Contains(search) ||
                            b.ISBN.Contains(search) ||
                            b.Author.Contains(search)))
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Author,
                    b.ISBN,
                    b.AvailableCopies
                })
                .Take(10)
                .ToListAsync();

            return Ok(books);
        }
    }
}