using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext db;

        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }
        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnDeletePost(int id)
        {
            var book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}