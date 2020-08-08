using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext db;

        public EditModel(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await db.Books.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookFromDB = await db.Books.FindAsync(Book.Id);
                bookFromDB.Name = Book.Name;
                bookFromDB.Author = Book.Author;
                bookFromDB.Publisher = Book.Publisher;
                bookFromDB.ISBN = Book.ISBN;
                bookFromDB.Address = Book.Address;
                bookFromDB.Pages = Book.Pages;
                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}