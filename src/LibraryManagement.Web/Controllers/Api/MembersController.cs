using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Infrastructure.Data;

namespace LibraryManagement.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public MembersController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return Ok(Array.Empty<object>());

            var members = await _context.Members
                .Where(m => m.IsActive &&
                           (m.FirstName.Contains(search) ||
                            m.LastName.Contains(search) ||
                            m.Phone.Contains(search) ||
                            m.Email.Contains(search)))
                .Select(m => new
                {
                    m.Id,
                    FullName = $"{m.FirstName} {m.LastName}",
                    m.Email,
                    m.Phone
                })
                .Take(10)
                .ToListAsync();

            return Ok(members);
        }
    }
}