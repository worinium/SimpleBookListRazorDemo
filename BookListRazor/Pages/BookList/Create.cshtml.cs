using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext db;

        public CreateModel(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }
        [BindProperty]
        public Book Book { get; set; }
        
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await db.Books.AddAsync(Book);
                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}