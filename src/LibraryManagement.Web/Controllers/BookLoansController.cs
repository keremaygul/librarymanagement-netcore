using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Core.Entities;
using LibraryManagement.Infrastructure.Data;

namespace LibraryManagement.Web.Controllers
{
    public class BookLoansController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookLoansController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: BookLoans
        public async Task<IActionResult> Index(string searchString, string status)
        {
            var bookLoans = _context.BookLoans
                .Include(b => b.Book)
                .Include(b => b.Member)
                .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                bookLoans = bookLoans.Where(s =>
                    s.Book.Title.Contains(searchString) ||
                    s.Member.FirstName.Contains(searchString) ||
                    s.Member.LastName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(status))
            {
                switch (status.ToLower())
                {
                    case "active":
                        bookLoans = bookLoans.Where(l => !l.IsReturned);
                        break;
                    case "overdue":
                        bookLoans = bookLoans.Where(l => !l.IsReturned && l.DueDate < DateTime.Now);
                        break;
                    case "returned":
                        bookLoans = bookLoans.Where(l => l.IsReturned);
                        break;
                }
            }

            return View(await bookLoans.OrderByDescending(l => l.LoanDate).ToListAsync());
        }

        // GET: BookLoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.BookLoans
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bookLoan == null)
            {
                return NotFound();
            }

            return View(bookLoan);
        }

        // GET: BookLoans/Create
        public IActionResult Create()
        {
            var availableBooks = _context.Books.Where(b => b.AvailableCopies > 0).Select(b => new { b.Id, b.Title }).ToList();
            var activeMembers = _context.Members.Where(m => m.IsActive).Select(m => new { m.Id, m.FullName }).ToList();

            ViewData["BookId"] = new SelectList(availableBooks, "Id", "Title");
            ViewData["MemberId"] = new SelectList(activeMembers, "Id", "FullName");

            var bookLoan = new BookLoan
            {
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14)
            };

            return View(bookLoan);
        }

        // POST: BookLoans/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] BookLoan bookLoan)
        {
            try
            {
                // Sadece gerekli alanları kontrol et
                ModelState.Remove("Book");
                ModelState.Remove("Member");

                if (!ModelState.IsValid)
                {
                    var availableBooks = _context.Books.Where(b => b.AvailableCopies > 0).Select(b => new { b.Id, b.Title }).ToList();
                    var activeMembers = _context.Members.Where(m => m.IsActive).Select(m => new { m.Id, m.FullName }).ToList();

                    ViewData["BookId"] = new SelectList(availableBooks, "Id", "Title", bookLoan.BookId);
                    ViewData["MemberId"] = new SelectList(activeMembers, "Id", "FullName", bookLoan.MemberId);
                    return View(bookLoan);
                }

                var book = await _context.Books.FindAsync(bookLoan.BookId);
                if (book == null || book.AvailableCopies <= 0)
                {
                    ModelState.AddModelError("BookId", "Seçilen kitap mevcut değil veya tüm kopyaları ödünç verilmiş.");
                    return View(bookLoan);
                }

                var member = await _context.Members.FindAsync(bookLoan.MemberId);
                if (member == null || !member.IsActive)
                {
                    ModelState.AddModelError("MemberId", "Seçilen üye aktif değil.");
                    return View(bookLoan);
                }

                book.AvailableCopies--;
                bookLoan.CreatedAt = DateTime.Now;
                bookLoan.IsReturned = false;
                bookLoan.ExtensionCount = 0;

                _context.Add(bookLoan);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Bir hata oluştu: {ex.Message}");
                return View(bookLoan);
            }
        }

        // POST: BookLoans/Return/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int id)
        {
            var bookLoan = await _context.BookLoans
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bookLoan == null)
            {
                return NotFound();
            }

            if (!bookLoan.IsReturned)
            {
                bookLoan.IsReturned = true;
                bookLoan.ReturnDate = DateTime.Now;
                bookLoan.Book.AvailableCopies++;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: BookLoans/Extend/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Extend(int id)
        {
            var bookLoan = await _context.BookLoans.FindAsync(id);

            if (bookLoan == null)
            {
                return NotFound();
            }

            if (!bookLoan.IsReturned && bookLoan.ExtensionCount < 2)
            {
                bookLoan.DueDate = bookLoan.DueDate.AddDays(14);
                bookLoan.ExtensionCount++;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id = bookLoan.Id });
        }
    }
}